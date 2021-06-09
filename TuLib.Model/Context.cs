using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TuLib.Model.Entities;

namespace TuLib.Model
{
    public class Context : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public Context(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<GeneroLiterario> GenerosLiterarios { get; set; }
        public DbSet<Valoracion> Valoraciones { get; set; }

    }
}
