using System;
using System.Collections.Generic;
using Library.Core.Models;
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
        /// <summary>
        /// 1.2 - 4.a
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPeople()
        {
            return Ok();
        }
        
        /// <summary>
        /// 1.2 - 4.c
        /// </summary>
        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<Person>> GetAllPeopleByName(string name)
        {
            return Ok();
        }

        /// <summary>
        /// 1.2 - 5
        /// 1.2.2 - 2
        /// </summary>
        [HttpPost]
        public ActionResult<IEnumerable<Person>> CreatePeople(Person person)
        {
            return Ok();
        }

        /// <summary>
        /// 1.2 - 6
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult<Person> DeletePerson(Guid id)
        {
            return Ok();
        }
    }
}