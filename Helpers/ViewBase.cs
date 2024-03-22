using BookManager.Helpers;
using System.Text.Json;

namespace BookManager
{
    public class ViewBase
    {
        protected Router Router = Router.Instance;
        public ViewBase() { }
        public virtual void Render() { }
    }

    public class ViewBase<T> : ViewBase
    {
        protected T Model;
        public ViewBase(T model) => Model = model;
        public virtual void WriteToFileJson(string path)
        {
            ViewHelp.WriteLine($"Saving data to file {path}", ConsoleColor.Green);
            string jsonString = JsonSerializer.Serialize(Model);
            File.WriteAllText(path, jsonString);
            ViewHelp.WriteLine("Done!", ConsoleColor.Cyan);
        }
    }
}