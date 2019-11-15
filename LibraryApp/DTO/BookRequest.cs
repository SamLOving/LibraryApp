using LibraryApp.Models;
using System;
using System.Collections.Generic;

namespace LibraryApp.DTO
{
    [Serializable]
    public class BookRequest : IEquatable<BookRequest>
    {
        public IEnumerable<string> Ids { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public bool Equals(BookRequest other)
        {
            throw new NotImplementedException();
        }
    }
}
