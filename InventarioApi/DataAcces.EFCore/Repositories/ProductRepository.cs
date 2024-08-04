using DataAcces.EFCore;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly InventarioContext _context;
        public ProductRepository(InventarioContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.ProductState)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByFilterAsync(int productStateId)
        {
            return await _context.Products
                .Where(p => p.ProductStateId == productStateId)
                .Include(p => p.ProductState)
                .ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _context.Products
                .Include(p => p.ProductState)
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }


        public async  Task CreateProductAsync(List<Product> products, int productStateId)
        {
            var existingState = await _context.ProductStates.FindAsync(productStateId);
            if (existingState == null)
            {
                throw new ArgumentException("El estado del prducto no existe.");
            }

            foreach (var product in products)
            {
                product.ProductState = existingState;
            }

            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();
        }



        public async Task UpdateProductStateIdAsync(int productId, int newProductStateId)
        {
            var productToUpdate = await _context.Products.FindAsync(productId);

            if (productToUpdate == null)
            {
                throw new ArgumentException("Producto no encontrado.");
            }

            var newState = await _context.ProductStates.FindAsync(newProductStateId);

            if (newState == null)
            {
                throw new ArgumentException("Estado del producto no válido.");
            }

            productToUpdate.ProductStateId = newProductStateId;
            await _context.SaveChangesAsync();
        }
    }
}
