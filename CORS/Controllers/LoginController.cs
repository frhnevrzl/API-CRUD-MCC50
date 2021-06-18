using API.Models;
using API.ViewModels;
using CORS.Base;
using CORS.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORS.Controllers
{
    public class LoginController : BaseController<Person, LoginRepository, int>
    {
        LoginRepository repository;

        public LoginController(LoginRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Auth(LoginVM loginVM)
        {
            var jwToken = await repository.Auth(loginVM);
            if (jwToken == null)
            {
                return RedirectToAction("login");
            }
            HttpContext.Session.SetString("JWToken", jwToken.Token);
            return RedirectToAction("index", "home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Login");
        }
    }
}
