using ApiRest.DTO;
using ApiRest.Entities;
using AutoMapper;

namespace ApiRest.Mapper;

public class ProductoMapper : Profile
{
    public ProductoMapper()
    {
        CreateMap<ProductoDTO, Producto>();
        CreateMap<Producto, ProductoDTO>();
        CreateMap<ProductoCreationDTO, Producto>();
        CreateMap<Producto, ProductoCreationDTO>();
        CreateMap<ProductoInCategoriaDTO,Producto>();
        CreateMap<Producto, ProductoInCategoriaDTO>();
        CreateMap<ProductoInComandaCamareroDTO, Producto>();
        CreateMap<Producto, ProductoInComandaCamareroDTO>();
        CreateMap<ProductoInComandaCocinero,Producto>();
        CreateMap<Producto, ProductoInComandaCocinero>();
    }
}