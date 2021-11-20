namespace NorthwindDB
{
    public partial class OrderDetail
    {
        public override string ToString()
        {
            return $"{Order.Employee.FirstName} {Order.Employee.LastName}: {Quantity} x {Product.ProductName} ({Product.Category.CategoryName}, {Product.Supplier.CompanyName})";
        }
    }
}