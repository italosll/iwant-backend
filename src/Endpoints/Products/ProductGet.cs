﻿namespace iwant_backend.Endpoints.Products;

public class ProductGet
{

    public static string Template => "/products/{id:guid}";

    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action([FromRoute] Guid id, ApplicationDbContext context)
    {

        var product = await context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

        if (product == null) return Results.NotFound();

        var result = new ProductResponse(
            product.Id,
            product.Name,
            product.Category.Name,
            product.Description,
            product.Amount,
            product.Price,
            product.Active,
            product.MainImage
         );

        return Results.Ok(result);
    }
}