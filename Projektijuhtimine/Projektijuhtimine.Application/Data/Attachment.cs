using System.ComponentModel.DataAnnotations;
namespace Projektijuhtimine.Application.Data;
public class Attachment { public int Id { get; set; } public int TaskId { get; set; } public ProjectTask? Task { get; set; } [Required, StringLength(255)] public string FileName { get; set; } = string.Empty; [Required, StringLength(1000)] public string FilePath { get; set; } = string.Empty; public DateTime UploadedAt { get; set; } public int UserId { get; set; } public User? User { get; set; } }
