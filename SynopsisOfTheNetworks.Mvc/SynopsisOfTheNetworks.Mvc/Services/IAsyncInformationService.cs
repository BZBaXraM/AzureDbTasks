using SynopsisOfTheNetworks.Mvc.Models;

namespace SynopsisOfTheNetworks.Mvc.Services;

public interface IAsyncInformationService
{
    Task<IEnumerable<InfoViewModel>> GetAsync();
    Task<InfoViewModel?> GetAsync(Guid id);
}