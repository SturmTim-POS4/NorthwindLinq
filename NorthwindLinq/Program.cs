using System;

namespace NorthwindLinq
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("LINQ with Northwind-Data".PadLeft(80, '-'));
      Console.WriteLine("Alle Tests ausführen mit: Menü Test --> Run --> All Tests");
      new Queries().CheckAll();
      Console.ReadKey();
    }
  }
}
