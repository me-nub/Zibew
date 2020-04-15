using System;

namespace stockMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of stocks");
            int noOfStocks = int.Parse(Console.ReadLine());

            int[] noOfShares = new int[noOfStocks];
            int[] priceOfShare = new int[noOfStocks];
            string[] nameOfStocks = new string[noOfStocks];

            for(int i=0;i<noOfStocks;i++){
                
                Console.WriteLine("stock name:");
                nameOfStocks[i] = Console.ReadLine();

                Console.WriteLine("Number of Shares:");
                noOfShares[i] = int.Parse(Console.ReadLine());

                Console.WriteLine("Share price:");
                priceOfShare[i] = int.Parse(Console.ReadLine());
            }

            int TotalStockPrice = 0;

            for(int i=0;i<noOfStocks;i++){
                Console.Write("Stock name : {0} ",nameOfStocks[i]);
                Console.Write("Number of shares {0} ",noOfShares[i]);
                Console.Write("Share price {0} ",priceOfShare[i]);
                int valueOfEachStock = noOfShares[i]*priceOfShare[i];
                Console.WriteLine("value of each stock {0} : ",valueOfEachStock);
                TotalStockPrice += valueOfEachStock;
            }
            Console.WriteLine("Total stock price {0} : ",TotalStockPrice);
        }
    }
}
