using ApiRest.Context;
using ApiRest.Entities;

namespace ApiRest.Repository;

public class MesaRepository : MasterRepoImpl<Mesa,MyDbContext>
{
    public MesaRepository(MyDbContext context) : base(context)
    {
    }
}