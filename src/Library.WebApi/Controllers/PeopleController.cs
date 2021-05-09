using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Library.WebApi.Convertors;
using Library.WebApi.Data;
using Library.WebApi.Models;
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
        private readonly MockDb _mockDb;

        public PeopleController(MockDb mockDb)
        {
            _mockDb = mockDb;
        }

        /// <summary>
        /// 1.2 - 4.a
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPeople()
        {
            return Ok(_mockDb.People);
        }
        
        /// <summary>
        /// 1.2 - 4.c
        /// </summary>
        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<Person>> GetAllPeopleByName(string name)
        {
            return Ok(_mockDb.People.Where(p => p.Name == name));
        }

        /// <summary>
        /// 1.2 - 5
        /// 1.2.2 - 2
        /// </summary>
        [HttpPost]
        public ActionResult<IEnumerable<Person>> CreatePeople(Person person)
        {
            _mockDb.People.Add(person);
            
            var options = new JsonSerializerOptions()
            {
                Converters =
                {
                    new PeopleResponseJsonConverter()
                }
            };

            var response = JsonSerializer.Serialize(_mockDb.People, options);

            return Ok(response);
        }

        /// <summary>
        /// 1.2 - 6
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult<Person> DeletePerson(Guid id)
        {
            var person = _mockDb.People.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            _mockDb.People.Remove(person);

            return Ok(person);
        }
    }
}