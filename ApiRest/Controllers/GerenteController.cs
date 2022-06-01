using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

[Route("Gerente")]
[ApiController]
public class GerenteController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly GerenteService _gerenteService;
    private readonly IMapper _mapper;
            
    public GerenteController(GerenteService gerenteService, IMapper mapper) 
    { 
        _gerenteService = gerenteService; 
        _mapper = mapper;
    }
            
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IList<GerenteDTO>> GetAll() 
    {
        var gerentes = await _gerenteService.FindAll();
        return gerentes.Select(g => _mapper.Map<GerenteDTO>(g)).ToList();
    }
    
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<GerenteDTO?> Get(long id)
    {
        var gerente = await _gerenteService.FindById(id); 
        return gerente is null ? null : _mapper.Map<GerenteDTO>(gerente);
    }
    
    [HttpPost]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Create(GerenteDTO gerenteDto) 
    {
        try
        {
            var newpass = BCrypt.Net.BCrypt.HashPassword(gerenteDto.Password);
            gerenteDto.Password = newpass;
            
            var gerente = _mapper.Map<Gerente>(gerenteDto); 
            await _gerenteService.Save(gerente);
            return Ok("Gerente creado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult?> Update(long id, GerenteDTO gerenteDto)
    {
        try
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto); 
            if (id != gerente.Id) 
            { 
                return null;
            } 
            await _gerenteService.Update(gerente);
            return Ok("Gerente creado");
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
        var deleted = await _gerenteService.DeleteById(id); 
        return deleted;
    }
}