using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Entities;
using Library.Core.Exceptions;
using Library.Core.General;
using Library.Core.Interfaces.Repositories;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Genre;
using Library.Core.Responses.Book;
using Library.Core.Responses.Genre;
using Library.Core.UoW;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GenreWithoutBooksResponse>> GetAllGenres()
        {
            var genres = await _unitOfWork.GetRepository<IGenreRepository>()
                .GetAllGenres(include: IncludeEntities.IncludeAllForGenre);

            return _mapper.Map<IEnumerable<GenreWithoutBooksResponse>>(genres);
        }

        public async Task<GenreResponse> AddGenre(GenreAddRequest genreAddRequest)
        {
            var genre = _mapper.Map<Genre>(genreAddRequest);
            
            await _unitOfWork.GetRepository<IGenreRepository>().AddGenre(genre);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GenreResponse>(genre);
        }

        public async Task<BookCountResponse> GetCountBooks(Guid genreId)
        {
            var genre = await _unitOfWork.GetRepository<IGenreRepository>()
                .GetGenreById(genreId, q => q.Include(g => g.Books));

            if (genre == null)
            {
                throw new NotFoundException($"Genre with id {genreId} not found");
            }

            return new BookCountResponse()
            {
                CountBooks = genre.Books.Count
            };
        }
    }
}