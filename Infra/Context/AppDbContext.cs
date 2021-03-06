using ApiFantasy.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFantasy.Infra.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=(local); Initial Catalog=FANTASYDB; Integrated Security=true;");

        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Logradouro> Logradouros {get; set;}
        public DbSet<User> Users {get; set;}

        protected override void OnModelCreating (ModelBuilder builder){
            base.OnModelCreating(builder);

            // TABLE CLIENTE

            builder.Entity<Cliente> ().ToTable ("Cliente");
            builder.Entity<Cliente> ().HasKey (p => p.Id);
            builder.Entity<Cliente> ().Property (p => p.Id).IsRequired ().ValueGeneratedOnAdd();
            builder.Entity<Cliente> ().Property (p => p.Nome).IsRequired ().HasMaxLength(30);
            builder.Entity<Cliente> ().Property (p => p.Email).IsRequired ().HasMaxLength(30);
            builder.Entity<Cliente> ().Property (p => p.Logotipo);
            builder.Entity<Cliente> ().HasMany
                (p => p.Logradouros).WithOne (p => p.Cliente).HasForeignKey(p => p.ClienteId);

            // TABLE LOGRADOURO

            builder.Entity<Logradouro> ().ToTable ("Logradouro");
            builder.Entity<Logradouro> ().HasKey (p => p.Id);
            builder.Entity<Logradouro> ().Property (p => p.Id).IsRequired ().ValueGeneratedOnAdd();
            builder.Entity<Logradouro> ().Property (p => p.Endereco).IsRequired ().HasMaxLength(30);

            // TABLE User

            builder.Entity<User> ().ToTable ("User");
            builder.Entity<User> ().HasKey (p => p.Id);
            builder.Entity<User> ().Property (p => p.Id).IsRequired ().ValueGeneratedOnAdd();
            builder.Entity<User> ().Property (p => p.Username).IsRequired ();

        }
    }
}