using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Entities;
using Library.Core.Exceptions;
using Library.Core.Interfaces.Repositories;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Person;
using Library.Core.Responses.Book;
using Library.Core.Responses.Person;

namespace Library.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IBookRepository _bookRepository;

        public PersonService(IMapper mapper, IPersonRepository personRepository, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<PersonResponse>> GetAllPeople()
        {
            var people = await _personRepository.GetAllPeople();

            return _mapper.Map<IEnumerable<PersonResponse>>(people);
        }

        public async Task<IEnumerable<PersonResponse>> GetAllPeopleByName(string name)
        {
            var people = await _personRepository.GetAllPeople();

            people = people.Where(p => p.FirstName == name);
            
            return _mapper.Map<IEnumerable<PersonResponse>>(people);
        }

        public async Task<PersonResponse> AddPerson(PersonAddRequest personAddRequest)
        {
            var person = _mapper.Map<Person>(personAddRequest);
            
            await _personRepository.AddPerson(person);
            await _personRepository.SaveChanges();

            return _mapper.Map<PersonResponse>(person);
        }

        public async Task<PersonResponse> UpdatePerson(Guid id, PersonUpdateRequest personUpdateRequest)
        {
            var person = await _personRepository.GetPersonById(id);

            if (person == null)
            {
                throw new NotFoundException($"Person with id {id} not found");
            }

            _mapper.Map(personUpdateRequest, person);

            await _personRepository.UpdatePerson(person);
            await _personRepository.SaveChanges();

            return _mapper.Map<PersonResponse>(person);
        }

        public async Task<PersonResponse> DeletePerson(Guid id)
        {
            var person = await _personRepository.GetPersonById(id);

            if (person == null)
            {
                throw new NotFoundException($"Person with id {id} not found");
            }

            await _personRepository.DeletePerson(person);
            await _personRepository.SaveChanges();
            
            return _mapper.Map<PersonResponse>(person);
        }

        public async Task DeletePeopleByFio(PeopleDeleteByFioRequest peopleDeleteByFioRequest)
        {
            var people = await _personRepository.GetAllPeople();

            people = people.Where(p =>
                p.FirstName == peopleDeleteByFioRequest.FirstName 
                && p.LastName == peopleDeleteByFioRequest.LastName
                && p.MiddleName == peopleDeleteByFioRequest.MiddleName);

            foreach (Person person in people)
            {
                await _personRepository.DeletePerson(person);
            }
            
            await _personRepository.SaveChanges();
        }

        public async Task<IEnumerable<BookResponse>> GetBorrowedBooks(Guid personId)
        {
            var person = await _personRepository.GetPersonById(personId);

            if (person == null)
            {
                throw new NotFoundException($"Person with id {personId} not found");
            }

            return _mapper.Map<IEnumerable<BookResponse>>(person.Books);
        }

        public async Task<PersonResponse> TakeBook(Guid personId, Guid bookId)
        {
            var person = await _personRepository.GetPersonById(personId);
            var book = await _bookRepository.GetBookById(bookId);

            if (person == null)
            {
                throw new NotFoundException($"Person with id {personId} not found");
            }

            if (book == null)
            {
                throw new NotFoundException($"Book with id {bookId} not found");
            }
            
            if (person.Books.Contains(book))
            {
                throw new BadRequestException($"Person already take this book");
            }
            
            person.Books.Add(book);
            book.Readers.Add(person);

            await _personRepository.UpdatePerson(person);
            await _bookRepository.UpdateBook(book);
            await _personRepository.SaveChanges();
            
            return _mapper.Map<PersonResponse>(person);
        }

        public async Task<PersonResponse> ReturnBook(Guid personId, Guid bookId)
        {
            var person = await _personRepository.GetPersonById(personId);
            var book = await _bookRepository.GetBookById(bookId);

            if (person == null)
            {
                throw new NotFoundException($"Person with id {personId} not found");
            }

            if (book == null)
            {
                throw new NotFoundException($"Book with id {bookId} not found");
            }

            if (!person.Books.Contains(book))
            {
                throw new BadRequestException($"Person not did not take this book");
            }
            
            person.Books.Remove(book);
            book.Readers.Remove(person);

            await _personRepository.UpdatePerson(person);
            await _bookRepository.UpdateBook(book);
            await _personRepository.SaveChanges();
            
            return _mapper.Map<PersonResponse>(person);
        }
    }
}