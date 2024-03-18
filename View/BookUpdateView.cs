using BookManager.Helpers;
using BookManger.Models;

namespace BookManager.View
{
    public class BookUpdateView
    {
        protected Book Model;

        public BookUpdateView(Book model) 
        { 
            Model = model;
        }
        public void Render()
        {
            ViewHelp.WriteLine("BOOK UPDATE INFORMATION!", ConsoleColor.Green);
            ViewHelp.InputString("Title", Model.Title);
            ViewHelp.InputString("Authors", Model.Authors);
            ViewHelp.InputString("Publisher", Model.Publisher);
            ViewHelp.InputInt("Year", Model.Year);
            ViewHelp.InputInt("Edition", Model.Edition);
            ViewHelp.InputString("ISBN", Model.ISBN);
            ViewHelp.InputString("Description", Model.Description);
            ViewHelp.InputString("Tags", Model.Tags);  
            ViewHelp.InputInt("Rating", Model.Rating);
            ViewHelp.InputBool("Reading [y/n]", Model.Reading);   
            ViewHelp.InputString("File", Model.File);
        }
    }
}