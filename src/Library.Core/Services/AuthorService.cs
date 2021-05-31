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
using Library.Core.Responses.Author;
using Library.Core.Responses.Book;
using Library.Core.UoW;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<AuthorWithoutBooksResponse>> GetAllAuthors()
        {
            var authors = await _unitOfWork.GetRepository<IAuthorRepository>()
                .GetAllAuthors(include: IncludeEntities.IncludeAllForAuthor);

            return _mapper.Map<IEnumerable<AuthorWithoutBooksResponse>>(authors);
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByAuthor(Guid authorId)
        {
            if (await _unitOfWork.GetRepository<IAuthorRepository>().GetAuthorById(authorId) == null)
            {
                throw new NotFoundException($"Author with id {authorId} not found");
            }

            var books = await _unitOfWork.GetRepository<IBookRepository>()
                .GetAllBooks(include: IncludeEntities.IncludeAllForBook);

            return _mapper.Map<IEnumerable<BookResponse>>(books);
        }

        public async Task<AuthorResponse> AddAuthor(AuthorAddRequest authorAddRequest)
        {
            var author = _mapper.Map<Author>(authorAddRequest);
            
            await _unitOfWork.GetRepository<IAuthorRepository>().AddAuthor(author);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AuthorResponse>(author);
        }

        public async Task<AuthorResponse> DeleteAuthor(Guid id)
        {
            var author = await _unitOfWork.GetRepository<IAuthorRepository>()
                .GetAuthorById(id, q => q.Include(a => a.Books));
            
            if (author == null)
            {
                throw new NotFoundException($"Author with id {id} not found");
            }
            
            if (author.Books.Count != 0)
            {
                throw new BadRequestException("You can't delete an author while there are his books");
            }
            
            await _unitOfWork.GetRepository<IAuthorRepository>().DeleteAuthor(author);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AuthorResponse>(author);
        }
    }
}