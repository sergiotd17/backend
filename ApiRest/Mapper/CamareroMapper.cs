using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class CamareroMapper : Profile
{
    public CamareroMapper()
    {
        CreateMap<CamareroDTO, Camarero>();
        CreateMap<Camarero, CamareroDTO>();
        CreateMap<CamareroCreationDTO, Camarero>();
        CreateMap<Camarero, CamareroCreationDTO>();
    }
    
}