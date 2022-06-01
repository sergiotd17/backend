using ApiRest.Context;
using ApiRest.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Repository;

public class PedidoRepository : MasterRepoImpl<Pedido,MyDbContext>
{
    private MyDbContext _db;
    public PedidoRepository(MyDbContext context) : base(context)
    {
        _db = context;
    }

    public async Task<Pedido> GetPedidoByMesaAsync(long id)
    {
        return await _db.Pedidos
            .Where(predicate: p => p.IdMesa == id)
            .Where(predicate: e => e.Estado == 0)
            .FirstOrDefaultAsync();             
    }

    public async Task<List<Pedido>> GetPedidoCamarero(long id)
    {
        return await _db.Pedidos
            .Where(predicate: p => p.IdCamarero == id)
            .Where(predicate: e => e.Estado == 0)
            .ToListAsync();
    }
}