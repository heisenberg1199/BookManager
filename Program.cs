using BookManager.Controller;
using BookManger.Models;


Console.Clear();

BookController controller = new BookController();

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