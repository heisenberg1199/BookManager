using BookManager.Controller;
using BookManager.DataServices;
using BookManager.Helpers;
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

            Router.Instance.Register("about", About);
            Router.Instance.Register("help", Help);

            while (true)
            {
                ViewHelp.Write("Request >>> ", ConsoleColor.Green);
                string request = Console.ReadLine() ?? "";
                /* switch (request.ToLower())
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
                } */
                Router.Instance.Forward(request);
                Console.WriteLine();
            }
        }
        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("PROJECT BOOK MANAGER TO PRACTICE C# CODING SKILL version 1.0.0", ConsoleColor.Green);
            ViewHelp.WriteLine("by heisenberg", ConsoleColor.Magenta);
        }
        private static void Help(Parameter parameter)
        {
            if (parameter == null)
            {
                ViewHelp.WriteLine("SUPPORTED COMMANDS:", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
                ViewHelp.WriteLine("type: help ? cmd = <command> to get command details", ConsoleColor.Cyan);
                return;
            }
            Console.BackgroundColor = ConsoleColor.Blue;
            var command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }
    }
}


