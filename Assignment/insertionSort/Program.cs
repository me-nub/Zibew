using System;

namespace insertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter how many words you want to sort :");
            int noOfWords = int.Parse(Console.ReadLine());
            String[] words = new String[noOfWords];
            Console.WriteLine("Enter the words :");
            for(int i=0;i<noOfWords;i++){
                words[i] = Console.ReadLine();
            }

            String temp;
            int j=0;

            for(int i=1;i<noOfWords;i++){
                Console.WriteLine("in for loop");
                j = i-1;
                temp = "";
                temp = words[i];
                while(j>=0){
                    Console.WriteLine("in while loop");
                    int val = string.Compare(words[j],temp) ;
                    if(val>0){
                        Console.WriteLine("in if loop");
                        words[j+1] = "";
                        words [j+1] += words[j];
                        j -= 1;
                    }
                }
                words[j+1] = "";
                words[j+1] += temp;
            }
            Console.WriteLine("Sorted words are :");
            for(int i=0;i<noOfWords;i++){
                Console.WriteLine("{0}",words[i]);
            }
        }
    }
}
