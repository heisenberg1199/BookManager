using BookManager.Helpers;
using BookManager.Models;

namespace BookManager.View
{
    public class BookUpdateView : ViewBase<Book>
    {
        // protected Book Model;
        public BookUpdateView(Book model) : base(model) { }
       
        public override void Render()
        {
            ViewHelp.WriteLine("BOOK UPDATE INFORMATION!", ConsoleColor.Green);

            var model = Model as Book;
            var title = ViewHelp.InputString("Title", model.Title);
            var author = ViewHelp.InputString("Authors", model.Authors);
            var publisher = ViewHelp.InputString("Publisher", model.Publisher);
            var year = ViewHelp.InputInt("Year", model.Year);
            var edition = ViewHelp.InputInt("Edition", model.Edition);
            var isbn = ViewHelp.InputString("ISBN", model.ISBN);
            var description = ViewHelp.InputString("Description", model.Description);
            var tags = ViewHelp.InputString("Tags", model.Tags);  
            var rating = ViewHelp.InputInt("Rating", model.Rating);
            var reading = ViewHelp.InputBool("Reading [y/n]", model.Reading);   
            var file = ViewHelp.InputString("File", model.File);

            var request = $"do update ? " +
                    $"id = {Model.Id}" +
                    $" & title = {title}" +
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