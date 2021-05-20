using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Exceptions;
using Library.Core.Interfaces.Repositories;
using Library.Core.Interfaces.Services;
using Library.Core.Models;
using Library.Core.Requests.Author;
using Library.Core.Requests.Book;
using Library.Core.Responses.Book;

namespace Library.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;

        public BookService(IMapper mapper, IBookRepository bookRepository, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<BookResponse>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();

            return _mapper.Map<IEnumerable<BookResponse>>(books);
        }

        public async Task<BookResponse> AddBook(BookAddRequest bookAddRequest)
        {
            var book = _mapper.Map<Book>(bookAddRequest);
            
            await _bookRepository.AddBook(book);
            await _bookRepository.SaveChanges();

            return _mapper.Map<BookResponse>(book);
        }

        public async Task<BookResponse> DeleteBook(Guid id)
        {
            var book = await _bookRepository.GetBookById(id);
            
            if (book == null)
            {
                throw new NotFoundException($"Book with id {id} not found");
            }
            
            if (book.Readers.Count != 0)
            {
                throw new BadRequestException("This book is with the person");
            }
            
            await _bookRepository.DeleteBook(book);
            await _bookRepository.SaveChanges();

            return _mapper.Map<BookResponse>(book);
        }

        public async Task<BookResponse> UpdateGenres(Guid id, BookUpdateGenresRequest bookUpdateGenresRequest)
        {
            var book = await _bookRepository.GetBookById(id);
            
            if (book == null)
            {
                throw new NotFoundException($"Book with id {id} not found");
            }
            
            var genres = new List<Genre>();

            foreach (Guid genreId in bookUpdateGenresRequest.GenresId)
            {
                var genre = await _genreRepository.GetGenreById(genreId);

                if (genre == null)
                {
                    throw new NotFoundException($"Genre with id {genreId} not found");
                }
                
                genres.Add(genre);
            }

            book.Genres = genres;

            await _bookRepository.UpdateBook(book);
            await _bookRepository.SaveChanges();

            return _mapper.Map<BookResponse>(book);
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByAuthor(AuthorFioRequest authorFioRequest)
        {
            var books = await _bookRepository.GetAllBooks();

            books = books.Where(b => 
                b.Author.FirstName == (authorFioRequest.FirstName ?? b.Author.FirstName)
                && b.Author.LastName == (authorFioRequest.LastName ?? b.Author.LastName)
                && b.Author.MiddleName == (authorFioRequest.MiddleName ?? b.Author.MiddleName));
            
            return _mapper.Map<IEnumerable<BookResponse>>(books);
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByGenre(Guid genreId)
        {
            var genre = await _genreRepository.GetGenreById(genreId);

            if (genre == null)
            {
                throw new NotFoundException($"Genre with id {genreId} not found");
            }

            return _mapper.Map<IEnumerable<BookResponse>>(genre.Books);
        }
    }
}