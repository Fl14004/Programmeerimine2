using System.ComponentModel.DataAnnotations;
namespace Projektijuhtimine.Application.Data;
public class WorkLog { public int Id { get; set; } public int TaskId { get; set; } public ProjectTask? Task { get; set; } public DateTime Date { get; set; } public decimal Hours { get; set; } public int UserId { get; set; } public User? User { get; set; } [Required] public string Description { get; set; } = string.Empty; }
