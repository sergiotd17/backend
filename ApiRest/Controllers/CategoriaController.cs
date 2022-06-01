using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

[Route("categoria")]
[ApiController]
public class CategoriaController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly CategoriaService _categoriaService;
    private readonly IMapper _mapper;

    public CategoriaController(CategoriaService categoriaService,IMapper imapper)
    {
        _categoriaService = categoriaService;
        _mapper = imapper;
    }
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero,cocinero")]
    public async Task<IList<CategoriaDTO>> GetAll() 
    {
        var categorias = await _categoriaService.FindAll();
        return categorias.Select(c => _mapper.Map<CategoriaDTO>(c)).ToList();
    }
    
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero,cocinero")]
    public async Task<CategoriaDTO?> Get(long id)
    {
        var categoria = await _categoriaService.FindById(id); 
        return categoria is null ? null : _mapper.Map<CategoriaDTO>(categoria);
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Create(CategoriaCreationDTO categoriaDto) 
    {
        try
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaService.Save(categoria);
            return Ok("Categoria creada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult?> Update(long id, CategoriaCreationDTO categoriaDto)
    {
        try
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto); 
            if (id != categoria.Id) 
            { 
                return null;
            }

            await _categoriaService.Update(categoria);
            return Ok("Categoria Actualizada");
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
        var deleted = await _categoriaService.DeleteById(id); 
        return deleted;
    }

}