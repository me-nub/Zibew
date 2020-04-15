using System;

namespace leapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the year you want to check is leap year or not");
            int year = int.Parse(Console.ReadLine());
            bool flag = true;
            if(year<1000){
                Console.WriteLine("Year must be 4 digits.");
            }
            else{
                if(year%100==0){
                    if(year%400==0){
                        flag = true;
                    }  
                    else{
                        flag = false;
                    }
                }
                else if(year%4==0){
                        flag = true;
                    }
                else{
                    flag = false;
                }
                if(flag){
                    Console.WriteLine("Entered year is a leap year ");
                }
                else{
                    Console.WriteLine("Entered year is not leap year ");
                }
            }

            
        }
    }
}
