using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class MesaMapper : Profile
{
    public MesaMapper()
    {
        CreateMap<MesaDTO, Mesa>();
        CreateMap<Mesa, MesaDTO>();
        CreateMap<MesaCreationDTO, Mesa>();
        CreateMap<Mesa,MesaCreationDTO>();
    }
}