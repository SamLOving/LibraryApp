using LibraryApp.DTO;
using LibraryApp.Models;
using LibraryApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Controllers
{
    [Produces("application/json")]
    [Route("api/books")]
    public class BookController
    {
        private readonly BooksRepository _booksRepository;

        public BookController(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpPost]
        public IActionResult GetBooks([FromBody] BookRequest bookRequest)
        {
            var books = GetRequestedBooks(bookRequest, _booksRepository.Books);
            return new OkObjectResult(books);
        }

        private ICollection<Book> GetRequestedBooks(BookRequest bookRequest, ICollection<Book> books)
        {
            if (bookRequest != null)
            {
                return books
                    .Where(book => bookRequest.Ids.Contains(book.Id) && bookRequest.Genres.Contains(book.Genre))
                    .Select(book => book).ToList();
            }
            return books;
        }
    }
}
