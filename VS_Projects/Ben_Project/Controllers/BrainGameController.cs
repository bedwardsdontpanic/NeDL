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
    public class BrainGameController : ControllerBase
    {

        private readonly ILogger<BrainGameController> _logger;

        public BrainGameController(ILogger<BrainGameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<HighScore> Get()
        {
            HighScore[] theScores = null;
            try
            {
                SqlConnectionStringBuilder builder = Helpers.startConnection();
                SqlConnection connection = new SqlConnection(builder.ConnectionString);

                string sql = "SELECT TOP 10 name,score FROM HighScores ORDER BY score DESC";
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var list = new List<HighScore>();
                        while (reader.Read())
                            list.Add(new HighScore { 
                                name = reader.GetString(0), 
                                score = reader.GetDecimal(1) 
                            });
                        theScores = list.ToArray();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return theScores;
        }




        [HttpPost]
        public void Post([FromBody] HighScore theScore)
        {
            Console.WriteLine("in post method for highscore");
            Console.WriteLine("INFO: " + theScore.name + theScore.score + " END INFO");
            SqlConnectionStringBuilder builder = Helpers.startConnection();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            var sql = "INSERT INTO [dbo].[HighScores](name, score) VALUES(@name, @score)";
            connection.Open();

            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", theScore.name);
                cmd.Parameters.AddWithValue("@score", theScore.score);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
