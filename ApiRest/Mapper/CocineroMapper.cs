using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class CocineroMapper : Profile
{
    public CocineroMapper()
    {
        CreateMap<CocineroDTO, Cocinero>();
        CreateMap<Cocinero, CocineroDTO>();
        CreateMap<CocineroCreationDTO, Cocinero>();
        CreateMap<Cocinero, CocineroCreationDTO>();
    }
    
}