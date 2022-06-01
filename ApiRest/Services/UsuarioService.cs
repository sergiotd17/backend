using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class UsuarioService
{
    UsuarioRepository UserRepository;

    public UsuarioService(UsuarioRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public async Task<bool> DeleteById(long id)
    {
        try
        {
            await UserRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Usuario>> FindAll()
    {
        return await UserRepository.GetAll();
    }

    public async Task<Usuario?> FindById(long id)
    {
        return await UserRepository.GetById(id);
    }

    public async Task<Usuario> Save(Usuario usuario)
    {
        Usuario usuarioUp = await UserRepository.Add(usuario);
        return usuarioUp;
    }

    public async Task<Usuario> Update(Usuario usuario)
    {
        var usuarioUp = await UserRepository.Update(usuario);
        return usuarioUp;
    }

    public async Task<Usuario?> GetUserByUsername(String username)
    {
        return await UserRepository.GetUsuarioByUsername(username);
    }
}