using AutoMapper;
using Library.Core.Entities;
using Library.Core.Requests.Genre;
using Library.Core.Responses.Genre;

namespace Library.Core.Mappings
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreAddRequest, Genre>();
            
            CreateMap<Genre, GenreResponse>();
            
            CreateMap<Genre, GenreWithoutBooksResponse>();
        }
    }
}