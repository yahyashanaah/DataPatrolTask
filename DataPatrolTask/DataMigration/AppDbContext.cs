using DataPatrolTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPatrolTask.DataMigration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<PolicyTable> PolicyTables { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<UserGroupMembership> UserGroupsMembership { get; set; }
        public DbSet<PolicyAssignment> PolicyAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserGroupMembership>()
                .HasKey(ug => new { ug.UserId, ug.GroupId });

            modelBuilder.Entity<PolicyAssignment>()
                .HasKey(pa => new { pa.PolicyId, pa.GroupId });

            modelBuilder.Entity<UserGroupMembership>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroupMemberships)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserGroupMembership>()
                .HasOne(ug => ug.UserGroup)
                .WithMany(g => g.UserGroupMemberships)
                .HasForeignKey(ug => ug.GroupId);

            modelBuilder.Entity<PolicyAssignment>()
                .HasOne(pa => pa.Policy)
                .WithMany(p => p.PolicyAssignments)
                .HasForeignKey(pa => pa.PolicyId);

            modelBuilder.Entity<PolicyAssignment>()
                .HasOne(pa => pa.Group)
                .WithMany(g => g.PolicyAssignments)
                .HasForeignKey(pa => pa.GroupId);

            modelBuilder.Entity<UserRequest>()
                .HasOne(ur => ur.RequestedUser)
                .WithMany(u => u.UserRequests)
                .HasForeignKey(ur => ur.RequestedUserUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
