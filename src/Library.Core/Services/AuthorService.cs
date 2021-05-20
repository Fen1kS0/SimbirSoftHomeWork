using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Entities;
using Library.Core.Exceptions;
using Library.Core.Interfaces.Repositories;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Author;
using Library.Core.Responses.Author;
using Library.Core.Responses.Book;

namespace Library.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public AuthorService(IMapper mapper, IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }


        public async Task<IEnumerable<AuthorWithoutBooksResponse>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllAuthors();

            return _mapper.Map<IEnumerable<AuthorWithoutBooksResponse>>(authors);
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByAuthor(Guid authorId)
        {
            if (await _authorRepository.GetAuthorById(authorId) == null)
            {
                throw new NotFoundException($"Author with id {authorId} not found");
            }
            
            var books = (await _bookRepository.GetAllBooks())
                .Where(b => b.AuthorId == authorId);
            
            return _mapper.Map<IEnumerable<BookResponse>>(books);
        }

        public async Task<AuthorResponse> AddAuthor(AuthorAddRequest authorAddRequest)
        {
            var author = _mapper.Map<Author>(authorAddRequest);
            
            await _authorRepository.AddAuthor(author);
            await _authorRepository.SaveChanges();

            return _mapper.Map<AuthorResponse>(author);
        }

        public async Task<AuthorResponse> DeleteAuthor(Guid id)
        {
            var author = await _authorRepository.GetAuthorById(id);
            
            if (author == null)
            {
                throw new NotFoundException($"Author with id {id} not found");
            }
            
            if (author.Books.Count != 0)
            {
                throw new BadRequestException("You can't delete an author while there are his books");
            }
            
            await _authorRepository.DeleteAuthor(author);
            await _authorRepository.SaveChanges();

            return _mapper.Map<AuthorResponse>(author);
        }
    }
}