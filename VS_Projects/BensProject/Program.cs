using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Azure.Security.KeyVault.Secrets;

namespace BensProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "bensprojectdbserver.database.windows.net";
                builder.UserID = "benj.edwrds";
                builder.Password = "ZBE3012.";
                builder.InitialCatalog = "BensProjectdb";
                var tenantId = "a4cb79c3-7e45-45d0-8335-29edefd7e9f8";
                Environment.SetEnvironmentVariable("AZURE_TENANT_ID", tenantId);

                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions()
                {
                    VisualStudioTenantId = tenantId,
                    SharedTokenCacheTenantId = tenantId
                };

//var client = new SecretClient(new Uri("https://sts.windows.net/a4cb79c3-7e45-45d0-8335-29edefd7e9f8"), new DefaultAzureCredential());

                /*                var client = new SecretClient(
                                             new Uri(key - vault - url),
                                             new DefaultAzureCredential(options)
                                             );*/

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT name, collation_name FROM sys.databases";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((context, config) =>
{
var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
config.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
