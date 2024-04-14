using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzpitalAPP.Services
{
    public abstract class UserCommunicationBase : IUserCommunication
    {
        public abstract void Task();
        protected void WritelineColor(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor = default)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        protected string GetInputFromUser(string comment)
        {
            WritelineColor(comment, ConsoleColor.DarkYellow);
            return Console.ReadLine()!;
        }

        protected void EmptyInputWarning(ref string? input, string inputName)
        {
            while (String.IsNullOrEmpty(input))
            {
                WritelineColor($"This input can not be empty.", ConsoleColor.Red);
                input = GetInputFromUser($"{inputName}:");
            }
        }
    }
}
