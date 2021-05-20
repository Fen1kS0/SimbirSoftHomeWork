using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly LibraryDbContext _context;

        public PersonRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            IQueryable<Person> query = _context.People
                .Include(p => p.Books)
                .ThenInclude(b => b.Author)
                .Include(p => p.Books)
                .ThenInclude(b => b.Genres);
            
            return await query.ToListAsync();
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            IQueryable<Person> query = _context.People
                .Include(p => p.Books)
                .ThenInclude(b => b.Author)
                .Include(p => p.Books)
                .ThenInclude(b => b.Genres);

            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPerson(Person person)
        {
            await _context.People.AddAsync(person);
        }

        public async Task UpdatePerson(Person person)
        {
            await Task.Run(() =>
            {
                person.LastUpdateRecordDate = DateTimeOffset.Now;
                person.Version++;
                
                _context.People.Update(person);
            });
        }

        public async Task DeletePerson(Person person)
        {
            await Task.Run(() =>
            {
                _context.People.Remove(person);
            });
        }
        
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}