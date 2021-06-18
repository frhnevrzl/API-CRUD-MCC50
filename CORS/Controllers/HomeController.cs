using API.Models;
using CORS.Base;
using CORS.Models;
using CORS.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CORS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : BaseController<Person, PersonRepository, int>
    {
        PersonRepository repository;
        //private readonly ILogger<HomeController> _logger;
        
        public HomeController(PersonRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Getsemuadata()
        {
            var result = await repository.GetAllProfile();
            return Json(result);
        }
        //[HttpGet("GetById/{nik}")]
        public async Task<JsonResult> GetByid(int Id)
        {
            var result = await repository.GetById(Id);
            return Json(result);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        
        public IActionResult Pokemon()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Person()
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
}
