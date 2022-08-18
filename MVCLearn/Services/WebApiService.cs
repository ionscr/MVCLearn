using Microsoft.AspNetCore.Mvc;
using MVCLearn.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCLearn.Services
{
    public interface IWebApiService
    {
        public Task<IEnumerable<Author>> GetAuthors();
    }
    public class WebApiService : IWebApiService
    {
        private string _apiUrl;
        public WebApiService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var authors = new List<Author>();
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(_apiUrl + "author");
                if (result.IsSuccessStatusCode)
                {
                    authors = await result.Content.ReadAsAsync<List<Author>>();
                }
                return authors;
            }
        }
    }
}
