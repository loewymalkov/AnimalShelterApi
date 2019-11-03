using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AnimalShelterClient.Models;

namespace AnimalShelterClient.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public IActionResult Index()
    {
        var allAnimals = Animal.GetAnimals();
        return View(allAnimals);
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
        var targetAnimal = Animal.PutAnimal(animal);
        return RedirectToAction("Details", "Animals", targetAnimal);
    }

    public ActionResult Details (Animal animal)
    {
        return View(animal);
    }

    [HttpGet]
    public ActionResult Type()
    {
        return View();
    }

    // [HttpPost]
    // public ActionResult Type(Animal animal)
    // {
    //     var targetAnimal = Animal.PutAnimal(animal);
    //     return RedirectToAction("Type", "Animals", targetAnimal);
    // }
  }
}

