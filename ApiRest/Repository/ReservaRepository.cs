using ApiRest.Context;
using ApiRest.Entities;

namespace ApiRest.Repository;

public class ReservaRepository : MasterRepoImpl<Reserva,MyDbContext>
{
    public ReservaRepository(MyDbContext context) : base(context)
    {
    }
}