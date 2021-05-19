using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Interfaces.Repositories;
using Library.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LibraryDbContext _context;

        public GenreRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            IQueryable<Genre> query = _context.Genres
                .Include(g => g.Books)
                .ThenInclude(b => b.Author)
                .Include(g => g.Books)
                .ThenInclude(b => b.Readers);
            
            return await query.ToListAsync();
        }

        public async Task<Genre> GetGenreById(Guid id)
        {
            IQueryable<Genre> query = _context.Genres
                .Include(g => g.Books)
                .ThenInclude(b => b.Author)
                .Include(g => g.Books)
                .ThenInclude(b => b.Readers);

            return await query.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddGenre(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
        }

        public async Task UpdateGenre(Genre genre)
        {
            await Task.Run(() =>
            {
                _context.Genres.Update(genre);
            });
        }

        public async Task DeleteGenre(Genre genre)
        {
            await Task.Run(() =>
            {
                _context.Genres.Remove(genre);
            });
        }
        
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}