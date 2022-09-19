using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCLearn.Core.Dto;
using MVCLearn.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCLearn.Services
{
    public interface IWebApiService
    {
        public Task<IEnumerable<Author>> GetAuthors();
        public Task<IEnumerable<Author>> AddAuthor(AuthorDto author);
        public Task<IEnumerable<Publication>> GetPublications();
        public Task<Publication> GetPublication(Guid id);
    }
    public class WebApiService : IWebApiService
    {
        private string _apiUrl;
        private IHttpClientFactory _factory;
        public WebApiService(/*string apiUrl,*/ IHttpClientFactory factory, IConfiguration Configuration)
        {
            _apiUrl = Configuration.GetConnectionString("WebAPI");
            _factory = factory;
        }
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var authors = new List<Author>();
            var client = _factory.CreateClient("ApiClient");
            var result = await client.GetAsync(_apiUrl + "author");
            if (result.IsSuccessStatusCode)
            {
                authors = await result.Content.ReadAsAsync<List<Author>>();
            }
            return authors;
        }

        public async Task<IEnumerable<Author>> AddAuthor(AuthorDto author)
        {
            var authors = new List<Author>();
            var json = JsonConvert.SerializeObject(author);
            StringContent content = new StringContent (json, System.Text.Encoding.UTF8, "application/json");
            var client = _factory.CreateClient("ApiClient");
            var result = await client.PostAsync(_apiUrl + "author", content);
            if (result.IsSuccessStatusCode)
            {
                authors = await result.Content.ReadAsAsync<List<Author>>();
            }
            return authors;
        }

        public async Task<IEnumerable<Publication>> GetPublications()
        {
            var publications = new List<Publication>();
            var client = _factory.CreateClient("ApiClient");
            var result = await client.GetAsync(_apiUrl + "publication");
            if (result.IsSuccessStatusCode)
            {
                publications = await result.Content.ReadAsAsync<List<Publication>>();
            }
            return publications;
        }
        public async Task<Publication> GetPublication(Guid id)
        {
            var publication = new Publication();
            var client = _factory.CreateClient("ApiClient");
            var result = await client.GetAsync(_apiUrl + "publication/" + id);
            if (result.IsSuccessStatusCode)
            {
                publication = await result.Content.ReadAsAsync<Publication>();
            }
            return publication;
        }
    }
}
