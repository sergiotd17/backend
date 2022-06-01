using ApiRest.Context;
using ApiRest.Entities;

namespace ApiRest.Repository;

public class ProductoRepository : MasterRepoImpl<Producto,MyDbContext>
{
    public ProductoRepository(MyDbContext context) : base(context)
    {
    }
}