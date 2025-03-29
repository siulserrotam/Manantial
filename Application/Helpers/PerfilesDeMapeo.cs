using AutoMapper;
using Application.DTOs;
using Core.Entities;

namespace Application.Helpers
{
    public class PerfilesDeMapeo : Profile
    {
        public PerfilesDeMapeo()
        {
            // Mapeo de Producto a DtoProducto
            CreateMap<Producto, DtoProducto>()
                .ForMember(destino => destino.DescripcionMarca, opt => opt.MapFrom(origen => origen.Marca.Descripcion))  // Ignoramos para evitar sobreescrituras
                .ForMember(destino => destino.DescripcionCategoria, opt => opt.MapFrom(origen => origen.Categoria.Descripcion))
                .ForMember(destino => destino.RutaImagen, opt => opt.MapFrom(origen => origen.RutaImagen))
                .ForMember(destino => destino.NombreImagen, opt => opt.MapFrom(origen => origen.NombreImagen));

            // Mapeo inverso si es necesario (de DTO a Entidad)
            CreateMap<DtoProducto, Producto>()
                .ForMember(destino => destino.Fk_IdMarca, opt => opt.Ignore())  // Ignoramos para evitar sobreescrituras
                .ForMember(destino => destino.Fk_IdCategoria, opt => opt.Ignore()); 

            // Mapeo de Cliente y Venta
            CreateMap<Cliente, DtoCliente>();
            CreateMap<Venta, DtoVenta>();
        }
    }
}