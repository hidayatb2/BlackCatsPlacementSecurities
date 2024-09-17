using BlackCats_Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlackCats_Application.RRModels;

public class UserRequest
{
    [Required]
    public string UserName { get; set; } = string.Empty;


    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;


    [Required]
    public string Name { get; set; } = string.Empty;


    [Required]
    public string ContactNo { get; set; } = string.Empty;


    [Required]
    public UserRole UserRole { get; set; }

}


public class UserResponse
{
    public Guid Id { get; set; }


    public string UserName { get; set; } = string.Empty;


    public string Email { get; set; } = string.Empty;


    public string Name { get; set; } = string.Empty;


    public string ContactNo { get; set; } = string.Empty;


    public UserRole UserRole { get; set; }


    public UserStatus UserStatus { get; set; }
    public DateTime CreatedAt { get; set; }
}


public class UserUpdateRequest
{
    public Guid Id { get; set; }


    public string Name { get; set; } = string.Empty;


    public string ContactNo { get; set; } = string.Empty;


    public UserRole UserRole { get; set; }


    public UserStatus UserStatus { get; set; }
}


public class UserUpdateResponse : UserUpdateRequest
{

}