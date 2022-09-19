using MVCLearn.Domain;
using MVCLearn.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCLearn.Models
{
    public interface IPublicationRepository
    {
        IEnumerable<Publication> GetPublications();
        Publication GetPublication(Guid id);
        IEnumerable<Publication> AddPublication(Publication publication);
        IEnumerable<Publication> DeletePublication(Guid id);
    }
    public class PublicationRepository : IPublicationRepository
    {
        private IWebApiService _webApiService;
        public PublicationRepository(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public IEnumerable<Publication> AddPublication(Publication publication)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publication> DeletePublication(Guid id)
        {
            throw new NotImplementedException();
        }

        public Publication GetPublication(Guid id)
        {
            return _webApiService.GetPublication(id).Result;
        }

        public IEnumerable<Publication> GetPublications()
        {
            return _webApiService.GetPublications().Result.ToList();
        }
    }
}
