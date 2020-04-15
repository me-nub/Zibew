using System;

namespace harmonicNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the harmonic value :");
            int harmonicValue = int.Parse(Console.ReadLine());
            double temp=0;
            double finalValue=0;
            for(int i=1;i<=harmonicValue;i++){
                Console.Write("{0}/{1} = ",1,i);
                temp = (float)1/i;
                Console.WriteLine(Math.Round(temp,6,MidpointRounding.ToEven));
                finalValue += temp;
            }

            Console.WriteLine("The Nth harmonic value is {1} ",finalValue, Math.Round(finalValue,2,MidpointRounding.ToEven));
        }
    }
}
