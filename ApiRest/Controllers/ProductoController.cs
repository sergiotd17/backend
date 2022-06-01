using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

[Route("producto")]
[ApiController]
public class ProductoController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ProductoService _productoService;
    private readonly IMapper _mapper;

    public ProductoController(ProductoService productoService, IMapper mapper)
    {
        _mapper = mapper;
        _productoService = productoService;
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero,cocinero")]
    public async Task<IList<ProductoDTO>> GetAll() 
    {
        var productos = await _productoService.FindAll();

        return productos.Select(p => _mapper.Map<ProductoDTO>(p)).ToList();
    }
    
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente,camarero,cocinero")]
    public async Task<ProductoDTO?> Get(long id)
    {
        var producto = await _productoService.FindById(id); 
        return producto is null ? null : _mapper.Map<ProductoDTO>(producto);
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Create(ProductoCreationDTO productoDto) 
    {
        try
        {
            var producto = _mapper.Map<Producto>(productoDto);
            await _productoService.Save(producto);
            return Ok("Producto Creado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id:long}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult?> Update(long id, ProductoCreationDTO productoDto)
    {
        try
        {
            var producto = _mapper.Map<Producto>(productoDto); 
            if (id != producto.Id) 
            { 
                return null;
            }

            await _productoService.Update(producto);
            return Ok("Producto Actualizado");
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
        var deleted = await _productoService.DeleteById(id); 
        return deleted;
    }
}