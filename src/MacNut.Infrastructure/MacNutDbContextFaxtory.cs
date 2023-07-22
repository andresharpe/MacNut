using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MacNut.Infrastructure;

public class MacNutDbContextFactory : IDesignTimeDbContextFactory<MacNutDbContext>
{
    public MacNutDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MacNutDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost; Database=macnut; Username=postgres; Password=mysecretpassword;");
        return new MacNutDbContext(optionsBuilder.Options);
    }
}