using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

[Route("Mesa")]
[ApiController]
public class MesaController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly MesaService _mesaService;
    private readonly PedidoService _pedidoService;
    private readonly IMapper _mapper;

    public MesaController(MesaService mesaService,IMapper mapper,PedidoService pedidoService)
    {
        _mesaService = mesaService;
        _mapper = mapper;
        _pedidoService = pedidoService;
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero,cocinero")]
    public async Task<IList<MesaDTO>> GetAll() 
    {
        var mesas = await _mesaService.FindAll();
        return mesas.Select(m => _mapper.Map<MesaDTO>(m)).ToList();
    }
    
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,cocinero,camarero")]
    public async Task<MesaDTO?> Get(long id)
    {
        var mesa = await _mesaService.FindById(id); 
        return mesa is null ? null : _mapper.Map<MesaDTO>(mesa);
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Create(MesaCreationDTO mesaDto) 
    {
        try
        {
            var mesa = _mapper.Map<Mesa>(mesaDto);
            await _mesaService.Save(mesa);
            return Ok("Mesa creada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id:long}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<IActionResult?> Update(long id, MesaCreationDTO mesaDto)
    {
        try
        {
            var mesa = _mapper.Map<Mesa>(mesaDto); 
            if (id != mesa.Id) 
            { 
                return null;
            }

            await _mesaService.Update(mesa);
            return Ok("Mesa Actualizado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<bool> Delete(long id) 
    { 
        var deleted = await _mesaService.DeleteById(id); 
        return deleted;
    }
    [HttpGet]
    [Route("MesaPedido/{idMesa:long}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<IResult> GetPedidoByMesaAsync(long idMesa)
    {
        var pedido =  await _pedidoService.GetPedidoByMesaAsync(idMesa);
        if (pedido == null)
        {
            return Results.BadRequest("vacio");
        }
        return Results.Ok(_mapper.Map<PedidoDTO>(pedido));
    }

}