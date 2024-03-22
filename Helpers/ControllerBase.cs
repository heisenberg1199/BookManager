using BookManager.Helpers;
using BookManager.Models;

namespace BookManager
{
    public class ControllerBase
    {
        public virtual void Render(ViewBase view) { view.Render(); }
        public virtual void Render<T> (ViewBase<T> view, string path = "")
        {
            if (!String.IsNullOrEmpty(path))
            {
                view.WriteToFileJson(path);
                return;
            }
            view.Render();
        }
        public virtual void Render(Message message) => Render(new MessageView(message));
        public virtual void Success(string text, string label = "SUCCESS")
            => Render(new Message {Type = MessageType.Success, Text = text, Label = label});
        public virtual void Info(string text, string label = "INFORMATION")
            => Render(new Message {Type = MessageType.Information, Text = text, Label = label});
        public virtual void Error(string text, string label = "ERROR")
            => Render(new Message {Type = MessageType.Error, Text = text, Label = label});
        public virtual void Confirm(string text, string route, string label = "CONFIRMATION")
            => Render(new Message {Type = MessageType.Confirmation, Text = text, Label = label, BackRoute = route});
    }
}