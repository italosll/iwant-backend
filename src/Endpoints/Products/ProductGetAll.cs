namespace iwant_backend.Endpoints.Products;

public class ProductGetAll
{

    public static string Template => "/products";

    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action(ApplicationDbContext context)
    {
        var products = await context.Products.Include(p => p.Category).OrderBy(p => p.Name).ToListAsync();
        var results = products.Select(p => new ProductResponse(p.Id,
            p.Name, p.Category.Name, p.Description, p.Amount, p.Price, p.Active, p.MainImage));

        return Results.Ok(results);
    }
}