using CMDMenu;

namespace Lesson12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CMDHandler cmd = new CMDHandler(generateHelpCommands:false);
            cmd.Description = "Enter login, password and confirm password separated by comma \',\', or type quit to exit";
            cmd.DefaultAction = input =>
            {
                string[] inArr = input.Split(",").Select(e => e.Trim()).ToArray();
                if (inArr.Length == 3)
                {
                    if (Account.Register(inArr[0], inArr[1], inArr[2]))
                    {
                        Console.WriteLine("Valid");
                    }
                }
                else throw new MessageException($"You must enter 3 parameters (Received: {inArr.Length})");
                return true;
            };
            cmd.Run(showDescriptionAtBeginning: true);
        }
    }
}