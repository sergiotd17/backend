using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class ComandaMapper : Profile
{
    public ComandaMapper()
    {
        CreateMap<ComandaDTO, Comanda>();
        CreateMap<Comanda, ComandaDTO>();
        CreateMap<ComandaCreationDTO, Comanda>();
        CreateMap<Comanda, ComandaCreationDTO>();
        CreateMap<ComandaInProductoDTO, Comanda>();
        CreateMap<Comanda, ComandaInProductoDTO>();
        CreateMap<ComandaCocineroDTO,Comanda>();
        CreateMap<ComandaInPedidoCamareroDTO, Comanda>();
        CreateMap<Comanda, ComandaInPedidoCamareroDTO>();
        CreateMap<ComandaCocineroDTO, Comanda>();
        CreateMap<Comanda, ComandaCocineroDTO>();
        CreateMap<ComandasCamarero, Comanda>();
        CreateMap<Comanda, ComandasCamarero>();
    }
}