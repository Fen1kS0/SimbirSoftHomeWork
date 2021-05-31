using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Enums;
using Library.Core.Responses.Author;

namespace Library.Core.Interfaces.Services
{
    public interface IFindAuthorsService
    {
        Task<IEnumerable<AuthorWithoutBooksResponse>> GetAuthorsByRealiseDateBook(int year, SortMode sortMode);
        
        Task<IEnumerable<AuthorWithoutBooksResponse>> FindAuthorBySubstringBookName(string substring);
    }
}