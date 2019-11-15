using Bogus;
using LibraryApp.Models;
using System;
using System.Collections.Generic;

namespace LibraryApp
{
    public class BooksRepository
    {
        public ICollection<Book> Books { get; internal set; }

        private Faker faker;

        public BooksRepository()
        {
            Books = new List<Book>();
            faker = new Faker();
        }

        public void PopulateBooks()
        {
            var numberOfbooks = 5000;
            var random = new Random();
            for (var i = 0; i < numberOfbooks; i++)
            {
                Books.Add(new Book
                {
                    Id = $"ID-{i}",
                    Author = $"{faker.Name.FirstName()} {faker.Name.LastName()}",
                    Genre = GetGenre(random),
                    Title = faker.Lorem.Sentence(),
                });
            }
        }

        private Genre GetGenre(Random random)
        {
            var genre = random.Next(0, 4);
            switch (genre)
            {
                case 0:
                    return Genre.Mistery;
                case 1:
                    return Genre.Romance;
                case 2:
                    return Genre.Horror;
                case 3:
                    return Genre.Comedy;
                default:
                    return Genre.Horror;
            };
        }
    }
}
