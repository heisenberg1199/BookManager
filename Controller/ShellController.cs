using System.Diagnostics;
using BookManager.DataServices;
using BookManager.Models;
namespace BookManager.Controller
{
    public class ShellController : ControllerBase
    {
        protected Repository Repository;
        public ShellController(DataAccess context)
        { 
            Repository = new Repository(context);
        }
        public void Shell(string folder, string ext = "*.pdf")
        {
            if (!Directory.Exists(folder))
            {
                Error("Folder not found!");
                return;
            }
            var files = Directory.GetFiles(folder, ext ?? "*.pdf", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                Repository.InsertBook(new Book { Title = Path.GetFileNameWithoutExtension(f), File = f});
            }
            if (files.Length > 0)
            {
                Success($"{files.Length} item(s) found!");
                return;
            }
            Info("Sorry, no item found!");
        }
        public void Read(int id)
        {
            var book = Repository.Select(id);
            if (book == null)
            {
                Error("Book not found!");
                return;
            }
            if (!File.Exists(book.File))
            {
                Error("File not found!");
                return;
            }
            Process.Start(book.File);
            Success($"You are reading the book '{book.Title}'");
        }
    }
}