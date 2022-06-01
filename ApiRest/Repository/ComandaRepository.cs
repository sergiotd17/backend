using ApiRest.Context;
using ApiRest.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Repository;

public class ComandaRepository : MasterRepoImpl<Comanda, MyDbContext>
{   
    private readonly MyDbContext _context;
    public ComandaRepository(MyDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Comanda>> GetComandasCamarero(long idCamarero)
    {
        var comandas = await _context.Comanda
            .Where(p => p.IdCamarero == idCamarero)
            .Where(e => (int) e.Estado != 3)
            .ToListAsync<Comanda>();

        return comandas;
    }

    public async Task<List<Comanda>> GetBebidasCamarero(long idCamarero)
    {
        var comandas = await _context.Comanda
           .Where(p => p.IdCamarero == idCamarero)
           .Where(e => (int)e.Estado != 3)
           .Where(c => c.IdProductoNavigation.IdCat == 1)
           .ToListAsync<Comanda>();

        return comandas;
    }

    public async Task<List<Comanda>> GetComandasAsignadasCocinero(long idCocinero)
    {
        var comandas = await _context.Comanda
            .Where(predicate: p => p.IdCocinero == idCocinero)
            .Where(predicate: e => (int)e.Estado == 1)
            .ToListAsync();
        return comandas;
    }

    public async Task<List<Comanda>> GetComandasCocina()
    {
        var comandas = await _context.Comanda
            .Where(predicate: p => p.IdProductoNavigation.IdCat != 1)
            .Where(predicate: e => e.Estado == 0)
            .ToListAsync();

        return comandas;
    }

}