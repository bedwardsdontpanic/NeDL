using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return Enumerable.Range(1, 5).Select(index => new HighScore
            {
                score = 10,
                name = "xx"
            })
            .ToArray();
        }
    }
}
