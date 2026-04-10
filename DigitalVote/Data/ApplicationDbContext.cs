using DigitalVote.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalVote.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Voter> Voters { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Vote> Votes { get; set; }
    public DbSet<Party> Parties { get; set; }
    public DbSet<Position> Positions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Voter>()
            .HasIndex(v => v.Dni)
            .IsUnique();

        modelBuilder.Entity<Party>()
            .HasIndex(p => p.Name)
            .IsUnique();
    }
}