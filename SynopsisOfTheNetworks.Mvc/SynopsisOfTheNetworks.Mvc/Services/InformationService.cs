using Microsoft.EntityFrameworkCore;
using SynopsisOfTheNetworks.Mvc.Entities;
using SynopsisOfTheNetworks.Mvc.Models;

namespace SynopsisOfTheNetworks.Mvc.Services;

public class InformationService : IAsyncInformationService
{
    private readonly InfoContext _context;

    public InformationService(InfoContext context)
        => _context = context;

    public async Task<IEnumerable<InfoViewModel>> GetAsync()
        => await _context.Infos.ToListAsync();

    public async Task<InfoViewModel?> GetAsync(Guid id)
    {
        var info = await _context.Infos.FindAsync(id);
        return info ?? null;
    }
}