using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;
using ToDoListApp.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ToDoListApp.Data;
public class ApplicationDbContext : IdentityDbContext<IdentityUser> {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<ToDoItem> ToDoItems { get; set; }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasMany(e => e.ToDoItems)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}