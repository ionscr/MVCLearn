using Microsoft.AspNetCore.Mvc;
using MVCLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLearn.Controllers
{
    public class HomeController : Controller
    {
        private IAuthorRepository _authorRepository;
        public HomeController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public IActionResult Index()
        {
            var content = _authorRepository.GetAuthors();
            return View(content);
        }
    }
}
