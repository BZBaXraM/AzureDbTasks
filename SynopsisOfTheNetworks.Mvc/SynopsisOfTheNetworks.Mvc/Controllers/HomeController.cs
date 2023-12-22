using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SynopsisOfTheNetworks.Mvc.Models;
using SynopsisOfTheNetworks.Mvc.Services;

namespace SynopsisOfTheNetworks.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly IAsyncInformationService _service;

    public HomeController(IAsyncInformationService service)
        => _service = service;

    public async Task<IActionResult> Index()
    {
        return View(await _service.GetAsync());
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var info = await _service.GetAsync(id);
        if (info == null)
        {
            return NotFound();
        }

        return View(info);
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