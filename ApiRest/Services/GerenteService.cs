using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class GerenteService
{
    private readonly GerenteRepository _gerenteRepository;

    public GerenteService(GerenteRepository gerenteRepository)
    {
        _gerenteRepository = gerenteRepository;
    }

    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await _gerenteRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Gerente>> FindAll()
    {
        return await _gerenteRepository.GetAll();
    }

    public async Task<Gerente?> FindById(long id)
    {
        return await _gerenteRepository.GetById(id);
    }

    public async Task<Gerente> Save(Gerente gerente)
    {
        Gerente gerenteUp = await _gerenteRepository.Add(gerente);
        return gerenteUp;
    }

    public async Task<Gerente> Update(Gerente gerente)
    {
        Gerente gerenteUp = await _gerenteRepository.Update(gerente);
        return gerenteUp;
    }
}