using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBookShelf.Context;
using WebAppBookShelf.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppBookShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AuthorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        // ENDPOINTS
        // GET: api/<AuthorController>
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            return context.Authors.ToList();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}", Name = "ObtainAuthor")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            var authorDb = await context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (authorDb == null)
            {
                return NotFound();
            } else
            {
                return authorDb;
            }
        }

        // POST api/<AuthorController>
        [HttpPost]
        public ActionResult<Author> Post([FromBody] Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtainAuthor", new { id = author.Id }, author);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author updatedAuthor)
        {
            if (id != updatedAuthor.Id)
            {
                return BadRequest();
            }
            context.Entry(updatedAuthor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            var deletedAuthor = context.Authors.FirstOrDefault(x => x.Id == id);
            if (deletedAuthor == null)
            {
                return NotFound();
            }

            context.Authors.Remove(deletedAuthor);
            context.SaveChanges();
            return deletedAuthor;
        }
    }
}
