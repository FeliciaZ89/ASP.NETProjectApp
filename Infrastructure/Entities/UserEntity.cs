﻿
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;
    [ProtectedPersonalData]
    public string? Biography { get; set; }
    [ProtectedPersonalData]
    public string? ProfileImageUrl { get; set; }
    public bool IsExternalAccount { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }
    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
}