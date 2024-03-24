
using BookManager.DataServices;
using BookManager.View;
using BookManager.Models;
using BookManger.View;
using Microsoft.VisualBasic;

namespace BookManager.Controller
{
    public class BookController : ControllerBase
    {
        protected Repository Repository;

        public BookController(DataAccess context)
        {
            Repository = new Repository(context);
        }

        public void Single(int id, string path = "")
        {
            // Book model = new Book() {
            //     Id = 1,
            //     Authors = "Mark J Price",
            //     Title = "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals - Eighth Edition: Start building websites and services with ASP.NET Core 8, Blazor, and EF Core 8",
            //     Publisher = "Packt Publishing",
            //     Year = 2023,
            //     Edition = 8,
            //     ISBN = "978-1837635870",
            //     Tags = "C#, .NET, Blazor, EF Core",
            //     Description = "An accessible guide for beginner-to-intermediate programmers to the concepts, real-world applications, and latest features of C# 12 and .NET 8, with hands-on exercises using Visual Studio 2022 and Visual Studio Code.",
            //     Rating = 5,
            //     Reading = true
            // };
            var model = Repository.Select(id);
            // BookSingleView view = new BookSingleView(model);
            // if(!String.IsNullOrEmpty(path))
            // {
            //     view.WriteToFileJson(path);
            //     return;
            // }
            // view.Render();
            Render(new BookSingleView(model), path);
        }
        public void Create(Book book = null)
        {
            // BookCreateView view = new BookCreateView();
            // view.Render();
            if (book == null)
            {
                Render(new BookCreateView());
                return;
            }
            Repository.InsertBook(book);
            Success("Book created!");
        }
        public void Update(int id, Book book = null)
        {
            // BookUpdateView view = new BookUpdateView(model);
            // view.Render();
            if (book == null)
            {
                var model =  Repository.Select(id);
                Render(new BookUpdateView(model));
                return;
            }
            Repository.UpdateBook(id, book);
            Success("Book updated!");
        }
        public void List(string path = "")
        {
            // Book[] model = {
            //     new Book() { Title = "Title 1", Authors = "Authors 1"},
            //     new Book() { Title = "Title 2", Authors = "Authors 2"},
            //     new Book() { Title = "Title 3", Authors = "Authors 3"},
            //     new Book() { Title = "Title 4", Authors = "Authors 4"},
            //     new Book() { Title = "Title 5", Authors = "Authors 5"},
            //     new Book() { Title = "Title 6", Authors = "Authors 6"},
            //     new Book() { Title = "Title 7", Authors = "Authors 7"},
            // };
            var model = Repository.Select();
            // BookListView view = new BookListView(model);
            // if (!String.IsNullOrEmpty(path))
            // {
            //     view.WriteToFileJson(path);
            //     return;
            // }
            // view.Render();
            Render(new BookListView(model), path);
        }
        public void Filter(string key)
        {
            var model = Repository.Select(key);
            if (model.Length == 0)
                Info("No match book found!");
            else
                Render(new BookListView(model));
        }
        public void Delete(int id, bool deleteSucess = false)
        {
            if (deleteSucess == false)
            {
                var model = Repository.Select(id);
                Confirm($"Do you want to delete this book ({model.Title}) ?", $"do delete ? id = {model.Id}");
            }
            Repository.DeleteBook(id);
            Success("Book deleted!");
        }
    }
}

