using Microsoft.AspNetCore.Identity;
using TODO.Application.Exceptions;

namespace TODO.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string Name { get; private set; } = null!;

    private ApplicationUser() { } // EF

    public ApplicationUser(string email, string name)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new DomainException("Email is required");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Name is required");
        }

        Id = Guid.NewGuid();
        Email = email;
        UserName = email;
        Name = name;
    }
}