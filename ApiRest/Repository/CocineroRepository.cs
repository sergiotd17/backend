using ApiRest.Context;
using ApiRest.Entities;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace ApiRest.Repository;

public class CocineroRepository : MasterRepoImpl<Cocinero,MyDbContext>

{
    public CocineroRepository(MyDbContext context) : base(context)
    {
    }    
}