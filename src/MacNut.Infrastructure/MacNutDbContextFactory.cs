using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MacNut.Infrastructure;

public class MacNutDbContextFactory : IDesignTimeDbContextFactory<MacNutDbContext>
{
    public MacNutDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MacNutDbContext>();
        return new MacNutDbContext(optionsBuilder.Options);
    }
}