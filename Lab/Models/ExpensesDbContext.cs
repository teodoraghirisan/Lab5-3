using Microsoft.EntityFrameworkCore;

namespace Labo2.Models
{
  public class ExpensesDbContext : DbContext
  {
    public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>(entity =>
      {
        entity.HasIndex(u => u.Username).IsUnique();
      });

      builder.Entity<Comment>()
          .HasOne(e => e.Expense)
          .WithMany(c => c.Comments)
          .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<Expense>()
        .HasOne(e => e.AddedBy)
        .WithMany(c => c.Expenses)
        .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<User> Users { get; set; }
  }
}
