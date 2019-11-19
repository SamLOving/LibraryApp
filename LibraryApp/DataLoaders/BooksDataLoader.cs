using LibraryApp.DTO;
using LibraryApp.Models;
using GreenDonut;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using LibraryApp.Repositories;
using System.Linq;
using LibraryApp.Logging;

namespace LibraryApp.DataLoaders
{
    public class BooksDataLoader : DataLoaderBase<BookRequest, IReadOnlyList<Book>>
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        private readonly BooksRepository _booksRepository;

        public BooksDataLoader(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        protected override Task<IReadOnlyList<Result<IReadOnlyList<Book>>>> FetchAsync(IReadOnlyList<BookRequest> keys, CancellationToken cancellationToken)
        {
            Logger.Info("## Fetching books from reqpository.");
            var booksByRequests = new List<Result<IReadOnlyList<Book>>>();
            foreach (var key in keys)
            {
                booksByRequests.Add(Result<IReadOnlyList<Book>>.Resolve(GetRequestedBooks(key)));
            }

            return Task.FromResult<IReadOnlyList<Result<IReadOnlyList<Book>>>>(booksByRequests);
        }

        private IReadOnlyList<Book> GetRequestedBooks(BookRequest bookRequest)
        {
            if (bookRequest != null)
            {
                var requestedBooks = _booksRepository.Books
                    .Where(book => bookRequest.Ids.Contains(book.Id))
                    .Select(book => book).ToList();
                return requestedBooks;
            }
            return _booksRepository.Books.ToList();
        }
    }
}
