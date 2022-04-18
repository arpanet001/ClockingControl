using System.ComponentModel.DataAnnotations;

public class Clocking{
 [Required]
 [MaxLength(100)]
 [Key]
 public string PersonalFileNumber{get;set;} = string.Empty;

 [Required]
 [MaxLength(100)]
 public string FirstName { get; set; } = string.Empty;

 [Required]
 [MaxLength(100)]
 public string LastName { get; set; } = string.Empty;

 

}