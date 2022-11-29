namespace iwant_backend.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category(string name, string createdBy, string editedBy)
    {

        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;

        Validate();

    }

    private void Validate()
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name", "O nome é obrigatório")
            .IsGreaterOrEqualsThan(Name, 3, "Name", "O nome deve ter ao menos 3 caracteres")
            .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
            .IsNotNullOrEmpty(EditedBy, "EditedBy");
        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active, string editedBy)
    {
        Active = active;
        Name = name;
        EditedBy = editedBy;
        EditedOn = DateTime.UtcNow;

        Validate();
    }
}
