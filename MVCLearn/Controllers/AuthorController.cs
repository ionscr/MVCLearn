using Microsoft.AspNetCore.Mvc;
using MVCLearn.Core.Dto;
using MVCLearn.Models;

namespace MVCLearn.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "MVCLearn";
            var content = _authorRepository.GetAuthors();
            return View(content);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddAuthor author)
        {
            _authorRepository.AddAuthor(new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            });
            return View();
        }
    }
}
