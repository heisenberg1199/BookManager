using BookManager.Helpers;
using BookManger.Models;

namespace BookManager.View
{
    public class BookListView
    {
        protected Book[] Model;
        public BookListView(Book[] model)
        {
            Model = model;
        }
        public void Render()
        {
            if (Model.Length == 0)
            {
                ViewHelp.WriteLine("NO BOOK FOUND!", ConsoleColor.Red);
            }
            ViewHelp.WriteLine("BOOK LIST!", ConsoleColor.Green);
            for (int i = 0; i < Model.Length; i++)
            {
                ViewHelp.Write($"[{i + 1}]\t", ConsoleColor.Yellow);
                ViewHelp.WriteLine($"{Model[i].Title}\t");
            }
        }
    }
}