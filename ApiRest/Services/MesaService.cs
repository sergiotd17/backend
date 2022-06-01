using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class MesaService
{
    private readonly MesaRepository _mesaRepository;

    public MesaService(MesaRepository mesaRepository)
    {
        _mesaRepository = mesaRepository;
    }
    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await _mesaRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Mesa>> FindAll()
    {
        return await _mesaRepository.GetAll();
    }

    public async Task<Mesa?> FindById(long id)
    {
        return await _mesaRepository.GetById(id);
    }

    public async Task<Mesa> Save(Mesa mesa)
    {
        var mesaUp = await _mesaRepository.Add(mesa);
        return mesaUp;
    }

    public async Task<Mesa> Update(Mesa mesa)
    {
        var mesaUp = await _mesaRepository.Update(mesa);
        return mesaUp;
    }
}