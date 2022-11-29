namespace iwant_backend.Endpoints.Orders;

public class OrderGetAllByUser
{

    public static string Template => "/orders/user/{id:guid}";

    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;


    public static async Task<IResult> Action([FromRoute] Guid id, ApplicationDbContext dbContext, HttpContext http)
    {
        var routeId = id;
        var idOnToken = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var employeeCode = http.User.Claims.FirstOrDefault(c => c.Type == "EmployeeCode");
        var isUserEmployee = employeeCode != null;

        if (!isUserEmployee)
        {
            var tokenIdIsEqualToRouteId = new Guid(idOnToken) == routeId;

            if (!tokenIdIsEqualToRouteId)
                return Results.Forbid();
        }

        var orders = await dbContext.Orders.Where(o => o.ClientId == routeId.ToString()).OrderBy(o => o.CreatedOn).ToListAsync();

        var results = orders.Select(o => new OrderResponse(o.Id, o.Products, o.Total, o.DeliveryAddress));

        return Results.Ok(results);
    }
}