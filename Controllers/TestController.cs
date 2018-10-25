using Microsoft.AspNetCore.Mvc;
using HashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase
  {

    public TestController()
    {
    }

    // GET api/test
    [HttpGet]
    public IActionResult Get()
    {
      return Ok("Test workin...");
    }

  }
}
