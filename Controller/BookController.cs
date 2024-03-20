
using BookManager.DataServices;
using BookManager.View;
using BookManger.Models;
using BookManger.View;

namespace BookManager.Controller
{
    public class BookController
    {
        protected Repository Repository;

        public BookController(DataAccess context)
        {
            Repository = new Repository(context);
        }

        public void Single(int id)
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
            BookSingleView view = new BookSingleView(model);
            view.Render();
        }
        public void Create()
        {
            BookCreateView view = new BookCreateView();
            view.Render();
        }
        public void Update(int id)
        {
            var model =  Repository.Select(id);
            BookUpdateView view = new BookUpdateView(model);
            view.Render();
        }
        public void List()
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
            BookListView view = new BookListView(model);
            view.Render();
        }
    }
}

