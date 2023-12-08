using Microsoft.EntityFrameworkCore;
using MiniTurboAz.Mvc.Models;

namespace MiniTurboAz.Mvc.Data;

public class CarContext : DbContext
{
    public CarContext(DbContextOptions<CarContext> options) : base(options)
    {
    }

    public virtual DbSet<CarViewModel> Cars => Set<CarViewModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cars = new List<CarViewModel>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Mercedes-Benz",
                ImageUrl = "https://myturbo.blob.core.windows.net/cars/Mercedes-Benz-S-class-W223-2021-carhirebaku-1.jpeg",
                Description =
                    "Mercedes-Benz is both a German automotive marque and, from late 2019 onwards, a subsidiary – as Mercedes-Benz AG – of Daimler AG. Mercedes-Benz is known for producing luxury vehicles and commercial vehicles. The headquarters is in Stuttgart, Baden-Württemberg. The name first appeared in 1926 as Daimler-Benz."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Aston Martin",
                ImageUrl = "https://myturbo.blob.core.windows.net/cars/Aston_Martin_Vantage_V8.jpeg",
                Description =
                    "Aston Martin Lagonda Global Holdings plc is a British independent manufacturer of luxury sports cars and grand tourers. It was founded in 1913 by Lionel Martin and Robert Bamford. Steered from 1947 by David Brown, it became associated with expensive grand touring cars in the 1950s and 1960s, and with the fictional character James Bond following his use of a DB5 model in the 1964 film Goldfinger."
            }
        };
        modelBuilder.Entity<CarViewModel>().HasData(cars);
    }
}