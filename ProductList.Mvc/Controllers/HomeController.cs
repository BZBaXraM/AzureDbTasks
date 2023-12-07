using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductList.Mvc.Data;
using ProductList.Mvc.Models;
using ProductList.Mvc.Services;

namespace ProductList.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly IAsyncProductService _productService;

    public HomeController(ProductContext context)
    {
        _productService = new ProductService(context);
    }

    public async Task<IActionResult> Index()
    {
        var productCategories = await _productService.GetAllProductCategoriesAsync();
        return View(productCategories);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}