using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class ReservaMapper : Profile
{
    public ReservaMapper()
    {
        CreateMap<ReservaDTO, Reserva>();
        CreateMap<Reserva,ReservaDTO>();
        CreateMap<ReservaCreationDTO, Reserva>();
        CreateMap<Reserva, ReservaCreationDTO>();
    }
}