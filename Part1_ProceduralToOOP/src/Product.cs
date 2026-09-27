namespace Part1_ProceduralToOOP;

public class Product
{
    public int Id { get; }
    public decimal Price { get; }
    public int Stock { get; set; }
    public string Name { get; }

    public Product(int id, decimal price, int stock, string name)
    {
        Id = id;
        Price = price;
        Stock = stock;
        Name = name;
    }
}