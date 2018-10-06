using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace UnidaysChallenge
{
    public static class UnidaysDiscountChallenge
    {
        public static List<Product> AddToBasket(string theItem)
        {
            var tempList = new List<Product>();
            string[] temp = theItem.Split(",");
            string prodName = temp[0].ToUpper();
            
            var prodQuant = (temp[1] != "" && temp[1] != " " && Int32.Parse(temp[1]) > 0) ? Int32.Parse(temp[1]) : 1;
            var itm = new Product{
                item = prodName,
                quantity = prodQuant,
            };

            var basket = new List<Product>();
            basket.Add(itm);
            return basket.ToList();
        }

        public static void CalculateTotalPrice(List<Product> someList)
        {   
            int qA = 0, qB = 0, qC = 0, qD = 0, qE = 0;
            int pA = 8, pB = 12, pC = 4, pD = 7, pE = 5;
                
            qA = someList.Where(r => r.item == "A").Sum(r => r.quantity);
            qB = someList.Where(r => r.item == "B").Sum(r => r.quantity);
            qC = someList.Where(r => r.item == "C").Sum(r => r.quantity);
            qD = someList.Where(r => r.item == "D").Sum(r => r.quantity);
            qE = someList.Where(r => r.item == "E").Sum(r => r.quantity);
            
            var price_B = DiscountForItemB(qB, pB);
            var price_C = threeItemsDiscount(qC, pC);
            var price_D = DiscountForItemD(qD, pD);
            var price_E = threeItemsDiscount(qE, pE);

            if(qA != 0)
            {
                receiptSection('A', qA, pA, (qA*pA));
            }
            
            if(qB != 0)
            {
                receiptSection('B', qB, pB, price_B);
            }

            if(qC != 0)
            {
                receiptSection('C', qC, pC, price_C);
            }

            if(qD != 0)
            {
                receiptSection('D', qD, pD, price_D);
            }

            if(qE != 0)
            {
                receiptSection('E', qE, pE, price_E);
            }

            var itemTotal = (qA * pA) + price_B + price_C + price_D + price_E;
            bool hasShippingFee = (itemTotal < 50) ? true : false;
            var receiptTotal = (hasShippingFee == true) ? (itemTotal + 7) : itemTotal;
            var msg =  (hasShippingFee == true) ? $"{(char)163}7 shipping fees." : "FREE shipping";
            Console.WriteLine($"Your order amounts to {(char)163}{receiptTotal}.- incl. {msg}");
        }

        public static int threeItemsDiscount(int quantity, int price)
        {
            var a = quantity;
            var b = price;
            int cost = 0;

                if(a < 3 ){
                    cost = a * b;
                }else
                if(a % 3 == 0)
                {
                    cost = (a/3) * 10;
                }else
                if((a - 1) % 3 == 0)
                {
                    cost = ((a - 1)/3) * 10 + b;
                }else
                if((a - 2) % 3 == 0)
                {
                    cost = ((a - 2)/3) * 10 + (2 * b);
                }
            return cost;
        }

        public static int DiscountForItemD(int quantity, int price)
        {
            var a = quantity;
            var b = price;
            int cost = 0;

            if(a < 2)
            {
                cost = a * b;
            }else
             if(a % 2 == 0)
             {
                cost = (a/2) * b;
            }else
             if((a - 1) % 2 == 0)
             {
                cost = (a - 1)/2 + b;
            }
            return cost;
        }

        public static int DiscountForItemB(int quantity, int price){
            var a = quantity;
            var b = price;
            int cost = 0;

            if(a < 2){
                cost = a * b;
            }else if(a % 2 == 0){
                cost = (a*b) - ((a/2) *4);
            }else if((a - 1) % 2 == 0){
                cost = ((a -1) * b) - (((a-1)/2) *4) + b;
            }
            return cost;
        }

        public static void receiptSection(char _item, int quantity, int price, int total){
            Console.Write($"Item {_item} ({(char)163}{price}.-/per Item):\n");
            Console.Write($"{quantity, 25} for {(char)163}{total}.-\n");
        }
    }
}
