using Microsoft.EntityFrameworkCore;
using MiniTurboAz.Mvc.Data;
using MiniTurboAz.Mvc.Models;

namespace MiniTurboAz.Mvc.Services;

public class CarService : IAsyncCarService
{
    private readonly CarContext _context;

    public CarService(CarContext context)
    {
        _context = context;
    }

    public async Task<List<CarViewModel>> GetCarsAsync()
    {
        var cars = await _context.Cars.ToListAsync();
        return cars.Select(car => new CarViewModel
        {
            Id = car.Id,
            Name = car.Name,
            ImageUrl = car.ImageUrl,
            Description = car.Description
        }).ToList();
    }
}