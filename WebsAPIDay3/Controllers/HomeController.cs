using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsAPIDay3.Models;

namespace WebsAPIDay3.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            var catBreeds = CatAPIMethods.CatBreeds().Result; //need Result otherwise it's a Task
            //without it, it just runs the method
            return View(catBreeds);
        }

        //home controller, collect, and send info to the view


        public IActionResult RandomCatByBreed() //10
        {
            var catImages = CatAPIMethods.GetBreedImages().Result;
            return View(catImages);
        }
    }
}
