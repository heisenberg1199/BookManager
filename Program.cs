using BookManager.Controller;
using BookManager.DataServices;
using BookManger.Models;


namespace BookManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            DataAccess dataAccess = new DataAccess();
            BookController controller = new BookController(dataAccess);
            while (true)
            {
                Console.WriteLine("Request>> ");
                string request = Console.ReadLine() ?? "";
                switch (request.ToLower())
                {
                    case "single":
                        controller.Single(1);
                        break;
                    case "create":
                        controller.Create();
                        break;
                    case "update":
                        controller.Update(1);
                        break;
                    case "list":
                        controller.List();
                        break;
                    default:
                        Console.WriteLine("Unknow command");
                        break;
                }
            }
        }
    }
}


