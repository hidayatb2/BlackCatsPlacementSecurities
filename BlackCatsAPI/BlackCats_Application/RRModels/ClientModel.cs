using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace BlackCats_Application.RRModels;

public class ClientRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    [Required]
    public string ContactNo { get; set; } = string.Empty;

    [Required]
    public DateOnly AgreementDate { get; set; }

    public int TotalEmployees { get; set; }

    [Required]
    public int SecurityDeposit { get; set; }

    public IFormFile? AgreementDocument { get; set; } = null;

    [Required]
    public Guid UserId { get; set; }
}


public class ClientResponse
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string ContactNo { get; set; } = string.Empty;

    public DateOnly AgreementDate { get; set; }

    public int TotalEmployees { get; set; }

    public int SecurityDeposit { get; set; }

    public string DocumentPath { get; set; }= string.Empty;



}

public class ClientUpdateRequest
{

    [Required]
    public Guid ClientId { get; set; }


    [Required]
    public string Name { get; set; } = string.Empty;

    
    [Required]
    public string Address { get; set; } = string.Empty;


    [Required]
    public string ContactNo { get; set; } = string.Empty;


    [Required]
    public int SecurityDeposit { get; set; }

    [Required]
    public IFormFile AgreementDocument { get; set; } = null!;


}