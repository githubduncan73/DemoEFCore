using AutoMapper;
using DemoEFCore.DTOs;
using DemoEFCore.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Producto, ProductoDTO>().ReverseMap();
    }
}
