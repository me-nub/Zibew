using System;

namespace bubbleSort
{
    class Program
    {
        /*public void Swap(int a,int b){
            int temp=a;
            a=b;
            b=temp;
        }*/
        static void Main(string[] args)
        {
            Console.WriteLine("Enter how many numbers you want to sort :");
            int num = int.Parse(Console.ReadLine());
            int[] arr = new int[num];
            //Program h = new Program();
            for(int i=0;i<num;i++){
                arr[i] = int.Parse(Console.ReadLine());
            }

            for(int i=0;i<num-1;i++){
                for(int j=0;j<(num-i-1);j++){
                    if(arr[j]>arr[j+1]){
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted numbers are :");
            for(int i=0;i<num;i++){
                Console.WriteLine("{0}",arr[i]);
            }
        }
    }
}
