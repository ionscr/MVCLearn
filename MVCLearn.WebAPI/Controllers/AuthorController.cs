using Microsoft.AspNetCore.Mvc;
using MVCLearn.Domain;
using MVCLearn.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCLearn.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public AuthorController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            var result = _appDbContext.Authors.ToList();
            return Ok(result);
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Author> GetAuthor(Guid id)
        {
            var result = _appDbContext.Authors.FirstOrDefault(p => p.Id == id);
            if (result != null)
                return Ok(result);
            else return NotFound();
        }

        [HttpPost]
        public ActionResult<IEnumerable<Author>> AddAuthor([FromBody] Author author)
        {
            author.Id = Guid.NewGuid();
            _appDbContext.Authors.Add(author);
            _appDbContext.SaveChanges();
            var result = _appDbContext.Authors.ToList();
            return Ok(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult<IEnumerable<Author>> DeleteAuthor(Guid id)
        {
            var authorToDelete = _appDbContext.Authors.FirstOrDefault(p => p.Id == id);
            if (authorToDelete == null) return NotFound();
            _appDbContext.Authors.Remove(authorToDelete);
            _appDbContext.SaveChanges();
            var result = _appDbContext.Authors.ToList();
            return Ok(result);
        }
    }
}
