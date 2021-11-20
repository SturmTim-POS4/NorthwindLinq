using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NorthwindDB;

namespace NorthwindLinq
{
  public class Queries
  {
    private NorthwindContext db;
    public Queries()
    {
      InitializeDatabase();
    }

    private void InitializeDatabase()
    {
      db = new NorthwindContext();
    }

    public void CheckAll()
    {
      First5ProductsWithCategories().Show("First5ProductsWithCategories");
      OrderedProductsOfBOTTM().Show("OrderedProductsOfBOTTM");
      NrOfEmployeesWhoSoldToCustomersInGivenCity("Nantes").Show("NrOfEmployeesWhoSoldToCustomersInGivenCity Nantes");
      NrOfEmployeesWhoSoldToCustomersInGivenCity("London").Show("NrOfEmployeesWhoSoldToCustomersInGivenCity London");
      NrOfEmployeesWhoSoldToCustomersInGivenCity("Buenos Aires").Show("NrOfEmployeesWhoSoldToCustomersInGivenCity Buenos Aires");
      CustomersWithUnshippedOrders().Show("CustomersWithUnshippedOrders");
      TotalQuantityOfShipper("Speedy Express").Show("TotalQuantityOfShipper Speedy Express");
      TotalQuantityOfShipper("United Package").Show("TotalQuantityOfShipper United Package");
      TotalQuantityOfShipper("Federal Shipping").Show("TotalQuantityOfShipper Federal Shipping");
      AveragePriceOfSuppliersOfCity("Tokyo").Show("AveragePriceOfSuppliersOfCity Tokyo");
      AveragePriceOfSuppliersOfCity("Paris").Show("AveragePriceOfSuppliersOfCity Paris");
      AveragePriceOfSuppliersOfCity("Berlin").Show("AveragePriceOfSuppliersOfCity Berlin");
      CategoriesWithProductsInStockMoreThan(400).Show("CategoriesWithProductsInStockMoreThan 400");
      CategoriesWithProductsInStockMoreThan(600).Show("CategoriesWithProductsInStockMoreThan 600");
      CategoriesWithProductsInStockMoreThan(200).Show("CategoriesWithProductsInStockMoreThan 200");
    }

    #region Q01
    public List<string> First5ProductsWithCategories()
    {
      return db.Products
        .OrderBy(x => x.ProductName)
        .Take(5)
        .Select(x => $"{x.ProductName} - {x.Category.CategoryName}")
        .ToList();
    }
    #endregion

    #region Q02
    public List<string> OrderedProductsOfBOTTM()
    {
      return db.Orders
        .Where(x => x.Customer.CustomerId == "BOTTM")
        .SelectMany(x => x.OrderDetails)
        .Select(x => x.Product)
        .Where(x => x.UnitPrice > 30)
        .Select(x => x.ProductName)
        .Distinct()
        .OrderBy(x => x)
        .ToList();
    }
    #endregion

    #region Q03
    public int NrOfEmployeesWhoSoldToCustomersInGivenCity(string city)
    {
      return db.Orders
        .Where(x => x.Customer.City == city)
        .Select(x => x.Employee.EmployeeId)
        .Distinct()
        .Count();
    }
    #endregion

    #region Q04
    public List<string> CustomersWithUnshippedOrders()
    {
      return db.Orders
        .Where(x => x.Customer.Country == "Venezuela" || x.Customer.Country == "Argentina")
        .Where(x => x.ShippedDate == null)
        .Select(x => $"{x.Customer.CompanyName} - {x.ShipCity}/{x.ShipCountry} - {x.Employee.FirstName} {x.Employee.LastName}")
        .ToList();
    }
    #endregion

    #region Q05
    public int TotalQuantityOfShipper(string shipperCompany)
    {
      return db.Orders
        .Where(x => x.ShipViaNavigation.CompanyName == shipperCompany)
        .Where(x => x.ShippedDate != null)
        .SelectMany(x => x.OrderDetails)
        .Select(x => x.Quantity)
        .Sum(x => x);
    }
    #endregion

    #region Q06
    public double AveragePriceOfSuppliersOfCity(string city)
    {
    return db.Products
      .Where(x => x.Supplier.City == city)
      .Select(x => (double)x.UnitPrice).Average();
    }
    #endregion

    #region Q07
    public List<string> CategoriesWithProductsInStockMoreThan(int totalStock)
    {
      return db.Categories.Where(x => x.Products.Select(x => (int) x.UnitsInStock).Sum() > totalStock)
        .OrderBy(x => x.CategoryName)
        .Select(x => x.CategoryName)
        .ToList();
    }
    #endregion

  }
}
