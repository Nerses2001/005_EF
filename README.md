# 005_EF
## One-to-One Relationship in Entity Framework

This repository presents a code example demonstrating a "one-to-one" relationship in Entity Framework.

## Defining the "One-to-One" Relationship

A "one-to-one" relationship in Entity Framework is a connection between two entities, where each entity from one data set (table) is associated with one and only one entity from another data set (table).

## Code Structure

### User

A class representing a user. Linked to the UserProfile entity through the UserProfile property.

```csharp
namespace _005_EF
{
    internal class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
```

## UserProfile

A class representing a user profile. It is linked to the User entity through the User property.

```csharp
namespace _005_EF
{
    internal class UserProfile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
```
## Context

The `Context` class represents the Entity Framework database context. It includes data sets for the `User` and `UserProfile` entities and is configured to work with SQL Server.

```csharp
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _005_EF
{
    internal class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "OneToOneTest",
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
    }
}
```
## Main Code Meaning

The provided code illustrates the establishment of a "one-to-one" relationship between the `User` and `UserProfile` entities. In this relationship, each user is associated with only one profile, defining its characteristics. This design allows for effective data storage related to users by utilizing a separate profile table, ultimately minimizing data redundancy.
