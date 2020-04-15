using System;

namespace powerOf2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the value :");
            int val = int.Parse(Console.ReadLine());
            int po = 2;
            double value;
            if(val<32){
                for(int i=0;i<val;i++){
                    Console.Write("{0}^{1} = ",po,i);
                    value = Math.Pow(po,i);
                    Console.WriteLine(value);
                }
            }
            else{
                Console.WriteLine("Overflow will happen for this number");
            }
        }
    }
}
