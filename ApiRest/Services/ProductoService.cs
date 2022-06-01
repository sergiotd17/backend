using ApiRest.Entities;
using ApiRest.Repository;
using AutoMapper;

namespace ApiRest.Service;

public class ProductoService
{
    private readonly ProductoRepository _productoRepository;

    public ProductoService(ProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }
    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await _productoRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Producto>> FindAll()
    {
        return await _productoRepository.GetAll();
    }

    public async Task<Producto?> FindById(long id)
    {
        return await _productoRepository.GetById(id);
    }

    public async Task<Producto> Save(Producto producto)
    {
        var productoUp = await _productoRepository.Add(producto);
        return productoUp;
    }

    public async Task<Producto> Update(Producto producto)
    {
        var productoUp = await _productoRepository.Update(producto);
        return productoUp;
    }
}