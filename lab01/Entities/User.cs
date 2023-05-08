using System;
using Microsoft.AspNetCore.Identity;

namespace lab01.Entities
{
  public class User : IdentityUser
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Secret { get; set; }
    public string Extra { get; set; }
    public UserRole Role { get; set; }
  }

  public enum UserRole
  {
    Admin,
    User
  }
}

