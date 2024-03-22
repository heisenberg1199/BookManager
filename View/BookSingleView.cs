using BookManager.Helpers;
using BookManager.Models;
using BookManager;

namespace BookManger.View
{
    public class BookSingleView : ViewBase<Book>
    {
        // protected Book Model;
        public BookSingleView(Book model) : base(model) { }
      
        public override void Render()
        {
            if (Model == null)
            {
                ViewHelp.WriteLine("NO BOOK FOUND!", ConsoleColor.Red);
                return;
            }

            ViewHelp.WriteLine("BOOK DETAIL INFORMATION:", ConsoleColor.Green);

            var model = Model as Book;
            Console.WriteLine($"Title:      {model.Title}");
            Console.WriteLine($"Authors:    {model.Authors}");
            Console.WriteLine($"Publisher:  {model.Publisher}");
            Console.WriteLine($"Year:       {model.Year}");
            Console.WriteLine($"Edition:    {model.Edition}");
            Console.WriteLine($"ISBN:       {model.ISBN}");
            Console.WriteLine($"Description:{model.Description}");
            Console.WriteLine($"Tags:       {model.Tags}");
            Console.WriteLine($"Rating:     {model.Rating}");
            Console.WriteLine($"Reading:    {model.Reading}");
            Console.WriteLine($"File:       {model.File}");
            Console.WriteLine($"File Name:  {model.FileName}");
        }
    }
}
