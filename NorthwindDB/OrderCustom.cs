namespace NorthwindDB
{
    public partial class Order
    {
        public override string ToString()
        {
            return $"{OrderDate} - {OrderId}";
        }
    }
}