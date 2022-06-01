using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class CocineroService
{
    private readonly CocineroRepository _cocineroRepository;
    private readonly ComandaRepository _comandaRepository;

    public CocineroService(CocineroRepository cocineroRepository, ComandaRepository comandaRepository)
    {
        _cocineroRepository = cocineroRepository;
        _comandaRepository = comandaRepository;
    }

    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await _cocineroRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Cocinero>> FindAll()
    {
        return await _cocineroRepository.GetAll();
    }

    public async Task<Cocinero?> FindById(long id)
    {
        return await _cocineroRepository.GetById(id);
    }

    public async Task<Cocinero> Save(Cocinero cocinero)
    {
        return await _cocineroRepository.Add(cocinero);
    }

    public async Task<Cocinero> Update(Cocinero cocinero)
    {
        return await _cocineroRepository.Update(cocinero);
    }

    public async Task<List<Comanda>> GetComandasAsignadas(long id)
    {
        var comandas = await _comandaRepository.GetComandasAsignadasCocinero(id);

        return comandas;
    }

    public async Task<List<Comanda>> GetComandasCocina()
    {
        var comandas = await _comandaRepository.GetComandasCocina();
        return comandas;
    }
}