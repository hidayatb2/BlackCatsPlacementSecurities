using BlackCats_Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlackCats_Application.RRModels;

public class UserRequest
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string ContactNo { get; set; } = string.Empty;

    [Required]
    public UserRole UserRole { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;


    [Compare(nameof(Password), ErrorMessage = "Password & ConfirmPassword Does Not Match")]
    public string ConfirmPassword { get; set; } = string.Empty;



}

public class UserResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public UserRole UserRole { get; set; } 

    public string ContactNo { get; set; } = string.Empty;




}
