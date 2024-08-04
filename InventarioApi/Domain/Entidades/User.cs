using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    
    public string? UserName { get; set; }
    
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

}
