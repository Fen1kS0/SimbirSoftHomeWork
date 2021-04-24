using System.Collections.Generic;
using BookShop.WebApi.Models;

namespace BookShop.WebApi
{
    public class MockDb
    {
        public List<Person> People { get; set; }

        public List<Book> Books { get; set; }
    }
}