#nullable disable

using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }

    public User() { } // For EF Core
}
