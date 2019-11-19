using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using LibraryApp.Logging;
using LibraryApp.Models;
using LibraryApp.Repositories;

namespace LibraryApp.DataLoaders
{
    public class BooksByIdsDataLoader : DataLoaderBase<string, Book>
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        private readonly BooksRepository _booksRepository;

        public BooksByIdsDataLoader(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        protected override Task<IReadOnlyList<Result<Book>>> FetchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            Logger.Info("## Fetching books from repository using BooksByIdsDataLoader.");

            var requestedBooks = _booksRepository.Books
                .Where(b => keys.Contains(b.Id))
                .Select(b => Result<Book>.Resolve(b))
                .ToList();

            return Task.FromResult<IReadOnlyList<Result<Book>>>(requestedBooks);
        }
    }
}
