using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Entities;
using Library.Core.Exceptions;
using Library.Core.General;
using Library.Core.Interfaces.Repositories;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Author;
using Library.Core.Requests.Book;
using Library.Core.Responses.Book;
using Library.Core.UoW;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookResponse>> GetAllBooks()
        {
            var books = await _unitOfWork.GetRepository<IBookRepository>()
                .GetAllBooks(include: IncludeEntities.IncludeAllForBook);

            return _mapper.Map<IEnumerable<BookResponse>>(books);
        }

        public async Task<BookResponse> AddBook(BookAddRequest bookAddRequest)
        {
            var book = _mapper.Map<Book>(bookAddRequest);
            
            await _unitOfWork.GetRepository<IBookRepository>().AddBook(book);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BookResponse>(book);
        }

        public async Task<BookResponse> DeleteBook(Guid id)
        {
            var book = await _unitOfWork.GetRepository<IBookRepository>()
                .GetBookById(id, q => q.Include(b => b.Readers));
            
            if (book == null)
            {
                throw new NotFoundException($"Book with id {id} not found");
            }
            
            if (book.Readers.Count != 0)
            {
                throw new BadRequestException("This book is with the person");
            }
            
            await _unitOfWork.GetRepository<IBookRepository>().DeleteBook(book);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BookResponse>(book);
        }

        public async Task<BookResponse> UpdateGenres(Guid id, BookUpdateGenresRequest bookUpdateGenresRequest)
        {
            var book = await _unitOfWork.GetRepository<IBookRepository>()
                .GetBookById(id, IncludeEntities.IncludeAllForBook, false);
            
            if (book == null)
            {
                throw new NotFoundException($"Book with id {id} not found");
            }
            
            var genres = new List<Genre>();

            foreach (Guid genreId in bookUpdateGenresRequest.GenresId)
            {
                var genre = await _unitOfWork.GetRepository<IGenreRepository>()
                    .GetGenreById(genreId, disableTracking: false);

                if (genre == null)
                {
                    throw new NotFoundException($"Genre with id {genreId} not found");
                }
                
                genres.Add(genre);
            }

            book.Genres = genres;

            await _unitOfWork.GetRepository<IBookRepository>().UpdateBook(book);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<BookResponse>(book);
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByAuthor(AuthorFioRequest authorFioRequest)
        {
            var books = await _unitOfWork.GetRepository<IBookRepository>()
                .GetAllBooks(
                    predicate: b => 
                        b.Author.FirstName == (authorFioRequest.FirstName ?? b.Author.FirstName)
                        && b.Author.LastName == (authorFioRequest.LastName ?? b.Author.LastName)
                        && b.Author.MiddleName == (authorFioRequest.MiddleName ?? b.Author.MiddleName),
                    include: IncludeEntities.IncludeAllForBook
                    );

            return _mapper.Map<IEnumerable<BookResponse>>(books);
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByGenre(Guid genreId)
        {
            var genre = await _unitOfWork.GetRepository<IGenreRepository>()
                .GetGenreById(genreId, IncludeEntities.IncludeAllForGenre);

            if (genre == null)
            {
                throw new NotFoundException($"Genre with id {genreId} not found");
            }

            return _mapper.Map<IEnumerable<BookResponse>>(genre.Books);
        }
    }
}