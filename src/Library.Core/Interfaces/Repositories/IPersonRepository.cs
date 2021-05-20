using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Core.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeople(
            Expression<Func<Person, bool>> predicate = null,
            Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null,
            Func<IQueryable<Person>, IIncludableQueryable<Person, object>> include = null,
            bool disableTracking = true
            );

        Task<Person> GetPersonById(
            Guid id,
            Func<IQueryable<Person>, IIncludableQueryable<Person, object>> include = null,
            bool disableTracking = true
            );

        Task AddPerson(Person person);

        Task UpdatePerson(Person person);

        Task DeletePerson(Person person);
    }
}