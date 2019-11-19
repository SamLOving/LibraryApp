using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.DTO
{
    [Serializable]
    public class BookRequest : IEquatable<BookRequest>
    {
        public IEnumerable<string> Ids { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public bool Equals(BookRequest other)
        {
            if (other == null || this == null) return false;
            if (other.Ids.Count() != Ids.Count() || other.Genres.Count() != Genres.Count()) return false;

            var areIdsEqual = Ids.Except(other.Ids).Count() == 0;
            var areGenresEqual = Genres.Except(other.Genres).Count() == 0;

            return areIdsEqual && areGenresEqual;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int hashingBase = (int)2166136261;
                const int hashingMultiplier = 16777619;

                int hash = hashingBase;
                hash = (hash * hashingMultiplier) ^ (Ids != null ? string.Join("", Ids).GetHashCode() : 0);
                hash = (hash * hashingMultiplier) ^ (Genres != null ? string.Join("", Genres).GetHashCode() : 0);

                return hash;
            }
        }
    }
}
