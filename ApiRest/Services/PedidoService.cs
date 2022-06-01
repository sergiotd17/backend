using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class PedidoService
{
    private readonly PedidoRepository _pedidoRepository;

    public PedidoService(PedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }
    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await _pedidoRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Pedido>> FindAll()
    {
        return await _pedidoRepository.GetAll();
    }

    public async Task<Pedido?> FindById(long id)
    {
        return await _pedidoRepository.GetById(id);
    }

    public async Task<Pedido> Save(Pedido pedido)
    {
        var pedidoUp = await _pedidoRepository.Add(pedido);
        return pedidoUp;
    }

    public async Task<Pedido> Update(Pedido pedido)
    {
        var pedidoUp = await _pedidoRepository.Update(pedido);
        return pedidoUp;
    }

    public async Task<Pedido> GetPedidoByMesaAsync(long id)
    {
        return await _pedidoRepository.GetPedidoByMesaAsync(id);
    }

    public async Task<List<Pedido>> GetPedidoCamarero(long id)
    {
        return await _pedidoRepository.GetPedidoCamarero(id);
    }
}