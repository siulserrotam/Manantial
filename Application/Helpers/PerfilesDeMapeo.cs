using AutoMapper;
using Manantial.Application.DTOs;
using Manantial.Core.Entities;

namespace Manantial.Application.Helpers
{
    public class PerfilesDeMapeo : Profile
    {
        public PerfilesDeMapeo()
        {
            // Mapeo de Producto a DtoProducto
            CreateMap<Producto, DtoProducto>()
                .ForMember(destino => destino.Fk_IdMarca, opt => opt.MapFrom(origen => origen.Fk_IdMarca))
                .ForMember(destino => destino.Fk_IdCategoria, opt => opt.MapFrom(origen => origen.Fk_IdCategoria))
                .ForMember(destino => destino.RutaImagen, opt => opt.MapFrom(origen => origen.RutaImagen))
                .ForMember(destino => destino.NombreImagen, opt => opt.MapFrom(origen => origen.NombreImagen));

            // Si en el futuro se necesita mapear DTO a Entidad
            CreateMap<DtoProducto, Producto>()
                .ForMember(destino => destino.Fk_IdMarca, opt => opt.MapFrom(origen => origen.Fk_IdMarca))
                .ForMember(destino => destino.Fk_IdCategoria, opt => opt.MapFrom(origen => origen.Fk_IdCategoria));
            
            CreateMap<Cliente, DtoCliente>();
            CreateMap<Venta, DtoVenta>();
        }
    }
}
