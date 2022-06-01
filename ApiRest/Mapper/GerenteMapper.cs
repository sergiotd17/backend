using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class GerenteMapper : Profile
{
    public GerenteMapper()
    {
        CreateMap<GerenteDTO, Gerente>();
        CreateMap<Gerente, GerenteDTO>();
        CreateMap<GerenteCreationDTO, Gerente>();
        CreateMap<Gerente, GerenteCreationDTO>();
    }
}