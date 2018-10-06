using System;
using System.Collections.Generic;
using static UnidaysChallenge.UnidaysDiscountChallenge;

namespace UnidaysChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            var theBasket = new List<Product>();
            
            do{
                Console.WriteLine("Add to cart: ");
                string input = Console.ReadLine();
                Console.Clear();
                
                try
                {
                    theBasket.AddRange(AddToBasket(input));
                    Console.WriteLine("Your basket:\n");
                    foreach(var obj in theBasket)
                    {
                        Console.WriteLine($"{obj.item}  x{obj.quantity}");
                    }
                }catch
                {
                    Console.WriteLine("Oops, something went wrong. :( Please try again!");
                }

            }
            while(Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.Clear();
            CalculateTotalPrice(theBasket);
        }

    }
}
