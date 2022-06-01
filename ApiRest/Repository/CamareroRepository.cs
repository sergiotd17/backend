using ApiRest.Context;
using ApiRest.Entities;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace ApiRest.Repository;

public class CamareroRepository : MasterRepoImpl<Camarero,MyDbContext>

{
    public CamareroRepository(MyDbContext context) : base(context)
    {
        
    }    
}