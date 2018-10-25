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
  public class HashController : ControllerBase
  {

    private HashContext hashContext;

    public HashController(HashContext hashContext)
    {
      this.hashContext = hashContext;
    }

    // GET api/hash
    [HttpGet]
    public IActionResult Get()
    {
      return Ok(hashContext.Hashes.Where(w => w.deleted == false).ToList());
    }

    // GET api/hash/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      return Ok(hashContext.Hashes.Where(w => w.id == id));
    }

    // POST api/hash
    [HttpPost]
    public IActionResult Post([FromBody] string input)
    {
      var newModel = new HashingModel().Generate256Hash(input, "Test Hash");

      // Result is the entire table.      
      // var result = hashContext.Hashes.Add(newModel);

      hashContext.Hashes.Add(newModel);
      hashContext.SaveChanges();

      return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/hash/{newModel.id}", newModel);
    }

    // PUT api/hash/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] string value)
    {
      var updateModel = hashContext.Hashes.Where(w => w.id == id).FirstOrDefault();

      updateModel.description = value;

      hashContext.Hashes.Update(updateModel);
      hashContext.SaveChanges();

      return Ok(updateModel);
    }

    // DELETE api/hash/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var deleteModel = hashContext.Hashes.Where(w => w.id == id).FirstOrDefault();

      deleteModel.deleted = true;

      hashContext.Hashes.Update(deleteModel);
      hashContext.SaveChanges();

      return NoContent();
    }
  }
}
