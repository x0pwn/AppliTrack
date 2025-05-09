namespace AppliTrack.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class Note
{
    public int Id { get; set; }
    [Required] public string Text { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}
