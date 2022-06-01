using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class ReservaService
{
    private readonly ReservaRepository _repository;

    public ReservaService(ReservaRepository reservaRepository)
    {
        _repository = reservaRepository;
    }
    
    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await _repository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Reserva>> FindAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Reserva?> FindById(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Reserva> Save(Reserva reserva)
    {
        var reservaUp = await _repository.Add(reserva);
        return reservaUp;
    }

    public async Task<Reserva> Update(Reserva reserva)
    {
        var reservaUp = await _repository.Update(reserva);
        return reservaUp;
    }
}