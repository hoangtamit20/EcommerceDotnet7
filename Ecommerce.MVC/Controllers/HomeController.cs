using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.MVC.Models;
using Ecommerce.Data.IdentityDatabase;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // private readonly IDbContextFactory<EcommerceDbContext> _contextFactory;

    public HomeController(
        ILogger<HomeController> logger
        // IDbContextFactory<EcommerceDbContext> contextFactory
        )
    {
        _logger = logger;
        // _contextFactory = contextFactory;
    }

    // public async Task<IActionResult> Get()
    // {
    //     using var context = _contextFactory.CreateDbContext();
    //     var data = await context.MyEntities.ToListAsync();
    //     return Ok();
    // }

    public IActionResult Index()
    {
        return View();
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
