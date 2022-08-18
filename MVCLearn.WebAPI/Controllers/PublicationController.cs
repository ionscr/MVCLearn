using Microsoft.AspNetCore.Mvc;
using MVCLearn.Domain;
using MVCLearn.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLearn.WebAPI.Controllers
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
            var result = _appDbContext.Publications.ToList();
            return Ok(result);
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Publication> GetPublication(Guid id)
        {
            var result = _appDbContext.Publications.FirstOrDefault(p => p.Id == id);
            if (result != null)
                return Ok(result);
            else return NotFound();
        }

        [HttpPost]
        public ActionResult<IEnumerable<Publication>> AddPublication([FromBody] Publication publication)
        {
            publication.Id = Guid.NewGuid();
            _appDbContext.Publications.Add(publication);
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
