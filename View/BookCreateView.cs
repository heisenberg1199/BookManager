using BookManager.Helpers;
using BookManager.Models;

namespace BookManager.View
{
    public class BookCreateView : ViewBase
    {
        public BookCreateView() { }

        public override void Render()
        {
            ViewHelp.WriteLine("CREATE A NEW BOOK!", ConsoleColor.Green);
            
            var title = ViewHelp.InputString("Title", "");
            var author = ViewHelp.InputString("Authors", "");
            var publisher = ViewHelp.InputString("Publisher", "");
            var year = ViewHelp.InputInt("Year", 2024);
            var edition = ViewHelp.InputInt("Edition", 1);
            var isbn = ViewHelp.InputString("ISBN", "");
            var description = ViewHelp.InputString("Description", "");
            var tags = ViewHelp.InputString("Tags", "");
            var rating = ViewHelp.InputInt("Rating", 1);
            var reading = ViewHelp.InputBool("Reading [y/n]", false);
            var file = ViewHelp.InputString("File", "");

            var request = $"do create ? " + 
                    $"title = {title}" + 
                    $" & author = {author}" +
                    $" & publisher = {publisher}" +
                    $" & year = {year}" +
                    $" & edition = {edition}" +
                    $" & isbn = {isbn}" +
                    $" & description = {description}" +
                    $" & tags = {tags}" +
                    $" & rating = {rating}" +
                    $" & reading = {reading}" + 
                    $" & file = {file}" ;
            
            Router.Forward(request);
        }
    }
}