﻿using Microsoft.AspNetCore.Mvc;
using ViewExercise.Models;
using ViewExercise.ViewData;

namespace ViewExercise.Controllers
{
    public class MovieController : Controller
    {
        //[Route("[Controler]/[Action]")]
        public IActionResult UI()
        {
            Movie movie = new Movie(){ MovieName = "3 Idiots" };
            var customer = new  List<Customer>
                {
                new Customer { MovieId = 1 , CustomerName = "Rahul"},
                new Customer { MovieId = 1 , CustomerName = "Deepak"}
            };
            var ViewModel = new ListOfCustomer
            { Movie = movie, Customers =  customer };
            return View(ViewModel);
        }
        public IActionResult Details(int id)
        {
            var customer = new List<Customer>
                {
                new Customer { MovieId = 1 , CustomerName = "Rahul"},
                new Customer { MovieId = 1 , CustomerName = "Deepak"}
            };
            var cust = customer.FirstOrDefault(customer => customer.Id == id+1);
            ViewBag.data = cust;
            Console.WriteLine(cust.CustomerName);
            return View();
        }
    }
}