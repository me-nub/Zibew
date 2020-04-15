using System;

namespace replaceString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String before replace");
            string toBeReplaced = "UserName";
            Console.WriteLine("Hello,{0} how are you",toBeReplaced);
            Console.WriteLine("Enter the user name:-");
            string name = Console.ReadLine();
            toBeReplaced = "";
            toBeReplaced += name;
            Console.WriteLine("Hello,{0} how are you",toBeReplaced);
        }
    }
}
