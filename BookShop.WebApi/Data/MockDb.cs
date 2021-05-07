using System;
using System.Collections.Generic;
using BookShop.WebApi.Models;

namespace BookShop.WebApi.Data
{
    public class MockDb
    {
        public MockDb()
        {
            InitialDb();
        }
        
        public List<Person> People { get; set; }

        public List<Book> Books { get; set; }

        public List<OrderBook> OrderBooks { get; set; }

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
                },
                new Person()
                {
                    Name = "Geana",
                    Surname = "Kalikin",
                    Patronymic = "Avraamovich",
                    BirthDate = new DateTime(1995, 05, 12)
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

            var orderBooks = new List<OrderBook>();

            People = people;
            Books = books;
            OrderBooks = orderBooks;
        }
    }
}