using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Enums;
using Library.Core.Interfaces.Repositories;
using Library.Core.Interfaces.Services;
using Library.Core.Responses.Author;

namespace Library.Core.Services
{
    public class FindAuthorsService : IFindAuthorsService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public FindAuthorsService(IAuthorRepository authorRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<AuthorWithoutBooksResponse>> GetAuthorsByRealiseDateBook(int year, SortMode sortMode)
        {
            var authors = await _authorRepository.GetAllAuthors();

            authors = authors.Where(a => a.Books.Any(b => b.RealiseDate.Year == year));

            switch (sortMode)
            {
                case SortMode.Increase:
                    authors = authors.OrderBy(a => a.FirstName);
                    break;
                case SortMode.Decrease:
                    authors = authors.OrderByDescending(a => a.FirstName);
                    break;
            }

            return _mapper.Map<IEnumerable<AuthorWithoutBooksResponse>>(authors);
        }

        public async Task<IEnumerable<AuthorWithoutBooksResponse>> FindAuthorBySubstringBookName(string substring)
        {
            var authors = await _authorRepository.GetAllAuthors();
            
            authors = authors.Where(a => a.Books.Any(b => b.Name.Contains(substring)));
            
            return _mapper.Map<IEnumerable<AuthorWithoutBooksResponse>>(authors);
        }
    }
}