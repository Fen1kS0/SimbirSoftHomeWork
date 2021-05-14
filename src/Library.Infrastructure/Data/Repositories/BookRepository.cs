using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces.Repositories;
using Library.Core.Models;

namespace Library.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}