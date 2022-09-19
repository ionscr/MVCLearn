using Microsoft.AspNetCore.Mvc;
using MVCLearn.Models;
using System;
using System.Linq;

namespace MVCLearn.Components
{
    public class AuthorPublications : ViewComponent
    {
        private IPublicationRepository _publicationRepository;
        public AuthorPublications(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }
        public IViewComponentResult Invoke(Guid authorId)
        {
            var result = _publicationRepository.GetPublications().Where(p => p.Author.Id == authorId).ToList();
            return View(result);
        }
    }
}
