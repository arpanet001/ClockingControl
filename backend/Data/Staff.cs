using System.ComponentModel.DataAnnotations;

public class Staff
{
  [Key]
 public int StaffId { get; set; }

 [Required]
 [MaxLength(100)]
 public string PersonalFileNumber{ get; set; } = string.Empty;

 [Required]
 [MaxLength(100)]
 public string DepartmentId {get;set;} = string.Empty;

 [Required]
 [MaxLength(100)]
 public string Department {get;set;} = string.Empty;

 [Required]
 [MaxLength(100)]
 public string FirstName { get; set; } = string.Empty;

 [Required]
 [MaxLength(100)]
 public string LastName { get; set; } = string.Empty;
 
 [Required]
 [MaxLength(100)]
 public string Designation{ get; set; } = string.Empty;

 [Required]
 [MaxLength(100)]
 public string Registered {get;set;} = string.Empty;

 [Required]
 [MaxLength(100)]
 public string Active {get;set;} = string.Empty;

}