using System;

namespace flipTheCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of time you want to toss the coin:");
            int noOfTimes = int.Parse(Console.ReadLine());
            if(noOfTimes<0){
                Console.WriteLine("Number of Heads :- 0 0%");
                Console.WriteLine("Number of Tails :- 0 0%");
            }
            else{
                    Random rand = new Random();
                    int noOfTails = 0;
                    int noOfHeads = 0;
                    for(int i=0;i<noOfTimes;i++){
                        double num = rand.NextDouble();
                        if(num<0.5){
                            noOfTails += 1;
                        }
                        else{
                            noOfHeads += 1;
                        }
                    }

                    double headPercent;
                    double tailPercent;

                    headPercent = noOfHeads*100/noOfTimes;
                    tailPercent = noOfTails*100/noOfTimes;

                    Console.WriteLine("Number of Heads :- {0} {1}%",noOfHeads,headPercent);
                    Console.WriteLine("Number of Tails :- {0} {1}%",noOfTails,tailPercent);
            
            }
        }
    }
}
