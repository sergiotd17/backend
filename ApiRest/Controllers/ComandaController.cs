using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

[Route("comanda")]
[ApiController]
public class ComandaController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ComandaService _comandaService;
    private readonly IMapper _mapper;

    public ComandaController(ComandaService comandaService,IMapper mapper)
    {
        _mapper = mapper;
        _comandaService = comandaService;
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "camarero,cocinero")]
    public async Task<IList<ComandaDTO>> GetAll() 
    {
        var comandas = await _comandaService.FindAll();
        return comandas.Select(c => _mapper.Map<ComandaDTO>(c)).ToList();
    }
    
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "camarero,cocinero")]
    public async Task<ComandaDTO?> Get(long id)
    {
        var comanda = await _comandaService.FindById(id); 
        return comanda is null ? null :  _mapper.Map<ComandaDTO>(comanda);
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "camarero,gerente")]
    public async Task<IActionResult> Create(ComandaCreationDTO comandaDto) 
    {
        try
        {
            var comanda = _mapper.Map<Comanda>(comandaDto);
            await _comandaService.Save(comanda);
            return Ok("Comanda Creada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero,cocinero")]
    public async Task<IActionResult?> Update(long id, ComandaDTO comandaDto)
    {
        try
        {
            var comanda = _mapper.Map<Comanda>(comandaDto); 
            if (id != comanda.Id) 
            { 
                return null;
            }

            await _comandaService.Update(comanda);
            return Ok("Comanda Actualizada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut]
    [Route("Cocinero")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,cocinero,camarero")]
    public async Task<IActionResult> AsignCocinero(ComandaAsignarCocinaDTO comanda)
    {
        try
        {
            await _comandaService.AsignCocinero(comanda.Id, (long)comanda.IdCocinero);
            return Ok("Asignado Correctamente!");
        }catch(Exception e)
        {
            return BadRequest("No se ha podido asignar el Cocinero a la comanda");
        }
    }

    [HttpDelete("{id}")] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero")]
    public async Task<bool> Delete(long id) 
    { 
        var deleted = await _comandaService.DeleteById(id); 
        return deleted;
    }
}