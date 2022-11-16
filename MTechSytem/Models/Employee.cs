using System.ComponentModel.DataAnnotations;

namespace MTechSytem.Models;

public class Employee : Resource
{
    public int ID { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required, MaxLength(80)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(13)]
    public string RFC { get; set; }

    [Required]
    public DateTime? BornDate { get; set; }

    public EmployeeStatus Status { get; set; } = EmployeeStatus.NotSet;
}

public enum EmployeeStatus
{
    NotSet = 1,
    Active = 2,
    Inactive = 3,
}
