using System.Xml.Schema;
using BookManger.Models;
using BookManger.View;

namespace BookManager.DataServices
{
    public class Repository
    {
        protected readonly DataAccess _context;
        public Repository(DataAccess context)
        {
            _context = context;
            _context.Load();
        }

        public List<Book> Books => _context.Books;
        public Book[] Select() => _context.Books.ToArray();
       
        public Book Select(int id)
        {
            foreach (var b in _context.Books)
            {
                if (b.Id == id) return b;
            }
            return null;
        }

        public Book[] Select(string searchString)
        {
            var temp = new List<Book> ();
            var search = searchString.ToLower();
            foreach (var b in _context.Books)
            {
                if (b.Title.ToLower().Contains(search) ||
                    b.Authors.ToLower().Contains(search) ||
                    b.Publisher.ToLower().Contains(search) ||
                    b.Tags.ToLower().Contains(search) ||
                    b.Description.ToLower().Contains(search)
                    )
                {
                    temp.Add(b);   
                }
            }
            return temp.ToArray();
        }

        public void InsertBook(Book book) 
        { 
            int lastIndex = _context.Books.Count() - 1;
            var id = lastIndex < 0 ? 1 : _context.Books[lastIndex].Id + 1;
            book.Id = id;
            _context.Books.Add(book);
        }

        public bool UpdateBook(int id, Book book) 
        { 
            var b = Select(id);
            if (b == null) return false;
            b.Title = book.Title;
            b.Authors = book.Authors;
            b.Publisher = book.Publisher;
            b.Edition = book.Edition;
            b.Year = book.Year;
            b.ISBN = book.ISBN;
            b.Description = book.Description;
            b.Tags = book.Tags;
            b.Rating = book.Rating;
            b.Reading = book.Reading;
            b.File = book.File;
            return true;
        }

        public bool DeleteBook(int id) 
        { 
            var b = Select(id);
            if (b == null) return false;
            _context.Books.Remove(b);
            return true;
        }
    }
}