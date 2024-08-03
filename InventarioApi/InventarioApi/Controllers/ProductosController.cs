using Domain.Entidades;
using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventarioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productoRepository)
        {
            _productRepository = productoRepository;
        }

        [HttpGet(Name = "Product")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products); // Devuelve los productos como respuesta HTTP 200 OK
        }

        [HttpGet("Filtro/{productStateId}")]
        public async Task<IActionResult> GetByFilterProducts(int productStateId)
        {
            var products = await _productRepository.GetByFilterAsync(productStateId);
            if (products == null)
            {
                return NotFound(); // Producto no encontrado
            }

            return Ok(products); // Producto encontrado
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProducts(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(); // Producto no encontrado
            }

            return Ok(product); // Producto encontrado
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> CreateProducts([FromBody] List<Product> products, int productStateId)
        {
            if (products == null || !products.Any())
            {
                return BadRequest("La lista de productos está vacía.");
            }
             
            foreach (var product in products)
            {
                productStateId = product.ProductStateId;
            }

            // Llama al método Agregar del repositorio
            await _productRepository.CreateProductAsync(products, productStateId);

            return Ok("Productos agregados correctamente.");
        }

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
