using ApiRest.Context;
using ApiRest.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace ApiRest.Repository;

public class UsuarioRepository : MasterRepoImpl<Usuario,MyDbContext>

{
    private MyDbContext _context;
    public UsuarioRepository(MyDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetUsuarioByUsername(String username)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(predicate: x => x.Username.Equals(username));
    }
}