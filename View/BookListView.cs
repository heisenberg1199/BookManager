using BookManager.Helpers;
using BookManager.Models;

namespace BookManager.View
{
    public class BookListView : ViewBase<Book[]>
    {
        // protected Book[] Model;
        public BookListView(Book[] model) : base(model) { }
      
        public override void Render()
        {
            if (((Book[]) Model).Length == 0)
            {
                ViewHelp.WriteLine("NO BOOK FOUND!", ConsoleColor.Red);
                return;
            }

            ViewHelp.WriteLine("BOOK LIST!", ConsoleColor.Green);

            var model = Model as Book[];
            for (int i = 0; i < model.Length; i++)
            {
                ViewHelp.Write($"[{i + 1}]\t", ConsoleColor.Yellow);
                ViewHelp.WriteLine($"{model[i].Title}\t");
            }
            ViewHelp.WriteLine($"Count {model.Length} item(s)", ConsoleColor.Green);
        }
    }
}