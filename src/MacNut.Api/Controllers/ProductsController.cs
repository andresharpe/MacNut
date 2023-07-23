using MacNut.Domain;
using MacNut.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MacNut.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    private readonly ILogger<ProductsController> _logger;
    private readonly MacNutDbContext _dbContext;

    public ProductsController(ILogger<ProductsController> logger, MacNutDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "Products")]
    public IEnumerable<Product> Get()
    {
        _logger.LogInformation("Woop!");

        return _dbContext.Products.Include("Categories");
    }
}