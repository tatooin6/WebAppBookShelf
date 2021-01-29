using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBookShelf.Entities;

namespace WebAppBookShelf.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        // <Model> Table
        public DbSet<Author> Authors { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
