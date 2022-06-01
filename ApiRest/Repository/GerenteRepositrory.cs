using ApiRest.Context;
using ApiRest.Entities;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace ApiRest.Repository;

public class GerenteRepository : MasterRepoImpl<Gerente,MyDbContext>

{
    public GerenteRepository(MyDbContext context) : base(context)
    {
        
    }    
}