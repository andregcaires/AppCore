using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaConstrucao.Web.Models;
using LojaConstrucao.Domain.Dtos;
using LojaConstrucao.Domain.Products;

namespace LojaConstrucao.Web.Controllers
{

    public class CategoryController : Controller
    {
        private readonly CategoryStorage _categoryStorage;

        public CategoryController(CategoryStorage categoryStorage)
        {
            _categoryStorage = categoryStorage; 
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateOrEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryDto dto)
        {
            _categoryStorage.Store(dto);

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
