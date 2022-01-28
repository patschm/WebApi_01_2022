using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ICounter _counter;

        public TestController(ICounter counter)
        {
            _counter = counter;
        }

        // Action
        [HttpGet("{id}")]
        //[Route()]
        public IActionResult Get(int id = 0)
        {
            _counter.Increment();
            return Ok(new Person { Id=id, Name = "Kees"});
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person p)
        {
            p.Id = 42;
            return CreatedAtAction(nameof(Get), new { id=p.Id}, p );// $"/api/test/{p.Id}", p);
        }
    }
}