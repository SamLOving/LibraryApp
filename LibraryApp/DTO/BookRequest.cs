using System;
using System.Collections.Generic;

namespace LibraryApp.DTO
{
    [Serializable]
    public class BookRequest : IEquatable<BookRequest>
    {
        public IEnumerable<string> Id { get; set; }
        public IEnumerable<string> Genre { get; set; }

        public bool Equals(BookRequest other)
        {
            throw new NotImplementedException();
        }
    }
}
