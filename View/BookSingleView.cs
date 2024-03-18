using System.Drawing;
using BookManager.Helpers;
using BookManger.Models;

namespace BookManger.View
{
    public class BookSingleView
    {
        protected Book Model;

        public BookSingleView(Book model)
        {
            Model = model;
        }

        public void Render()
        {
            if (Model == null)
            {
                ViewHelp.WriteLine("NO BOOK FOUND!", ConsoleColor.Red);
                return;
            }

            ViewHelp.WriteLine("BOOK DETAIL INFORMATION:", ConsoleColor.Green);

            Console.WriteLine($"Title:      {Model.Title}");
            Console.WriteLine($"Authors:    {Model.Authors}");
            Console.WriteLine($"Publisher:  {Model.Publisher}");
            Console.WriteLine($"Year:       {Model.Year}");
            Console.WriteLine($"Edition:    {Model.Edition}");
            Console.WriteLine($"ISBN:       {Model.ISBN}");
            Console.WriteLine($"Description:{Model.Description}");
            Console.WriteLine($"Tags:       {Model.Tags}");
            Console.WriteLine($"Rating:     {Model.Rating}");
            Console.WriteLine($"Reading:    {Model.Reading}");
            Console.WriteLine($"File:       {Model.File}");
            Console.WriteLine($"File Name:  {Model.FileName}");
        }
    }
}
