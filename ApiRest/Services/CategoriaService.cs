using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class CategoriaService
{
    private readonly CategoriaRepository _categoriaRepository;

    public CategoriaService(CategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }
    
    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await _categoriaRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
       
          
    }

    public async Task<IList<Categoria>> FindAll()
    {
        return await _categoriaRepository.GetAll();
    }

    public async Task<Categoria?> FindById(long id)
    {
        return await _categoriaRepository.GetById(id);
    }

    public async Task<Categoria> Save(Categoria categoria)
    {
        var categoriaUp = await _categoriaRepository.Add(categoria);
        return categoriaUp;
    }

    public async Task<Categoria> Update(Categoria categoria)
    {
        Categoria categoriaUp = await _categoriaRepository.Update(categoria);
        return categoriaUp;
    }
}