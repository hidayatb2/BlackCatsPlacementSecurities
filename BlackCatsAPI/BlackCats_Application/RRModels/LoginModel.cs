using BlackCats_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.RRModels;

public class LoginDto
{
    [Required(ErrorMessage = "Please enter valid email")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}

public class LoginResponse
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ContactNo { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }

    public string Token { get; set; } = string.Empty;

}
