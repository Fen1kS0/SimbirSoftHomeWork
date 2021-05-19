using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Interfaces.Repositories;
using Library.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var query = _context.Authors
                .Include(a => a.Books)
                .ThenInclude(b => b.Readers)
                .Include(a => a.Books)
                .ThenInclude(b => b.Genres);
                
            return await query.ToListAsync();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            var query = _context.Authors
                .Include(a => a.Books)
                .ThenInclude(b => b.Readers)
                .Include(a => a.Books)
                .ThenInclude(b => b.Genres);

            return await query.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
        }

        public async Task UpdateAuthor(Author author)
        {
            await Task.Run(() =>
            {
                _context.Authors.Update(author);
            });
        }

        public async Task DeleteAuthor(Author author)
        {
            await Task.Run(() =>
            {
                _context.Authors.Remove(author);
            });
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}