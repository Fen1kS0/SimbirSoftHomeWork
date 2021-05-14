using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Models;

namespace Library.Core.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeople();

        Task<Person> GetPersonById(Guid id);

        Task AddPerson(Person person);

        Task UpdatePerson(Person person);

        Task DeletePerson(Person person);
    }
}