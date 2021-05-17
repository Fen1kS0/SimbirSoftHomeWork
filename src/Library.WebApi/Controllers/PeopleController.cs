using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces.Services;
using Library.Core.Requests.Person;
using Library.Core.Responses.Book;
using Library.Core.Responses.Person;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// 1.2 - 3,
    /// 1.2 - 4
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }
        
        /// <summary>
        /// 1.2 - 4.a
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetAllPeople()
        {
            var response = await _personService.GetAllPeople();

            return Ok(response);
        }

        /// <summary>
        /// 1.2 - 4.c
        /// </summary>
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetAllPeopleByName(string name)
        {
            var response = await _personService.GetAllPeopleByName(name);

            return Ok(response);
        }

        /// <summary>
        /// 1.2 - 5
        /// 1.2.2 - 2
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PersonResponse>> AddPerson(PersonAddRequest personAddRequest)
        {
            var response = await _personService.AddPerson(personAddRequest);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonResponse>> UpdatePerson(Guid id, PersonUpdateRequest personUpdateRequest)
        {
            var response = await _personService.UpdatePerson(id, personUpdateRequest);

            return Ok(response);
        }

        /// <summary>
        /// 1.2 - 6
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonResponse>> DeletePerson(Guid id)
        {
            var response = await _personService.DeletePerson(id);

            return Ok(response);
        }

        [HttpDelete("deletePeopleByFio")]
        public async Task<IActionResult> DeletePeopleByFio(PeopleDeleteByFioRequest peopleDeleteByFioRequest)
        {
            await _personService.DeletePeopleByFio(peopleDeleteByFioRequest);

            return NoContent();
        }
        
        [HttpGet("{personId}/books")]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBorrowedBooks(Guid personId)
        {
            var response = await _personService.GetBorrowedBooks(personId);

            return Ok(response);
        }

        [HttpPost("{personId}/takeBook/{bookId}")]
        public async Task<ActionResult<PersonResponse>> TakeBook(Guid personId, Guid bookId)
        {
            var response = await _personService.TakeBook(personId, bookId);

            return Ok(response);
        }

        [HttpPost("{personId}/returnBook/{bookId}")]
        public async Task<ActionResult<PersonResponse>> ReturnBook(Guid personId, Guid bookId)
        {
            var response = await _personService.ReturnBook(personId, bookId);

            return Ok(response);
        }
    }
}