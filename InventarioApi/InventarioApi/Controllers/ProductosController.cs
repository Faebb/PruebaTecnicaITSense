using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventarioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]//Asegura que solo usuarios autenticados puedan acceder a este controlador
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        //Constructor: Inyecta la dependencia del repositorio de productos
        public ProductController(IProductRepository productoRepository)
        {
            _productRepository = productoRepository;
        }

        //Obtiene todos los productos
        [HttpGet(Name = "Product")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        //Filtra los productos por estado
        [HttpGet("Filtro/{productStateId}")]
        public async Task<IActionResult> GetByFilterProducts(int productStateId)
        {
            var products = await _productRepository.GetByFilterAsync(productStateId);
            if (products == null)
            {
                return NotFound();//Devuelve 404 si no se encuentran productos 
            }

            return Ok(products);
        }

        //Obtiene un producto por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProducts(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();//Devuelve 404 si no se encuentra el producto
            }

            return Ok(product);
        }
        
        //Agrega una lista de productos
        [HttpPost("Agregar")]
        public async Task<IActionResult> CreateProducts([FromBody] List<Product> products, int productStateId)
        {
            if (products == null || !products.Any())
            {
                return BadRequest("La lista de productos está vacía."); //Devuelve 400 si la lista está vacía
            }
             
            foreach (var product in products)
            {
                productStateId = product.ProductStateId;
            }

            await _productRepository.CreateProductAsync(products, productStateId);

            return Ok("Productos agregados correctamente.");
        }

        //Actualiza el estado de un producto
        [HttpPut("UpdateState/{productId}/{newStateId}")]
        public async Task<IActionResult> UpdateProductState(int productId, int newStateId)
        {
            try
            {
                await _productRepository.UpdateProductStateIdAsync(productId, newStateId);
                return Ok("Estado del producto actualizado correctamente.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
