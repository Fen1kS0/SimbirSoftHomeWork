using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Models;

namespace Library.Core.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book> GetBookById(Guid id);

        Task AddBook(Book book);

        Task UpdateBook(Book book);

        Task DeleteBook(Book book);
    }
}