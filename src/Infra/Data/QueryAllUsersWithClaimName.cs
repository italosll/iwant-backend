using Dapper;
using iwant_backend.Endpoints.Employees;
using Microsoft.Data.SqlClient;

namespace iwant_backend.Infra.Data;

public class QueryAllUsersWithClaimName
{
    private readonly IConfiguration configuration;
    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<EmployeeResponse> Execute(int page, int rows)
    {
        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);


        var query =
            @"SELECT Email, ClaimValue AS Name 
                FROM AspNetUserClaims claims INNER JOIN AspNetUsers users 
                ON users.Id = claims.UserId and ClaimType = 'Name'
            order by Name
            OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY
            ";


        return db.Query<EmployeeResponse>(
            query,
            new { page, rows }
         );
    }
}
