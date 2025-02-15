using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_MBrown.Models;

namespace Mission6_MBrown.Controllers;

public class HomeController : Controller
{
    private MovieInformationContext _context;

    public HomeController(MovieInformationContext movieName) //constructor
    {
        _context = movieName;
    }

    //Home Page
    public IActionResult Index()
    {
        return View();
    }

    //Get To know Joel page
    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    //Quick Wits page
    public IActionResult QuickWitsComedy()
    {
        return Redirect("https://www.qwcomedy.com/");
    }
    
    //Baconsale page
    public IActionResult Baconsale()
    {
        return Redirect( "https://baconsale.com/");
    }
   
    //Adding a movie PAGE
    [HttpGet]
    public IActionResult AddAMovie()
    {
        return View();
    }
    
    //Adding the movie to go to the database
    [HttpPost]
    public IActionResult AddAMovie(NewMovie response)
    {
        _context.NewMovies.Add(response);
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }
}