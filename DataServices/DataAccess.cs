using BookManager.Models;

namespace BookManager.DataServices
{
    public class DataAccess
    {
        public List<Book> Books { get; set; }
        
        public void Load()
        {
            Books = new List<Book>
            {
                new Book() { Id = 1, Title = "A new book 1" },
                new Book() { Id = 2, Title = "A new book 2" },
                new Book() { Id = 3, Title = "A new book 3" },
                new Book() { Id = 4, Title = "A new book 4" },
                new Book() { Id = 5, Title = "A new book 5" },
                new Book() { Id = 6, Title = "A new book 6" },
                new Book() { Id = 7, Title = "A new book 7" },
                new Book() { Id = 8, Title = "A new book 8" },
                new Book() { Id = 9, Title = "A new book 9" },
                new Book() { Id = 10, Title = "A new book 10" },
            };
        }
        public void SaveChanges() { }
    }
}
