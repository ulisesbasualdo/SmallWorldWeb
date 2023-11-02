using Microsoft.EntityFrameworkCore;
using SmallWorld.src.LocalFiles;
using SmallWorld.src.Model.Interactuable;
using SmallWorld.src.Model.MapModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        DbSet<Entity> Entities { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Food> Foods { get; set; }
        DbSet<Map> Maps { get; set; }
        DbSet<Land> Lands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>().ToTable("Entity");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Food>().ToTable("Food");
            modelBuilder.Entity<Map>().ToTable("Map");
            modelBuilder.Entity<Land>().ToTable("Land");
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection = LocalInformation.GetConnectionString();
                //string connection = LocalInformation.GetConnectionStringAlt();
                if (attemptConnectionToDatabase(connection))
                {
                    optionsBuilder.UseSqlServer(connection);
                }
            }
        }*/

        /*private bool attemptConnectionToDatabase(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }*/

    }
}
