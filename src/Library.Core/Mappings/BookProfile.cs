using AutoMapper;
using Library.Core.Models;
using Library.Core.Requests.Book;
using Library.Core.Responses.Book;

namespace Library.Core.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookAddRequest, Book>();

            CreateMap<Book, BookResponse>();
            
            CreateMap<Book, BookCountResponse>()
                .ForMember(x => x.CountBooks, 
                    m => m
                        .MapFrom(from => from.Genres.Count));
        }
    }
}