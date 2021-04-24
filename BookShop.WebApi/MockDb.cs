using System;
using System.Collections.Generic;
using BookShop.WebApi.Models;

namespace BookShop.WebApi
{
    public class MockDb
    {
        public MockDb()
        {
            InitialDb();
        }
        
        public List<Person> People { get; set; }

        public List<Book> Books { get; set; }

        private void InitialDb()
        {
            var people = new List<Person>()
            {
                new Person()
                {
                    Name = "Alex",
                    Surname = "Ivanov",
                    Patronymic = "Evgenich",
                    BirthDate = new DateTime(1980, 12, 30)
                }
            };
            
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "Forest of fireflies",
                    AuthorId = people[0].Id,
                    Author = people[0],
                    Genre = "Fantasy"
                }
            };

            People = people;
            Books = books;
        }
    }
}