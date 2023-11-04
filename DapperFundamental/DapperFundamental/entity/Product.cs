namespace DapperFundamental.entity;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public long ProductPrice { get; set; }
    public int Stock { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(ProductName)}: {ProductName}, {nameof(ProductPrice)}: {ProductPrice}, {nameof(Stock)}: {Stock}";
    }
}