namespace iwant_backend.Domain.Products;

public class Product : Entity
{
    public string Name { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    public string Description { get; private set; }
    public string MainImage { get; private set; }
    public int Amount { get; private set; }
    public decimal Price { get; private set; }
    public bool Active { get; private set; } = true;


    private Product() { }


    public Product(string name, Category category, string description, int amount, decimal price, bool active, string mainImage, string createdBy)
    {
        Name = name;
        Description = description;
        MainImage = mainImage;
        Amount = amount;
        Price = price;
        Active = active;
        Category = category;

        CreatedBy = createdBy;
        EditedBy = createdBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Product>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsGreaterOrEqualsThan(Name, 3, "Name")
            .IsLowerOrEqualsThan(Name, 100, "Name")
            .IsNotNull(Category, "Category", "Category not found")
            .IsNotNullOrEmpty(Description, "Description")
            .IsGreaterOrEqualsThan(Description, 3, "Description")
            .IsLowerOrEqualsThan(Description, 255, "Description")
            .IsNotNull(Amount, "Amount")
            .IsGreaterThan(Amount, 0, "Amount")
            .IsNotNull(Price, "Price")
            .IsGreaterThan(Price, 0, "Price")
            .IsNotEmpty(MainImage, "MainImage")
            .IsLowerOrEqualsThan(MainImage, 100, "MainImage")
            .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
            .IsNotNullOrEmpty(EditedBy, "EditedBy");
        AddNotifications(contract);
    }
}
