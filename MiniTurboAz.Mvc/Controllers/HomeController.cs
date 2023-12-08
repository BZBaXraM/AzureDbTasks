using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiniTurboAz.Mvc.Data;
using MiniTurboAz.Mvc.Models;
using MiniTurboAz.Mvc.Services;

namespace MiniTurboAz.Mvc.Controllers;

public class HomeController : Controller
{
  private readonly IAsyncCarService _carService;
  
    public HomeController(CarContext context)
    {
        _carService = new CarService(context);
    }

    public async Task<IActionResult> Index()
    {
        var cars = await _carService.GetCarsAsync();
        
        return View(cars);
    }
    
    public async Task<IActionResult> Details(Guid id)
    {
        var cars = await _carService.GetCarsAsync();
        var car = cars.FirstOrDefault(c => c.Id == id);
        
        return View(car);
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