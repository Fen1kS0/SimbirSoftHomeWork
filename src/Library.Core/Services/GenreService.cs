using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Exceptions;
using Library.Core.Interfaces.Repositories;
using Library.Core.Interfaces.Services;
using Library.Core.Models;
using Library.Core.Requests.Genre;
using Library.Core.Responses.Book;
using Library.Core.Responses.Genre;

namespace Library.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public GenreService(IMapper mapper, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GenreWithoutBooksResponse>> GetAllGenres()
        {
            var genres = await _genreRepository.GetAllGenres();

            return _mapper.Map<IEnumerable<GenreWithoutBooksResponse>>(genres);
        }

        public async Task<GenreResponse> AddGenre(GenreAddRequest genreAddRequest)
        {
            var genre = _mapper.Map<Genre>(genreAddRequest);
            
            await _genreRepository.AddGenre(genre);
            await _genreRepository.SaveChanges();

            return _mapper.Map<GenreResponse>(genre);
        }

        public async Task<BookCountResponse> GetCountBooks(Guid genreId)
        {
            var genre = await _genreRepository.GetGenreById(genreId);

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