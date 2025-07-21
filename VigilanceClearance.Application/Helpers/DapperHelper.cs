using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

public static class DapperHelper
{
    public static async Task<IEnumerable<dynamic>> QueryAsync(
        VCDbContext dbContext,
        string procedureName,
        DynamicParameters parameters)
    {
        using var connection = dbContext.Database.GetDbConnection();

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync();

        return await connection.QueryAsync(
            procedureName,
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
