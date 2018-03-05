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

namespace LojaConstrucao.Web.Controllers
{

    public class CategoryController : Controller
    {
        private readonly CategoryStorage _categoryStorage;
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(CategoryStorage categoryStorage, IRepository<Category> categoryRepository)
        {
            _categoryStorage = categoryStorage; 
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var categories = _categoryRepository.All();
            var viewModels = categories.Select(c => new CategoryViewModel{Id = c.Id, Name = c.Name});

            return View(viewModels);
        }

        public IActionResult CreateOrEdit(int id)
        {
            if(id > 0)
            {
                var category = _categoryRepository.GetById(id);
                var categoryViewModel = new CategoryViewModel{ Id = category.Id, Name = category.Name};
                return View(categoryViewModel);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
            _categoryStorage.Store(viewModel.Id, viewModel.Name);

            return RedirectToAction("Index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
