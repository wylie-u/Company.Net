using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CompanyManager.Models;
using CompanyManager.ViewModels;

namespace CompanyManager.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Signup()
    {
        return View();
    }

    // should this be in the user controller??????
    //[HttpPost]
    //public IActionResult Signup(UserViewModel user)
    //{
    //    // if model is valid 
    //    if (ModelState.IsValid)
    //    {
    //        return RedirectToAction("Index");
    //    }
    //    return View();
    //}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

