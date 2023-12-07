using MonefyProjects.Models;
using System.Windows.Controls;

namespace MonefyProjects.Messages
{
    public class TextMessage : IData
    {
        public string Message { get; set; }

        public TextMessage(string message)
        {
            Message = message;
        }
    }

}
