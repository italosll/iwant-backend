using iwant_backend.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace iwant_backend.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {

        if (rows >= 20)
        {
            return Results.BadRequest("Rows is bigger than 20");
        }


        return Results.Ok(query.Execute(page.Value, rows.Value));
    }


}


