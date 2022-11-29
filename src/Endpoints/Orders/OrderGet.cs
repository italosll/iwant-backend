namespace iwant_backend.Endpoints.Orders;

public class OrderGet
{

    public static string Template => "/orders/{id:guid}";

    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;


    public static async Task<IResult> Action([FromRoute] Guid id, ApplicationDbContext dbContext, HttpContext http, UserManager<IdentityUser> userManager)
    {

        var clientClaim = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
        var employeeClaim = http.User.Claims.FirstOrDefault(c => c.Type == "EmployeeCode");

        var order = dbContext.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == id);


        if (order.ClientId != clientClaim.Value && employeeClaim == null)
            return Results.Forbid();

        var client = await userManager.FindByIdAsync(order.ClientId);
        var results = new OrderResponse(order.Id, order.Products, order.Total, order.DeliveryAddress);

        return Results.Ok(results);
    }
}