using Domain.Entidades;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetByFilterAsync(int productStateId);//filtra la tabla por el estado del producto
        Task<Product> GetByIdAsync(int productId);
        Task CreateProductAsync(List<Product> products, int productStateId);
        Task UpdateProductStateIdAsync(int productId, int newProductStateId);
    }

}
