using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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

    public IFormFile AgreementDocument { get; set; } = null!;

    [Required]
    public Guid UserId { get; set; }
}


public class ClientResponse
{
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string ContactNo { get; set; } = string.Empty;

    public DateOnly AgreementDate { get; set; }

    public int TotalEmployees { get; set; }

    public int SecurityDeposit { get; set; }



}

public class ClientUpdateRequest
{
    public Guid ClientId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string ContactNo { get; set; } = string.Empty;

    public int SecurityDeposit { get; set; }

}