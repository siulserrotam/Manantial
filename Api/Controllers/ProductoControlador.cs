using API.Controllers;
using API.Errors;
using AutoMapper;
using Manantial.Application.DTOs;
using Manantial.Core.Entities;
using Manantial.Core.Interfaces;
using Manantial.Core.Specifications;
using Microsoft.AspNetCore.Mvc;  // Importa clases necesarias para crear controladores de la API en ASP.NET

namespace API.Controller
{

    public class ProductoControlador : ControladorBaseApi
    {
        private readonly IRepositorioProducto _RepoProducto;
        private readonly IRepositorioGenerico<Categoria> _RepoCategoria;
        private readonly IRepositorioGenerico<Marca> _RepoMarca;
        private readonly IMapper _mapper;

        // Constructor con la inyección de dependencias
        public ProductoControlador(
            IRepositorioProducto RepoProducto, 
            IRepositorioGenerico<Categoria> RepoCategoria, 
            IRepositorioGenerico<Marca> RepoMarca,
            IMapper mapper)
        {
            _RepoProducto = RepoProducto;  // Asignamos las dependencias a las variables de instancia
            _RepoCategoria = RepoCategoria;
            _RepoMarca = RepoMarca;
            _mapper = mapper;
        }

        // Método para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DtoProducto>>> ObtenerProductos()
        {
            var spec = new EspecificacionProductosConCategoriaYMarca();  // Definimos la especificación para obtener los productos

            var productos = await _RepoProducto.ListarPorEspecificacionAsync(spec);  // Usamos el repositorio para obtener los productos con la especificación

            // Si no hay productos, se retorna un 404 NotFound
            if (productos == null || !productos.Any())
            {
                return NotFound("No products found.");
            }

            // Se mapea la lista de productos a una lista de DTOs y se devuelve
            return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<DtoProducto>>(productos));
        }

        // Método para obtener un producto por su id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DtoProducto), 200)]
        [ProducesResponseType(typeof(RespuestaApi), 404)]
        public async Task<ActionResult<DtoProducto>> ObtenerPoducto(int id)
        {
            var spec = new EspecificacionProductosConCategoriaYMarca(id);  // Creamos una especificación que use el id del producto

            var producto = await _RepoProducto.(spec);  // Obtenemos el producto con esa especificación

            // Si no se encuentra el producto, retornamos un 404 NotFound
            if (producto == null)
            {
                return NotFound($"Producto con Id {id} no funciona.");
            }

            // Si no hay productos, se retorna un 404 NotFound
            if (producto == null) return NotFound(new RespuestaApi(404));
           
            
        
            // Se mapea el producto a un DTO y se devuelve
            return Ok(_mapper.Map<Producto, DtoProducto>(producto));
        }

        // Método para obtener todas las marcas de productos
        [HttpGet("Categorias")]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> ObtenerProductosPorCategoria()
        {
            var RepoCategoria = await _RepoCategoria.ListarPorEspecificacionAsync();  // Obtenemos todas las marcas de productos

            // Si no hay marcas, retornar un 404 NotFound
            if (RepoCategoria == null || !RepoCategoria.Any())
            {
                return NotFound("No product brands found.");
            }

            return Ok(RepoCategoria);
        }

        // Método para obtener todos los tipos de productos
        [HttpGet("Marcas")]
        public async Task<ActionResult<IReadOnlyList<Marca>>> GetProductTypes()
        {
            var RepoMarca = await _RepoMarca.ListAllAsync();  // Obtenemos todos los tipos de productos

            // Si no hay tipos, retornar un 404 NotFound
            if (RepoMarca == null || !RepoMarca.Any())
            {
                return NotFound("No product types found.");
            }

            return Ok(RepoMarca);
        }
    }
}