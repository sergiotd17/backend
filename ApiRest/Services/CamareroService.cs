using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class CamareroService
{
    private readonly CamareroRepository _camareroRepository;
    private readonly ComandaRepository _comandaRepository;

    public CamareroService(CamareroRepository camareroRepository,ComandaRepository comanda)
    {
        _camareroRepository = camareroRepository;
        _comandaRepository = comanda;
    }

    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await _camareroRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
       
          
    }

    public async Task<IList<Camarero>> FindAll()
    {
        return await _camareroRepository.GetAll();
    }

    public async Task<Camarero?> FindById(long id)
    {
        return await _camareroRepository.GetById(id);
    }

    public async Task<Camarero> Save(Camarero camarero)
    {
        Camarero camareroUp = await _camareroRepository.Add(camarero);
        return camareroUp;
    }

    public async Task<Camarero> Update(Camarero camarero)
    {
        Camarero camareroUp = await _camareroRepository.Update(camarero);
        return camareroUp;
    }

    public async Task<List<Comanda>> GetComandasActivas(long id)
    {
        var comandas = await _comandaRepository.GetComandasCamarero(id);

        return comandas;
    }

    public async Task<List<Comanda>> GetBebidas(long id)
    {
        var comandas = await _comandaRepository.GetBebidasCamarero(id);
        return comandas;
    }
}