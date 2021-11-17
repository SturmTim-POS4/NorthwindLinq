using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindLinq
{
  public class Queries
  {
    //private NorthwindContext db;
    public Queries()
    {
      InitializeDatabase();
    }

    private void InitializeDatabase()
    {
      //initialize the variable db here
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
      return new List<string>();
    }
    #endregion

    #region Q02
    public List<string> OrderedProductsOfBOTTM()
    {
      return new List<string>();
    }
    #endregion

    #region Q03
    public int NrOfEmployeesWhoSoldToCustomersInGivenCity(string city)
    {
      return -1;
    }
    #endregion

    #region Q04
    public List<string> CustomersWithUnshippedOrders()
    {
      return new List<string>();
    }
    #endregion

    #region Q05
    public int TotalQuantityOfShipper(string shipperCompany)
    {
      return -1;
    }
    #endregion

    #region Q06
    public double AveragePriceOfSuppliersOfCity(string city)
    {
      return -1;
    }
    #endregion

    #region Q07
    public List<string> CategoriesWithProductsInStockMoreThan(int totalStock)
    {
      return new List<string>();
    }
    #endregion

  }
}
