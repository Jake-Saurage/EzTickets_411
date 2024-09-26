using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningStarter.Entities
{
    // Common User class (base class)
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<UserRole> UserRoles { get; set; } = new();
    }

    // Tech user class
    public class Tech : User
    {
        public int Company { get; set; }
        public int AssignedTicket { get; set; }
    }

    // Client user class
    public class Client : User
    {
        public int Company { get; set; }
        public int TicketList { get; set; }
        public string Email { get; set; }  // Email property from IdentityUser already exists, so this is optional
        public string PhoneNumber { get; set; } // PhoneNumber also exists in IdentityUser base class
    }

    public class TechCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int Company { get; set; }
        public int AssignedTicket { get; set; }
    }

    // DTO for creating a Client user
    public class ClientCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int Company { get; set; }
        public int TicketList { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    // User entity configuration
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired();

            builder.Property(x => x.LastName)
                .IsRequired();

            builder.Property(x => x.UserName)
                .IsRequired();
        }
    }

    // Tech entity configuration
    public class TechEntityConfiguration : IEntityTypeConfiguration<Tech>
    {
        public void Configure(EntityTypeBuilder<Tech> builder)
        {
            builder.Property(x => x.Company)
                .IsRequired();

            builder.Property(x => x.AssignedTicket)
                .IsRequired();
        }
    }

    // Client entity configuration
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(x => x.Company)
                .IsRequired();

            builder.Property(x => x.TicketList)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(256) // varchar for email
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(15); // varchar for phone number
        }
    }
}
