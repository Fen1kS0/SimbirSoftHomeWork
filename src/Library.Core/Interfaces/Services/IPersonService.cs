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
        
        Task<PersonResponse> GetAllPeopleByName(string name);

        Task<PersonResponse> AddPerson(PersonAddRequest personAddRequest);

        Task<PersonResponse> UpdatePerson(PersonUpdateRequest personUpdateRequest);

        Task<PersonResponse> DeletePerson(Guid id);

        Task DeletePeopleByFio(PeopleDeleteByFioRequest peopleDeleteByFioRequest);

        Task<BookResponse> GetBorrowedBooks(Guid personId);

        Task<PersonResponse> TakeBook(Guid personId, Guid bookId);

        Task<PersonResponse> ReturnBook(Guid personId, Guid bookId);
    }
}