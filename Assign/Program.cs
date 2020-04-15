using System;

namespace Assign
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            Console.WriteLine("Enter the program number you wish to execute :");
            int num = Convert.ToInt32(Console.ReadLine());
            if(num == 1){
                obj.replaceString();
            }
        }
    }
}
