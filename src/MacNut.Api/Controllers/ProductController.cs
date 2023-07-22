using MacNut.Domain;
using MacNut.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace MacNut.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly MacNutDbContext _dbContext;

    public ProductController(ILogger<ProductController> logger, MacNutDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "Products")]
    public IEnumerable<Product> Get()
    {
        _logger.LogInformation("Woop!");

        return _dbContext.Products;
    }
}