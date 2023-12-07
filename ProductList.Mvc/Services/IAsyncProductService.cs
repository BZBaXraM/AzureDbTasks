using ProductList.Mvc.Models;

namespace ProductList.Mvc.Services;

public interface IAsyncProductService
{
    Task<List<ProductCategory>> GetAllProductCategoriesAsync();
}