using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Security.Principal;
using System.Web.Security;

namespace TwitterClone.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }


    public class UserModel : IPrincipal
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string JoinedDate { get; set; }
        public UserModel()
        {
        }

        public IIdentity Identity
        {
            get;
            set;

        }
        public UserModel(string username)
        {
            Identity = new GenericIdentity(username);
        }

        public bool IsInRole(string role)
        {
            if (!string.IsNullOrEmpty(this.UserName))
            {
                return true;
            }
            else { return false; }
        }
    }


    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Fullname")]
        // [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string FullName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        // [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Email { get; set; }


        [Required]

        [Display(Name = "Join Date")]
        // [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public DateTime Joined { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
