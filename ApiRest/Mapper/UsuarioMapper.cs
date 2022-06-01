using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class UsuarioMapper : Profile
{
    public UsuarioMapper()
    {
        CreateMap<UsuarioDTO, Usuario>();
        CreateMap<Usuario, UsuarioDTO>();
        CreateMap<UsuarioCreationDTO, Usuario>();
        CreateMap<Usuario, UsuarioCreationDTO>();
        CreateMap<Usuario, UsuarioLoginDTO>();
        CreateMap<UsuarioLoginDTO, Usuario>();
        CreateMap<UsuarioAfterLoginDTO, Usuario>();
        CreateMap<Usuario,UsuarioAfterLoginDTO>();
    }
}