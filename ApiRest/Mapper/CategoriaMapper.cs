using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class CategoriaMapper : Profile
{
    public CategoriaMapper()
    {
        CreateMap<Categoria, CategoriaDTO>();
        CreateMap<CategoriaDTO, Categoria>();
        CreateMap<Categoria, CategoriaCreationDTO>();
        CreateMap<CategoriaCreationDTO, CategoriaCreationDTO>();
    }
}