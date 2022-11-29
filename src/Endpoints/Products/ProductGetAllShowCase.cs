namespace iwant_backend.Endpoints.Products;

public class ProductGetAllShowCase
{

    public static string Template => "/products/showcase";

    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    [AllowAnonymous]
    public static async Task<IResult> Action(
         ApplicationDbContext context, int page = 1, int row = 10, string orderBy = "name")
    {

        if (row > 50)
            return Results.Problem(title: "Row with max 50", statusCode: 400);

        if (orderBy != "name" && orderBy != "price")
            return Results.Problem(title: "Order only by price or number", statusCode: 400);


        var queryBase = context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Where(p => p.Category.Active && p.Active);


        if (orderBy == "name")
            queryBase = queryBase.OrderBy(p => p.Name);
        else
            queryBase = queryBase.OrderBy(p => p.Price);

        var queryFilter = queryBase.Skip((page - 1) * row).Take(row);

        var products = await queryFilter.ToListAsync();

        var results = products.Select(p => new ProductResponse(p.Id,
            p.Name, p.Category.Name, p.Description, p.Amount, p.Price, p.Active, p.MainImage));

        return Results.Ok(results);
    }
}