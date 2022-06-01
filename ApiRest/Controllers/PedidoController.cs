using ApiRest.DTO;
using ApiRest.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ApiRest.Controller;

using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("pedido")]
[ApiController]
public class PedidoController : Controller
{
    private readonly PedidoService _pedidoService;
    private readonly IMapper _mapper;

    public PedidoController(PedidoService pedidoService, IMapper mapper)
    {
        _mapper = mapper;
        _pedidoService = pedidoService;
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<IList<PedidoDTO>> GetAll() 
    {
        var pedidos = await _pedidoService.FindAll();

        return pedidos.Select(p => _mapper.Map<PedidoDTO>(p)).ToList();
    }
    
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<PedidoDTO?> Get(long id)
    {
        var pedido = await _pedidoService.FindById(id);
        return pedido is null ? null : _mapper.Map<PedidoDTO>(pedido);
    }

    [HttpGet("/{id}/cuenta")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<PedidoDTO?> GetCuenta(long id)
    {
        var pedido = await _pedidoService.FindById(id);
        pedido.PrecioTotal = 0;
        foreach (var comanda in pedido.Comanda)
        {
            pedido.PrecioTotal += comanda.IdProductoNavigation.Precio;
        }

        await _pedidoService.Update(pedido);

        return _mapper.Map<PedidoDTO>(pedido);
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<IActionResult> Create(PedidoCreationDTO pedidoDto) 
    {
        try
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            await _pedidoService.Save(pedido);
            return Ok("Pedido Creado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id:long}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<IActionResult?> Update(long id, PedidoDTO pedidoDto)
    {
        try
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto); 
            if (id != pedido.Id) 
            { 
                return null;
            }

            await _pedidoService.Update(pedido);
            return Ok("Pedido Actualizado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<bool> Delete(long id) 
    { 
        var deleted = await _pedidoService.DeleteById(id); 
        return deleted;
    }
}