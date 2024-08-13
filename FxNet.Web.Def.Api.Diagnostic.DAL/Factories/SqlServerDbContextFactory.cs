using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Db.Factories
{
    public class SqlServerDbContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            var connectionString = "Server = localhost\\SQLEXPRESS; Database = MyApp; Integrated Security = True; trustServerCertificate = true";//Environment.GetEnvironmentVariable("SQLSERVER_MOVIES_LOCAL_CONNSTR");
            optionsBuilder.UseSqlServer(connectionString
                                        ?? throw new NullReferenceException(
                                            $"Connection string is not got from environment {nameof(connectionString)}"));

            return new DataBaseContext(optionsBuilder.Options);
        }
    }
}
