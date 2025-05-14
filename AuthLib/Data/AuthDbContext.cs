using AuthLib.Entities;
using System.Collections.Generic;
using System.Data.Entity;


public class AuthDbContext : DbContext
{
    public AuthDbContext() : base("AuthDbConnection") { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Composite Key for UserRole
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        // Composite Key for RolePermission
        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        base.OnModelCreating(modelBuilder);
    }
}