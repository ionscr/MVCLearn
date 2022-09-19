using System;

namespace MVCLearn.Core.Dto
{
    public class PublicationDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
    }
}
