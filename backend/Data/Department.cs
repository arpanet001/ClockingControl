using System.ComponentModel.DataAnnotations;

public class Department{
 [Key]
 public int DepartmentId{get;set;}

 [Required]
 [MaxLength(100)]
 public string DepartmentName{get;set;} = string.Empty;

}