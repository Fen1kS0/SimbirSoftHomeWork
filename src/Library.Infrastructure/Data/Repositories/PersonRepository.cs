using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Infrastructure.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IGenericRepository<Person> _genericRepository;

        public PersonRepository(LibraryDbContext context)
        {
            _genericRepository = new GenericRepository<Person>(context.People);
        }

        public async Task<IEnumerable<Person>> GetAllPeople(
            Expression<Func<Person, bool>> predicate = null, 
            Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, 
            Func<IQueryable<Person>, IIncludableQueryable<Person, object>> include = null, 
            bool disableTracking = true
            )
        {
            return await _genericRepository.GetAllAsync(predicate, orderBy, include, disableTracking);
        }

        public async Task<Person> GetPersonById(
            Guid id, 
            Func<IQueryable<Person>, IIncludableQueryable<Person, object>> include = null, 
            bool disableTracking = true
            )
        {
            return await _genericRepository.GetEntityByIdAsync(id, include, disableTracking);
        }

        public async Task AddPerson(Person person)
        {
            await _genericRepository.AddEntityAsync(person);
        }

        public async Task UpdatePerson(Person person)
        {
            await _genericRepository.UpdateEntityAsync(person);
        }

        public async Task DeletePerson(Person person)
        {
            await _genericRepository.DeleteEntityAsync(person);
        }
    }
}