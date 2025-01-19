using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;
using ToDoListApp.Data.Configurations;

namespace ToDoListApp.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}