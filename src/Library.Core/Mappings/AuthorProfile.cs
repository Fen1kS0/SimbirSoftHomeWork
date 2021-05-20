using AutoMapper;
using Library.Core.Entities;
using Library.Core.Requests.Author;
using Library.Core.Responses.Author;

namespace Library.Core.Mappings
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorAddRequest, Author>();
            
            CreateMap<Author, AuthorResponse>();
            
            CreateMap<Author, AuthorWithoutBooksResponse>();
        }
    }
}