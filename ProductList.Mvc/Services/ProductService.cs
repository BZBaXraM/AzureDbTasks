using Microsoft.EntityFrameworkCore;
using ProductList.Mvc.Data;
using ProductList.Mvc.Models;

namespace ProductList.Mvc.Services;

public class ProductService : IAsyncProductService
{
    private readonly ProductContext _context;

    public ProductService(ProductContext context)
        => _context = context;


    public async Task<List<ProductCategory>> GetAllProductCategoriesAsync()
    {
        return await _context.ProductCategories.ToListAsync();
    }
}