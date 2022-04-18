
using System;
using System.ComponentModel.DataAnnotations;
public class Time
{
    
 [Key]
 public int TimeId { get; set; } 
 
 [Required]
 [MaxLength(100)]
 public string PersonalFileNumber {get;set;} = string.Empty;

 [Required]
 [MaxLength(100)]
 public string FirstName {get;set;} = string.Empty;

 [Required]
 [MaxLength(100)]
 public string LastName {get;set;} = string.Empty;
 public DateTime ClockInTime {get;set;} = DateTime.Now;
 public DateTime ClockOutTime {get;set;} = DateTime.Now;

}