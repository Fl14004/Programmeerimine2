using System.ComponentModel.DataAnnotations;
namespace Projektijuhtimine.Application.Data;
public class Project { public int Id { get; set; } [Required, StringLength(200)] public string Name { get; set; } = string.Empty; public DateTime StartDate { get; set; } public DateTime Deadline { get; set; } public decimal Budget { get; set; } public decimal HourlyRate { get; set; } public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>(); public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>(); }
