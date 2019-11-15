namespace LibraryApp.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
    }

    public enum Genre
    {
        Mistery = 0,
        Romance = 1,
        Horror = 2,
        Comedy = 3
    }
}
