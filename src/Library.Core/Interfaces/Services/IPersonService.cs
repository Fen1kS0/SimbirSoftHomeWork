using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Requests.Person;
using Library.Core.Responses.Book;
using Library.Core.Responses.Person;

namespace Library.Core.Interfaces.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonResponse>> GetAllPeople();
        
        Task<IEnumerable<PersonResponse>> GetAllPeopleByName(string name);

        Task<PersonResponse> AddPerson(PersonAddRequest personAddRequest);

        Task<PersonResponse> UpdatePerson(Guid id, PersonUpdateRequest personUpdateRequest);

        Task<PersonResponse> DeletePerson(Guid id);

        Task DeletePeopleByFio(PeopleDeleteByFioRequest peopleDeleteByFioRequest);

        Task<IEnumerable<BookResponse>> GetBorrowedBooks(Guid personId);

        Task<PersonResponse> TakeBook(Guid personId, Guid bookId);

        Task<PersonResponse> ReturnBook(Guid personId, Guid bookId);
    }
}