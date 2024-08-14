using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task3.model;

namespace task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //api/patron
    public class PatronController : ControllerBase
    {
        private readonly itientity Context;
        public PatronController(itientity context)
        {
            Context = context;
        }

        // GET /api/patron
        [HttpGet]
        public IActionResult GetPatron()
        {
            List<Patron> Patrons = Context.Patrons.ToList();
            return Ok(Patrons);
           
        }


        // GET /api/patrons/{id}
        [HttpGet("{id}")]
        public IActionResult GetPatronById(int id)
        {
            
            Patron patron = Context.Patrons.Find(id);
            return Ok(patron);
        }
        

        // POST /api/patrons
        [HttpPost]
        public IActionResult Add([FromBody]Patron patron  )
        {
            
            if (ModelState.IsValid)
            {
                Context.Patrons.Add(patron);
                Context.SaveChanges();
                return Ok("patron added success");
            }
            return BadRequest(ModelState);
        }

        // PUT /api/patrons/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Patron patron)
        {
            
            if (ModelState.IsValid)
            {
               Patron oldpatron = Context.Patrons.Find(id);
               
                Context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent, "datasaved");
            }
            return BadRequest("data not valid");
        }

        // DELETE /api/patrons/{id}
        [HttpDelete("{id}")]
        public IActionResult RemovePatron(int id)
        {
            // Remove a book from the library.
           Patron oldpatron = Context.Patrons.Find(id);
            Context.Patrons.Remove(oldpatron);
            Context.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent, "datasaved");
        }
    }
}
