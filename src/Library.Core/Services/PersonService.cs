using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Entities;
using Library.Core.Exceptions;
using Library.Core.General;
using Library.Core.Interfaces.Repositories;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Person;
using Library.Core.Responses.Book;
using Library.Core.Responses.Person;
using Library.Core.UoW;

namespace Library.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PersonResponse>> GetAllPeople()
        {
            var people = await _unitOfWork.GetRepository<IPersonRepository>()
                .GetAllPeople(include: IncludeEntities.IncludeAllForPerson);

            return _mapper.Map<IEnumerable<PersonResponse>>(people);
        }

        public async Task<IEnumerable<PersonResponse>> GetAllPeopleByName(string name)
        {
            var people = await _unitOfWork.GetRepository<IPersonRepository>()
                .GetAllPeople(
                    predicate: p => p.FirstName == name,
                    include: IncludeEntities.IncludeAllForPerson
                    );

            return _mapper.Map<IEnumerable<PersonResponse>>(people);
        }

        public async Task<PersonResponse> AddPerson(PersonAddRequest personAddRequest)
        {
            var person = _mapper.Map<Person>(personAddRequest);
            
            await _unitOfWork.GetRepository<IPersonRepository>().AddPerson(person);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PersonResponse>(person);
        }

        public async Task<PersonResponse> UpdatePerson(Guid id, PersonUpdateRequest personUpdateRequest)
        {
            var person = await _unitOfWork.GetRepository<IPersonRepository>()
                .GetPersonById(id, disableTracking: false);

            if (person == null)
            {
                throw new NotFoundException($"Person with id {id} not found");
            }

            _mapper.Map(personUpdateRequest, person);

            await _unitOfWork.GetRepository<IPersonRepository>().UpdatePerson(person);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PersonResponse>(person);
        }

        public async Task<PersonResponse> DeletePerson(Guid id)
        {
            var person = await _unitOfWork.GetRepository<IPersonRepository>().GetPersonById(id);

            if (person == null)
            {
                throw new NotFoundException($"Person with id {id} not found");
            }

            await _unitOfWork.GetRepository<IPersonRepository>().DeletePerson(person);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<PersonResponse>(person);
        }

        public async Task DeletePeopleByFio(PeopleDeleteByFioRequest peopleDeleteByFioRequest)
        {
            var people = await _unitOfWork.GetRepository<IPersonRepository>()
                .GetAllPeople(
                    predicate: p =>
                        p.FirstName == peopleDeleteByFioRequest.FirstName 
                        && p.LastName == peopleDeleteByFioRequest.LastName
                        && p.MiddleName == peopleDeleteByFioRequest.MiddleName
                        );

            foreach (Person person in people)
            {
                await _unitOfWork.GetRepository<IPersonRepository>().DeletePerson(person);
            }
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookResponse>> GetBorrowedBooks(Guid personId)
        {
            var person = await _unitOfWork.GetRepository<IPersonRepository>()
                .GetPersonById(personId, IncludeEntities.IncludeAllForPerson);

            if (person == null)
            {
                throw new NotFoundException($"Person with id {personId} not found");
            }

            return _mapper.Map<IEnumerable<BookResponse>>(person.Books);
        }

        public async Task<PersonResponse> TakeBook(Guid personId, Guid bookId)
        {
            var person = await _unitOfWork.GetRepository<IPersonRepository>()
                .GetPersonById(personId, disableTracking: false);
            var book = await _unitOfWork.GetRepository<IBookRepository>()
                .GetBookById(bookId, disableTracking: false);

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

            await _unitOfWork.GetRepository<IPersonRepository>().UpdatePerson(person);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<PersonResponse>(person);
        }

        public async Task<PersonResponse> ReturnBook(Guid personId, Guid bookId)
        {
            var person = await _unitOfWork.GetRepository<IPersonRepository>()
                .GetPersonById(personId, disableTracking: false);
            var book = await _unitOfWork.GetRepository<IBookRepository>()
                .GetBookById(bookId, disableTracking: false);

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

            await _unitOfWork.GetRepository<IPersonRepository>().UpdatePerson(person);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<PersonResponse>(person);
        }
    }
}