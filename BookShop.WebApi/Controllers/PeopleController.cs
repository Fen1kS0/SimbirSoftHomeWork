using System.Collections.Generic;
using System.Linq;
using BookShop.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.WebApi.Controllers
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
    }
}