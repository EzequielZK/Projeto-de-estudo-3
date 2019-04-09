using System;
using System.Collections.Generic;
using System.Globalization;
using StudyApp.Entities;

namespace StudyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> prod = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
               
                if(ch == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customs = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    prod.Add(new ImportedProduct(name, price, customs));
                }
                else if(ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    prod.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    prod.Add(new Product(name, price));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach(Product p in prod)
            {
                Console.WriteLine(p.PriceTag());
            }
            Console.ReadLine();
        }
    }
}
