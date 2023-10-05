using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
        Database.SetConnectionString("DESKTOP-CELEVHP\\SQLEXPRESS;Database=AzFarFroup;Trusted_Connection=True");
        Database.EnsureCreated();
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.ApplyConfiguration(new ());
    //    base.OnModelCreating(modelBuilder);
    //}
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderTime> OrderTimes { get; set; }
    public DbSet<User> Users { get; set; }
}
