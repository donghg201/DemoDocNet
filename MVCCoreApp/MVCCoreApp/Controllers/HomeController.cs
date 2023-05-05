using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCoreApp.Models;

namespace MVCCoreApp.Controllers
{
    //[Route("khach-hang")]
    public class HomeController : Controller
    {
        //[Route("vip")]
        //public string Vip()
        //{
        //    return "Khach hang vip";
        //}

        //[Route("")]
        //[Route("normal/{id?}")]
        //public string Normal(int id)
        //{
        //    return "Khach hang thuong voi id la: " + id;
        //}

        //[Route("Home/Index/{id:int}")]
        //public IActionResult Index(int id)
        //{
        //    var model = new IndexModel();
        //    model.Message = "Hello from Model, ID = " + id;
        //    return View(model);
        //}

        //[Route("Home/Index/{id:int}")]
        public IActionResult Index(string year)
        {
            var model = new IndexModel();
            model.Message = "Hello from Model, year = " + year;
            return View(model);
        }
    }
}