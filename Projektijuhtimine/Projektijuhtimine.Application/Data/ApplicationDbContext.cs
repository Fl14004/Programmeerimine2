using Microsoft.EntityFrameworkCore;
namespace Projektijuhtimine.Application.Data;
public class ApplicationDbContext : DbContext {
 public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
 public DbSet<User> Users => Set<User>(); public DbSet<Project> Projects => Set<Project>(); public DbSet<ProjectMember> ProjectMembers => Set<ProjectMember>(); public DbSet<ProjectTask> Tasks => Set<ProjectTask>(); public DbSet<WorkLog> WorkLogs => Set<WorkLog>(); public DbSet<Attachment> Attachments => Set<Attachment>();
 protected override void OnModelCreating(ModelBuilder modelBuilder) {
  modelBuilder.Entity<ProjectMember>().HasOne(x=>x.Project).WithMany(x=>x.ProjectMembers).HasForeignKey(x=>x.ProjectId).OnDelete(DeleteBehavior.Cascade);
  modelBuilder.Entity<ProjectMember>().HasOne(x=>x.User).WithMany(x=>x.ProjectMembers).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);
  modelBuilder.Entity<ProjectTask>().HasOne(x=>x.Project).WithMany(x=>x.Tasks).HasForeignKey(x=>x.ProjectId).OnDelete(DeleteBehavior.Cascade);
  modelBuilder.Entity<ProjectTask>().HasOne(x=>x.ResponsibleUser).WithMany().HasForeignKey(x=>x.ResponsibleUserId).OnDelete(DeleteBehavior.Restrict);
  modelBuilder.Entity<WorkLog>().HasOne(x=>x.Task).WithMany(x=>x.WorkLogs).HasForeignKey(x=>x.TaskId).OnDelete(DeleteBehavior.Cascade);
  modelBuilder.Entity<WorkLog>().HasOne(x=>x.User).WithMany().HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);
  modelBuilder.Entity<Attachment>().HasOne(x=>x.Task).WithMany(x=>x.Attachments).HasForeignKey(x=>x.TaskId).OnDelete(DeleteBehavior.Cascade);
  modelBuilder.Entity<Attachment>().HasOne(x=>x.User).WithMany().HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);
 }
}
