using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

// Blueprints
public class UserAuth
{
    public string Username {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
}
public class UserInfo
{
    public int Id {get; set;}
    public string Username {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
}

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
    public DbSet<UserInfo> Users {get; set;}
}