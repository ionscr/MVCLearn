using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCLearn.Core.Dto;
using MVCLearn.Domain;
using MVCLearn.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLearn.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicationController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PublicationController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Publication>> GetPublications()
        {
            var result = _appDbContext.Publications.Include(p => p.Author).ToList();
            return Ok(result);
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Publication> GetPublication(Guid id)
        {
            var result = _appDbContext.Publications.Include(p => p.Author).FirstOrDefault(p => p.Id == id);
            if (result != null)
                return Ok(result);
            else return NotFound();
        }

        [HttpPost]
        public ActionResult<IEnumerable<Publication>> AddPublication([FromBody] PublicationDto publication)
        {
            var publicationToAdd = new Publication
            {
                Id = Guid.NewGuid(),
                Author = _appDbContext.Authors.FirstOrDefault(p => p.Id == publication.AuthorId),
                Content = publication.Content,
                Title = publication.Title
                
            };
            _appDbContext.Publications.Add(publicationToAdd);
            _appDbContext.SaveChanges();
            var result = _appDbContext.Publications.ToList();
            return Ok(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult<IEnumerable<Publication>> DeletePublication(Guid id)
        {
            var publicationToDelete = _appDbContext.Publications.FirstOrDefault(p => p.Id == id);
            if (publicationToDelete == null) return NotFound();
            _appDbContext.Publications.Remove(publicationToDelete);
            _appDbContext.SaveChanges();
            var result = _appDbContext.Publications.ToList();
            return Ok(result);
        }
    }
}
