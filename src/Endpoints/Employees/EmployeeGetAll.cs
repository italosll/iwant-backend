namespace iwant_backend.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {

        if (rows >= 20)
        {
            return Results.BadRequest("Rows is bigger than 20");
        }

        var result = await query.Execute(page.Value, rows.Value);
        return Results.Ok();
    }


}


