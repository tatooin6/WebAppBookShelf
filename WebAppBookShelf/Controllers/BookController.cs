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
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return context.Books.ToList();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}", Name = "ObtainBook")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtainBook", new { id = book.Id }, book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody] Book updatedBook)
        {
            if (id != updatedBook.Id)
            {
                return BadRequest();
            }
            context.Entry(updatedBook).State = EntityState.Modified;
            context.SaveChanges();
            return updatedBook;
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            var deletedBook = context.Books.FirstOrDefault();
            if (deletedBook == null)
            {
                return NotFound();
            }
            context.Books.Remove(deletedBook);
            context.SaveChanges();
            return deletedBook;
        }
    }
}
