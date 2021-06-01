using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Entities;
using Library.Core.Enums;
using Library.Core.General;
using Library.Core.Interfaces.Repositories;
using Library.Core.Interfaces.Services;
using Library.Core.Responses.Author;
using Library.Core.UoW;

namespace Library.Core.Services
{
    public class FinderAuthorsService : IFinderAuthorsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FinderAuthorsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<AuthorWithoutBooksResponse>> GetAuthorsByRealiseDateBook(int year, SortMode sortMode)
        {
            Func<IQueryable<Author>, IOrderedQueryable<Author>> orderBy = null;
            
            switch (sortMode)
            {
                case SortMode.Increase:
                    orderBy = q=> q.OrderBy(a => a, new AuthorNameComparer());
                    break;
                case SortMode.Decrease:
                    orderBy = q=> q.OrderByDescending(a => a, new AuthorNameComparer());
                    break;
            }
            
            var authors = await _unitOfWork.GetRepository<IAuthorRepository>()
                .GetAllAuthors(
                    predicate: a => a.Books.Any(b => b.RealiseDate.Year == year),
                    orderBy: orderBy,
                    include: IncludeEntities.IncludeAllForAuthor
                );
            
            return _mapper.Map<IEnumerable<AuthorWithoutBooksResponse>>(authors);
        }

        public async Task<IEnumerable<AuthorWithoutBooksResponse>> FindAuthorBySubstringBookName(string substring)
        {
            var authors = await _unitOfWork.GetRepository<IAuthorRepository>()
                .GetAllAuthors(
                    predicate: a => a.Books.Any(b => b.Name.Contains(substring)),
                    include: IncludeEntities.IncludeAllForAuthor
                    );

            return _mapper.Map<IEnumerable<AuthorWithoutBooksResponse>>(authors);
        }
    }
}