using System.ComponentModel.DataAnnotations;
namespace Projektijuhtimine.Application.Data;
public class User { public int Id { get; set; } [Required, StringLength(100)] public string Username { get; set; } = string.Empty; [Required, EmailAddress, StringLength(200)] public string Email { get; set; } = string.Empty; [Required, StringLength(200)] public string Password { get; set; } = string.Empty; public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>(); }
