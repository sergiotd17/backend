using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ApiRest.Entities.Pedido;

namespace ApiRest.Controllers;

[Route("Camarero")]
[ApiController]
public class CamareroController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly CamareroService _camareroService;
    private readonly PedidoService _pedidoService;
    private readonly ComandaService _comandaService;
    private readonly IMapper _mapper;
            
    public CamareroController(CamareroService camareroService,ComandaService comanda, PedidoService pedidoService, IMapper mapper) 
    { 
        _camareroService = camareroService; 
        _pedidoService  = pedidoService;
        _comandaService = comanda;
        _mapper = mapper;
    }
    
    // Obtiene listado de todos los camarero
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IList<CamareroDTO>> GetAll() 
    {
        var camareros = await _camareroService.FindAll();
        return camareros.Select(c => _mapper.Map<CamareroDTO>(c)).ToList();
    }
    //Obtiene un camarero por id
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<CamareroDTO?> Get(long id)
    {
        var camarero =  await _camareroService.FindById(id); 
        return camarero is null ? null : _mapper.Map<CamareroDTO>(camarero);
    }
    
    //Crea un camarero 
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Create(CamareroDTO camareroDto)
    {
        try
        {
            
            var newpass = BCrypt.Net.BCrypt.HashPassword(camareroDto.Password);
            camareroDto.Password = newpass;

            var camarero = _mapper.Map<Camarero>(camareroDto); 
            await _camareroService.Save(camarero);
            return Ok("Camarero creado correctamente");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult?> Update(long id, CamareroDTO camareroDto)
    {
        try
        {
            var camarero = _mapper.Map<Camarero>(camareroDto); 
            if (id != camarero.Id) 
            { 
                return null;
            } 
            await _camareroService.Update(camarero);
            return Ok("Camarero actualizado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpGet]
    [Route("Bebidas/{idCamarero}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="camarero,gerente")]
    public async Task<List<ComandasCamarero>?> GetBebidas(long idCamarero)
    {
        try
        {
            var comandas = await _camareroService.GetBebidas(idCamarero);
            var comandasDto = new List<ComandasCamarero>();

            comandas.ForEach(com =>
                comandasDto.Add(_mapper.Map<ComandasCamarero>(com))
                );

            return comandasDto;
        }catch(Exception e)
        {
            return null;
        }
    }

    [HttpGet]
    [Route("{idCamarero}/Comandas")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "camarero,gerente")]
    public async Task<List<ComandasCamarero>?> GetComandasActivas(long idCamarero)
    {
        try
        {
            var comandas = await _camareroService.GetComandasActivas(idCamarero);
            var comandasDto = new List<ComandasCamarero>();

            comandas.ForEach(com =>
                comandasDto.Add(_mapper.Map<ComandasCamarero>(com))
                );

            return comandasDto;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    [HttpGet]
    [Route("{id}/Pedidos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "camarero,gerente")]
    public async Task<List<PedidoDTO>?> GetPedidoCamarero(long id)
    {
        try
        {
            var pedidos = await _pedidoService.GetPedidoCamarero(id);
            var pedidosDto = new List<PedidoDTO>();
            pedidos.ForEach(ped =>
                pedidosDto.Add(_mapper.Map<PedidoDTO>(ped))
            );
            return pedidosDto;
        }
        catch (Exception)
        {

            return null;
        }
    }
    
    [HttpPut]
    [Route("Comanda/{idComanda}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "camarero,gerente")]
    public async Task<IActionResult> SetComandaEntregada(long idComanda)
    {
        var comanda = await _comandaService.FindById(idComanda);
        if (comanda == null)
        {
            return BadRequest("No existe esa comanda");
        }
        else
        {
            comanda.Estado = (EstadosComanda)3;
            await _comandaService.Update(comanda);
            return Ok("Comanda Entregada");
        }
    }


    [HttpPut]
    [Route("Pedido/{idPedido}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "camarero,gerente")]
    public async Task<IActionResult> SetPedidoPagado(long idPedido)
    {
        var pedido = await _pedidoService.FindById(idPedido);
        if (pedido == null)
        {
            return BadRequest("No existe ese pedido");
        }
        else
        {
            pedido.Estado = (EstadosPedido)1;
            await _pedidoService.Update(pedido);
            return Ok("Pedido Cobrado");
        }
    }

    [HttpDelete("{id}")] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Delete(long id) 
    { 
        var deleted = await _camareroService.DeleteById(id);
        if (deleted)
        {
            return Ok("Camarero borrado");
        }
        else
        {
            return BadRequest("Camarero no borrado");
        }
    }
}