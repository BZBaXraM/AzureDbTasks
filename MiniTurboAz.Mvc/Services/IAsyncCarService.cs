using MiniTurboAz.Mvc.Models;

namespace MiniTurboAz.Mvc.Services;

public interface IAsyncCarService
{
    Task<List<CarViewModel>> GetCarsAsync();
}