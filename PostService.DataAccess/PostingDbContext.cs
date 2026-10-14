using Microsoft.EntityFrameworkCore;
using PostService.Models;

namespace PostService.DataAccess;

public class PostingDbContext : DbContext
{
    public DbSet<Posting> Postings { get; set; } = null!;

    public PostingDbContext(DbContextOptions<PostingDbContext> options) : base(options)
    {
    }

    public PostingDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=PostingDb.db;");
        }
    }
}