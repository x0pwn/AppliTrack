namespace AppliTrack.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Application
{
    public int Id { get; set; }
    [Required] public string Company { get; set; }
    [Required] public string Role    { get; set; }
    [DataType(DataType.Date)] public DateTime DateApplied    { get; set; }
    [Required] public ApplicationStatus Status { get; set; }
    [DataType(DataType.Date)] public DateTime? NextActionDate { get; set; }
    public ICollection<Note> Notes    { get; set; }
}

public enum ApplicationStatus
{
    Applied,
    PhoneScreen,
    Interview,
    Offer,
    Rejected
}
