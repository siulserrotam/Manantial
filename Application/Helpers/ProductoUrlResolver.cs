using AutoMapper;
using Application.DTOs;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Helpers
{
    public class ProductoUrlResolver : IValueResolver<Producto, DtoProducto, string>
    {
        private readonly IConfiguration _config;

        public ProductoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Producto source, DtoProducto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.RutaImagen) ? _config["ApiUrl"] + source.RutaImagen : string.Empty;
        }
    }
}