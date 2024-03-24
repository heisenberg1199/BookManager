using BookManager.Controller;
using BookManager.DataServices;
using BookManager.Helpers;
using BookManager.Models;


namespace BookManager
{
    public partial class Program
    {
        public static void Config()
        {
            DataAccess dataAccess = new DataAccess();
            BookController controller = new BookController(dataAccess);
            ShellController shellController = new ShellController(dataAccess);

            Router r = Router.Instance;

            r.Register(route: "single", action: p => controller.Single(Extension.ToInt(p["id"])), help: "[single ? id = <value>]. Book Information by Id!");
            r.Register(route: "create", action: p => controller.Create(), help:"[create]. Create a new book!");
            r.Register(route: "do create", action: p => controller.Create(toBook(p)));
            r.Register(route: "update", action: p => controller.Update(Extension.ToInt(p["id"])), help:"[update ? id = <value>]. Update book by Id");
            r.Register(route: "do update", action: p => controller.Update(Extension.ToInt(p["id"]), toBook(p)));
            r.Register(route: "list", action: p => controller.List(), help:"[list]. Get book list!");
            
            r.Register(route: "filter", action: p => controller.Filter(p["key"]), help:"[filter ? key = <value>]. Filter book by key (ex: title, author, tags, etc.)");
            r.Register(route: "do delete", action: p => controller.Delete(Extension.ToInt(p["id"]), false));
            
            r.Register(route: "single file", action: p => controller.Single(Extension.ToInt(p["id"]), p["path"]));
            r.Register(route: "list file", action: p => controller.List(p["path"]));

            r.Register(route: "add shell", action: p => shellController.Shell(p["path"], p["ext"]), help:"[add shell ? path = <path>]. Find book from folder");
            r.Register(route: "read", action: p => shellController.Read(Extension.ToInt(p["id"])));

            r.Register("about", About);
            r.Register("help", Help);

            Book toBook(Parameter p)
            {
                var b = new Book();
                if (p.ContainsKey("id")) b.Id = Extension.ToInt(p["id"]);
                if (p.ContainsKey("title")) b.Title = p["title"];
                if (p.ContainsKey("author")) b.Authors = p["author"];
                if (p.ContainsKey("publisher")) b.Publisher = p["publisher"];
                if (p.ContainsKey("year")) b.Year = Extension.ToInt(p["year"]);
                if (p.ContainsKey("edition")) b.Edition = Extension.ToInt(p["edition"]);
                if (p.ContainsKey("description")) b.Description = p["description"];
                if (p.ContainsKey("tags")) b.Tags = p["tags"];
                if (p.ContainsKey("rating")) b.Rating = Extension.ToInt(p["rating"]);
                if (p.ContainsKey("reading")) b.Reading = Extension.ToBool(p["reading"]);
                if (p.ContainsKey("file")) b.File = p["file"];
                return b;
            }
        }
    }
}