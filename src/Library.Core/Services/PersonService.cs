using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Person;
using Library.Core.Responses.Book;
using Library.Core.Responses.Person;

namespace Library.Core.Services
{
    public class PersonService : IPersonService
    {
        public async Task<IEnumerable<PersonResponse>> GetAllPeople()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonResponse>> GetAllPeopleByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonResponse> AddPerson(PersonAddRequest personAddRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonResponse> UpdatePerson(Guid id, PersonUpdateRequest personUpdateRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonResponse> DeletePerson(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePeopleByFio(PeopleDeleteByFioRequest peopleDeleteByFioRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookResponse>> GetBorrowedBooks(Guid personId)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonResponse> TakeBook(Guid personId, Guid bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonResponse> ReturnBook(Guid personId, Guid bookId)
        {
            throw new NotImplementedException();
        }
    }
}