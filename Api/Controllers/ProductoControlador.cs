using API.Controllers;
using API.Errors;
using Application.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{

    public class ProductsController : ControladorBaseApi
    {
        private readonly IRepositorioProducto _productoRepo;
        private readonly IRepositorioGenerico<Categoria> _productoCategoriaRepo;
        private readonly IRepositorioGenerico<Marca> _productoMarcaRepo;
        private readonly IMapper _mapper;

        // Constructor con la inyección de dependencias
        public ProductsController(
            IRepositorioProducto productoRepo, 
            IRepositorioGenerico<Categoria> productoCategoriaRepo, 
            IRepositorioGenerico<Marca> productoMarcaRepo,
            IMapper mapper)
        {
            _productoRepo = productoRepo;  // Asignamos las dependencias a las variables de instancia
            _productoCategoriaRepo = productoCategoriaRepo;
            _productoMarcaRepo = productoMarcaRepo;
            _mapper = mapper;
        }

        // Método para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DtoProducto>>> ObtenerProductos()
        {
            var spec = new EspecificacionProductosConCategoriaYMarca();  // Definimos la especificación para obtener los productos

            var productos = await _productoRepo.ListarPorEspecificacionAsync(spec);  // Usamos el repositorio para obtener los productos con la especificación

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
        public async Task<ActionResult<DtoProducto>> GetProduct(int id)
        {
            var spec = new EspecificacionProductosConCategoriaYMarca(id);  // Creamos una especificación que use el id del producto

            var producto = await _productoRepo.ObtenerProductoConEspecificacionAsync(spec);  // Obtenemos el producto con esa especificación

            // Si no se encuentra el producto, retornamos un 404 NotFound
            if (producto == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            // Si no hay productos, se retorna un 404 NotFound
            if (producto == null) return NotFound(new RespuestaApi(404));
           
            
        
            // Se mapea el producto a un DTO y se devuelve
            return Ok(_mapper.Map<Producto, DtoProducto>(producto));
        }

        // Método para obtener todas las marcas de productos
        [HttpGet("Categorias")]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> ObtenerCategorias()
        {
            var productoCategoria = await _productoCategoriaRepo.ObtenerTodosAsync();  // Obtenemos todas las categorias de productos

            // Si no hay marcas, retornar un 404 NotFound
            if (productoCategoria == null || !productoCategoria.Any())
            {
                return NotFound("No product brands found.");
            }

            return Ok(productoCategoria);
        }

        // Método para obtener todos los tipos de productos
        [HttpGet("Marcas")]
        public async Task<ActionResult<IReadOnlyList<Marca>>> ObtenerMarcas()
        {
            var productoMarca = await _productoMarcaRepo.ObtenerTodosAsync();  // Obtenemos todos los marcas de productos

            // Si no hay tipos, retornar un 404 NotFound
            if (productoMarca == null || !productoMarca.Any())
            {
                return NotFound("No product types found.");
            }

            return Ok(productoMarca);
        }
    }
}