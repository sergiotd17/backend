using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

[Route("Cocinero")]
[ApiController]
public class CocineroController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly CocineroService _cocineroService;
    private readonly ComandaService _comandaService;
    private readonly IMapper _mapper;
            
    public CocineroController(CocineroService cocineroService,ComandaService comandaService, IMapper mapper) 
    { 
        _cocineroService = cocineroService; 
        _comandaService = comandaService;
        _mapper = mapper;
    }
            
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<List<CocineroDTO>> GetAll() 
    {
        var cocineros = await _cocineroService.FindAll();
        return cocineros.Select(c => _mapper.Map<CocineroDTO>(c)).ToList();
    }
    
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,cocinero")]
    public async Task<CocineroDTO> Get(long id)
    {
        var cocinero = await _cocineroService.FindById(id); 
        return _mapper.Map<CocineroDTO>(cocinero);
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Create(CocineroDTO cocineroDto) 
    {
        try
        {
            var newpass = BCrypt.Net.BCrypt.HashPassword(cocineroDto.Password);
            cocineroDto.Password = newpass;
            
            var cocinero = _mapper.Map<Cocinero>(cocineroDto); 
            await _cocineroService.Save(cocinero);
            return Ok("Cocinero creado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
            
    [HttpPut("{id:long}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Update(long id, CocineroDTO cocineroDto)
    {
        try
        {
            var cocinero = _mapper.Map<Cocinero>(cocineroDto); 
            if (id != cocinero.Id)
            {
                return BadRequest("No coincide el ID a actualizar con el insertado");
            } 
            await _cocineroService.Update(cocinero);
            return Ok("Cocinero actualizado");
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
        var deleted = await _cocineroService.DeleteById(id); 
        return deleted;
    }

    [HttpGet]
    [Route("{idCocinero}/Comandas")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "cocinero,gerente")]
    public async Task<List<ComandaCocineroDTO>?> GetComandasAsignadas(long idCocinero)
    {
        try
        {
            var comandas = await _cocineroService.GetComandasAsignadas(idCocinero);
            var comandasDto = new List<ComandaCocineroDTO>();

            comandas.ForEach(com =>
                comandasDto.Add(_mapper.Map<ComandaCocineroDTO>(com))
                );

            return comandasDto;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    [HttpGet]
    [Route("Comandas")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "cocinero,gerente")]
    public async Task<List<ComandaCocineroDTO>?> GetComandasCocina()
    {
        try
        {
            var comandas = await _cocineroService.GetComandasCocina();
            var comandaDTOs = new List<ComandaCocineroDTO>();
            comandas.ForEach(ped =>
                comandaDTOs.Add(_mapper.Map<ComandaCocineroDTO>(ped))
            );
            return comandaDTOs;
        }
        catch (Exception)
        {

            return null;
        }
    }

    [HttpPut]
    [Route("Comanda/{idComanda}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "cocinero,gerente")]
    public async Task<IActionResult> SetComandaPreparada(long idComanda)
    {
        var comanda = await _comandaService.FindById(idComanda);
        if (comanda == null)
        {
            return BadRequest("No existe esa comanda");
        }
        else
        {
            comanda.Estado = (EstadosComanda)2;
            await _comandaService.Update(comanda);
            return Ok("Comanda Preparada");
        }
    }
}