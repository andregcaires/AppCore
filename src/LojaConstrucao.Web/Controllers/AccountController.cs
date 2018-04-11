using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaConstrucao.Web.Models;
using LojaConstrucao.Domain.Dtos;
using LojaConstrucao.Domain.Products;
using LojaConstrucao.Web.ViewModels;
using LojaConstrucao.Domain;
using LojaConstrucao.Domain.Account;

namespace LojaConstrucao.Web.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;

        public AccountController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);

            if(result)
            {
                return Redirect("/");
            }
            else{
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }

    }
}
