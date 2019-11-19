using HotChocolate;
using LibraryApp.DataLoaders;
using LibraryApp.DTO;
using LibraryApp.Logging;
using LibraryApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApp.Resolvers
{
    public class BooksResolver
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public async Task<IReadOnlyCollection<Book>> GetBooksAsync(
            IEnumerable<string> ids, 
            IEnumerable<Genre> genres,
            [DataLoader] BooksDataLoader booksDataLoader, 
            CancellationToken cancellationToken)
        {
            Logger.Info("## Resolving books");

            var bookRequest = new BookRequest()
            {
                Ids = ids,
                Genres = genres
            };

            var booksTask = booksDataLoader.LoadAsync(new List<BookRequest> { bookRequest }, cancellationToken);

            return await booksTask.ContinueWith(t =>
            {
                IReadOnlyList<IReadOnlyList<Book>> books = t.Result;
                return books.ElementAt(0);
            }, cancellationToken);
        }
    }
}
