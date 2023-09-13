using Microsoft.EntityFrameworkCore;
using System;

namespace WebAppPostgres.Models
{
    public class FurnitureDBContext:DbContext
    {

        public FurnitureDBContext(DbContextOptions<FurnitureDBContext> options) : base(options)
        {
        }

        public DbSet<Furniture> Furniture { get; set; }
        public DbSet<FurnitureType> FurnitureType { get; set; }
    }
}
