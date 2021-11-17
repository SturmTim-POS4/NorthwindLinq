using FluentAssertions;
using NorthwindLinq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace NorthwindLinqTests
{
  /*
  Install-Package xunit -ProjectName NorthwindLinqTests
  Install-Package xunit.runner.console -ProjectName NorthwindLinqTests
  Install-Package xunit.runner.visualstudio -ProjectName NorthwindLinqTests
  Install-Package FluentAssertions -ProjectName NorthwindLinqTests
  Install-Package Microsoft.NET.Test.Sdk -ProjectName NorthwindLinqTests
  */

  public class QueriesTests
  {
    private readonly ITestOutputHelper output;
    private readonly Queries queries;

    public QueriesTests(ITestOutputHelper output)
    {
      this.output = output;
      queries = new Queries();
    }

    [Fact]
    public void T01_SelectFirst5ProductsWithCategoriesTest()
    {
      var expected = new List<string>(){
        "Alice Mutton - Meat/Poultry",
        "Aniseed Syrup - Condiments",
        "Boston Crab Meat - Seafood",
        "Camembert Pierrot - Dairy Products",
        "Carnarvon Tigers - Seafood" };
      queries.First5ProductsWithCategories().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void T02_OrderedProductsOfBOTTMTest()
    {
      var expected = new List<string>{
        "Alice Mutton",
        "Camembert Pierrot",
        "Gnocchi di nonna Alice",
        "Ikura",
        "Ipoh Coffee",
        "Manjimup Dried Apples",
        "Mozzarella di Giovanni",
        "Northwoods Cranberry Sauce",
        "Raclette Courdavault",
        "Tarte au sucre"
      };
      queries.OrderedProductsOfBOTTM().Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(4, "Nantes")]
    [InlineData(9, "London")]
    [InlineData(8, "Buenos Aires")]
    public void T03_NrOfEmployeesWhoSoldToCustomersInGivenCity(int expectedNr, string city)
    {
      queries.NrOfEmployeesWhoSoldToCustomersInGivenCity(city).Should().Be(expectedNr, $"for city {city}");
    }

    [Fact]
    public void T04_CustomersWithUnshippedOrdersTest()
    {
      var expected = new List<string>
      {
        "Cactus Comidas para llevar - Buenos Aires/Argentina - Laura Callahan",
        "LILA-Supermercado - Barquisimeto/Venezuela - Laura Callahan",
        "LILA-Supermercado - Barquisimeto/Venezuela - Nancy Davolio",
        "LINO-Delicateses - I. de Margarita/Venezuela - Nancy Davolio",
        "Rancho grande - Buenos Aires/Argentina - Michael Suyama"
      };
      queries.CustomersWithUnshippedOrders().Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(15730, "Speedy Express")]
    [InlineData(19195, "United Package")]
    [InlineData(15194, "Federal Shipping")]
    public void T05_TotalQuantityOfShipperTest(int expectedQuantity, string shipperName)
    {
      queries.TotalQuantityOfShipper(shipperName).Should().Be(expectedQuantity, $"for shipperName {shipperName}");
    }

    [Theory]
    [InlineData(46, "Tokyo")]
    [InlineData(140.75, "Paris")]
    [InlineData(29.71, "Berlin")]
    public void T06_AveragePriceOfSuppliersOfCityTest(double expectedPrice, string city)
    {
      queries.AveragePriceOfSuppliersOfCity(city).Should().BeApproximately(expectedPrice, 0.01, $"for city {city}");
    }

    [Theory]
    [InlineData(400, "Beverages", "Condiments", "Seafood")]
    [InlineData(600, "Seafood")]
    [InlineData(200, "Beverages", "Condiments", "Confections", "Dairy Products", "Grains/Cereals", "Seafood")]
    public void T07_CategoriesWithProductsInStockMoreThanTest(int limit, params string[] expected)
    {
      queries.CategoriesWithProductsInStockMoreThan(limit).Should().BeEquivalentTo(expected, $"for limit {limit}");
    }
  }
}
