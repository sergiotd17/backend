using ApiRest.Context;
using ApiRest.Entities;

namespace ApiRest.Repository;

public class CategoriaRepository : MasterRepoImpl<Categoria,MyDbContext>
{
    public CategoriaRepository(MyDbContext context) : base(context)
    {
    }
}