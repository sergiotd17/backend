using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class ComandaService
{
    private readonly ComandaRepository _comandaRepository;
    private readonly CocineroRepository _cocineroRepository;

    public ComandaService(ComandaRepository comandaRepository,CocineroRepository cocineroRepository)
    {
        _comandaRepository = comandaRepository;
        _cocineroRepository = cocineroRepository;
    }
    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await _comandaRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Comanda>> FindAll()
    {
        return await _comandaRepository.GetAll();
    }

    public async Task<Comanda?> FindById(long id)
    {
        return await _comandaRepository.GetById(id);
    }

    public async Task<Comanda> Save(Comanda comanda)
    {
        var comandaUp = await _comandaRepository.Add(comanda);
        return comandaUp;
    }

    public async Task<Comanda> Update(Comanda comanda)
    {
        var comandaUp = await _comandaRepository.Update(comanda);
        return comandaUp;
    }

    public async Task<Comanda> AsignCocinero(long idComanda, long idCocinero)
    {
        var comanda = await _comandaRepository.GetById(idComanda);
        if (comanda == null)
        {
            //Nada
        }
        else
        {
            comanda.IdCocinero = idCocinero;
            comanda.Estado = (EstadosComanda)1;
        }
        
        return await _comandaRepository.Update(comanda);
    }
}