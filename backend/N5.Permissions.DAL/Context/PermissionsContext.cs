using Microsoft.EntityFrameworkCore;
using N5.Permissions.DAL.Entities;

namespace N5.Permissions.DAL.Context;

public class PermissionsContext : DbContext
{
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<PermissionType> PermissionTypes { get; set; }

    public PermissionsContext(DbContextOptions<PermissionsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the schema name for all tables explicitly
        modelBuilder.HasDefaultSchema("dbo");

        // Configure PermissionType entity
        modelBuilder.Entity<PermissionType>(entity =>
        {
            entity.ToTable("PermissionTypes"); // Ensure table name matches DB

            entity.HasKey(e => e.Id); // Primary Key
            entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Identity Column

            entity.Property(e => e.Description)
                  .IsRequired()
                  .HasMaxLength(255); // Match NVARCHAR(255) and NOT NULL
        });

        // Configure Permission entity
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permissions"); // Ensure table name matches DB

            entity.HasKey(e => e.Id); // Primary Key
            entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Identity Column

            entity.Property(e => e.NombreEmpleado)
                  .IsRequired()
                  .HasMaxLength(255); // Match NVARCHAR(255) and NOT NULL

            entity.Property(e => e.ApellidoEmpleado)
                  .IsRequired()
                  .HasMaxLength(255); // Match NVARCHAR(255) and NOT NULL

            entity.Property(e => e.FechaPermiso)
                  .IsRequired()
                  .HasColumnType("date"); // Match DATE type

            entity.HasOne(d => d.PermissionType) // Configure the foreign key relationship
                  .WithMany()
                  .HasForeignKey(d => d.TipoPermiso)
                  .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        });
    }
}
