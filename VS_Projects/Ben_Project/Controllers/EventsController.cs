using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//using Microsoft.EntityFrameworkCore.Storage;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ben_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TheEventsController : ControllerBase
    {

        private readonly ILogger<TheEventsController> _logger;

        public TheEventsController(ILogger<TheEventsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Events> Get()
        {
            Events[] theEvents = null;
            try
            {
                SqlConnectionStringBuilder builder = Helpers.startConnection();
                SqlConnection connection = new SqlConnection(builder.ConnectionString);

                string sql = "SELECT TOP 10 id,name,location FROM events ORDER BY ID ASC";
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var list = new List<Events>();
                        while (reader.Read())
                            list.Add(new Events { 
                                id = reader.GetDecimal(0),
                                name = reader.GetString(1),
                                location = reader.GetString(2)
                            });
                        theEvents = list.ToArray();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return theEvents;
        }




        [HttpPost]
        public void Post([FromBody] Events theEvent)
        {
            Console.WriteLine("in post method for events");
            Console.WriteLine("INFO: " + theEvent.name + theEvent.name + " END INFO");
            SqlConnectionStringBuilder builder = Helpers.startConnection();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            var sql = "INSERT INTO [dbo].[EVENTS](ID,name,location) VALUES(@ID, @name, @location)";
            connection.Open();

            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@id", theEvent.id);
                cmd.Parameters.AddWithValue("@name", theEvent.name);
                cmd.Parameters.AddWithValue("@location", theEvent.location);
                cmd.ExecuteNonQuery();
            }
        }

        [HttpDelete]
        public void Delete([FromBody] Events theEvent)
        {
            Console.WriteLine("in delete method for events");
            Console.WriteLine("INFO: " + theEvent + " END INFO");
            SqlConnectionStringBuilder builder = Helpers.startConnection();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            var sql = "DELETE FROM [dbo].[EVENTS] WHERE id = @theID";
            connection.Open();

            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@theID", theEvent.id);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
