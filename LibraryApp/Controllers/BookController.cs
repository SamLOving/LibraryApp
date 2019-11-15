using LibraryApp.DTO;
using LibraryApp.Models;
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

        [HttpGet]
        public IActionResult GetBooks([FromBody] BookRequest bookRequest)
        {
            var books = GetRequestedBooks(bookRequest, _booksRepository.Books);
            return new OkObjectResult(books);
        }

        private ICollection<Book> GetRequestedBooks(BookRequest bookRequest, ICollection<Book> books)
        {
            ICollection<Book> requestedBooks = new List<Book>();
            if (bookRequest != null)
            {
                var ids = bookRequest.Id.Select(id => id);
                requestedBooks = books.Where(book => ids.Contains(book.Id)).Select(book => book).ToList();
            }
            else
            {
                requestedBooks = books;
            }
            return requestedBooks;
        }
    }
}
