using System;

namespace _2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows and columns:");
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            int[,] arr = new int[row,column];
            Console.WriteLine("Enter the data in array :");
            for(int i=0;i<row;i++){
                for(int j=0;j<column;j++){
                    int val = int.Parse(Console.ReadLine());
                    arr[i,j] = val;
                }
            }
            Console.WriteLine("2d array is :");
            for(int i=0;i<row;i++){
                for(int j=0;j<column;j++){
                    Console.Write("{0} ",arr[i,j]);
                }
                Console.WriteLine("");
            }
        }
    }
}
