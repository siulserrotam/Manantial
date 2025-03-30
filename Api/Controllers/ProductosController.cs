using API.Controllers;
using API.Errors;
using Application.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductosController : ControladorBaseApi
    {
        private readonly IRepositorioProducto _productoRepo;
        private readonly IRepositorioGenerico<Categoria> _categoriaRepo;
        private readonly IRepositorioGenerico<Marca> _marcaRepo;
        private readonly IMapper _mapper;

        public ProductosController(
            IRepositorioProducto productoRepo, 
            IRepositorioGenerico<Categoria> categoriaRepo, 
            IRepositorioGenerico<Marca> marcaRepo,
            IMapper mapper)
        {
            _productoRepo = productoRepo;
            _categoriaRepo = categoriaRepo;
            _marcaRepo = marcaRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DtoProducto>>> ObtenerProductos()
        {
            var spec = new EspecificacionProductosConCategoriaYMarca();
            var productos = await _productoRepo.ListarPorEspecificacionAsync(spec);

            if (productos == null || !productos.Any())
            {
                return NotFound("No contiene productos.");
            }

            return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<DtoProducto>>(productos));
        }
        

        [HttpGet("{id}")]
      //  [ProducesResponseType(typeof(DtoProducto), 200)]
       // [ProducesResponseType(typeof(RespuestaApi), 404)]
        public async Task<ActionResult<DtoProducto>> ObtenerProducto(int id)
        {
            var spec = new EspecificacionProductosConCategoriaYMarca(id);
            var producto = await _productoRepo.ObtenerProductoConEspecificacionAsync(spec);

            if (producto == null)
            {
                return NotFound(new RespuestaApi(404));
            }

            return Ok(_mapper.Map<Producto, DtoProducto>(producto));
        }

        [HttpGet("Categorias")]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> ObtenerCategorias()
        {
            var categorias = await _categoriaRepo.ObtenerTodosAsync();

            if (categorias == null || !categorias.Any())
            {
                return NotFound("No contiene categorias.");
            }

            return Ok(categorias);
        }

        [HttpGet("Marcas")]
        public async Task<ActionResult<IReadOnlyList<Marca>>> ObtenerMarcas()
        {
            var marcas = await _marcaRepo.ObtenerTodosAsync();

            if (marcas == null || !marcas.Any())
            {
                return NotFound("No contiene marcas.");
            }

            return Ok(marcas);
        }
    }
}
