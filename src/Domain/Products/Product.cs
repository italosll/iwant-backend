namespace iwant_backend.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public String Description { get; set; }
    public int Amount { get; set; }
    public float Price { get; set; }
    public bool Active { get; set; } = true;

}
