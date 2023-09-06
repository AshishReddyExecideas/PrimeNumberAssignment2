// See https://aka.ms/new-console-template for more information

using Assignment2;
using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        PrimeNumberService p = new PrimeNumberService();
        for (int i = 0; i < 5; i++)
        {
            var prime = p.GenerateRandomPrimeNumber();
            Console.WriteLine(prime);
        }

        Console.WriteLine("__________________\n");

        p.GenerateRandomPrimesandStore();
        foreach (var item in p.dict)
        {
            if (item.Value == true)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}
