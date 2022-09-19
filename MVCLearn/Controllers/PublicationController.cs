using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVCLearn.Models;
using System;
using System.Collections.Generic;

namespace MVCLearn.Controllers
{
    public class PublicationController : Controller
    {
        private IPublicationRepository _publicationRepository;
        public PublicationController(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }
        [System.Web.Mvc.HandleError]
        public IActionResult Index()
        {
            throw new OutOfMemoryException();
            ViewBag.Title = "MVCLearn";
            var content = _publicationRepository.GetPublications();
            return View(content);
        }

        public IActionResult Details(Guid id)
        {
            throw new KeyNotFoundException();
            var content = _publicationRepository.GetPublication(id);
            if (content == null)
                return NotFound();
            return View(content);
        }
    }
}
