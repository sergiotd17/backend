using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class PedidoMapper : Profile
{
    public PedidoMapper()
    {
        CreateMap<Pedido, PedidoDTO>();
        CreateMap<PedidoDTO, Pedido>();
        CreateMap<PedidoCreationDTO, Pedido>();
        CreateMap<Pedido, PedidoCreationDTO>();
        CreateMap<PedidoyMesaDTO, Pedido>();
        CreateMap<Pedido, PedidoyMesaDTO>();
    }
    
}