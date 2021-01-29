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
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return context.Users.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}", Name = "ObtainUser")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtainUser", new { id = user.Id }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest();
            }

            context.Entry(updatedUser).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var deletedUser = context.Users.FirstOrDefault(x => x.Id == id);
            if (deletedUser == null)
            {
                NotFound();
            }

            context.Users.Remove(deletedUser);
            context.SaveChanges();
            return deletedUser;
        }
    }
}
