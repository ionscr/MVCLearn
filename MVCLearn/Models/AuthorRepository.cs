using MVCLearn.Core.Dto;
using MVCLearn.Domain;
using MVCLearn.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCLearn.Models
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthor(Guid id);
        IEnumerable<Author> AddAuthor(AuthorDto author);
        IEnumerable<Author> DeleteAuthor(Guid id);
    }
    public class AuthorRepository : IAuthorRepository
    {
        private IWebApiService _webApiService;
        public AuthorRepository(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public IEnumerable<Author> GetAuthors()
        {
            return _webApiService.GetAuthors().Result.ToList();
        }
        public Author GetAuthor(Guid id)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<Author> AddAuthor(AuthorDto author)
        {
            return _webApiService.AddAuthor(author).Result.ToList();
        }

        public IEnumerable<Author> DeleteAuthor(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
