using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        return View("AddAMovie", new Movie());
    }
    
    //Saves valid new Movie instances to the database (if invalid, gives errors for correction
    [HttpPost]
    public IActionResult AddAMovie(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); 
            _context.SaveChanges(); 
            
            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            
            return View("AddAMovie", response);
        }
    }

    
    //pulls up list of all movies
    public IActionResult MovieList()
    {
        //Linq query, what we use to pull data from the database
        var movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title).ToList();

        return View(movies);

    }
    
    //pulls up page to edit based on movie chosen by the user
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddAMovie", recordToEdit);
    }
    
    //submits edited information back into the database
    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
    
    //pulls up confirmation page to delete the record
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);

        return View("Delete", recordToDelete);
    }
    
    //deletes the entry
    [HttpPost]
    public IActionResult Delete(Movie deletingInfo)
    {
        _context.Movies.Remove(deletingInfo);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }
}