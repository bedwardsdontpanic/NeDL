
using Azure.Identity;
using Microsoft.Data.SqlClient;
using System;

namespace Ben_Project
{
    public class Helpers
    {
        public static SqlConnectionStringBuilder startConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "ben-projectdbserver.database.windows.net";
            builder.UserID = "benj.edwrds";
            builder.Password = "ZBE3012.";
            builder.InitialCatalog = "Ben_Project_db";
            var tenantId = "a4cb79c3-7e45-45d0-8335-29edefd7e9f8";
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", tenantId);

            DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions()
            {
                VisualStudioTenantId = tenantId,
                SharedTokenCacheTenantId = tenantId
            };

            return builder;
        }

    }
}