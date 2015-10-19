using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace lab1.Models
{
    public class LoginModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remeber Me")]
        public bool RemeberMe { get; set; }

        [Display(Name = "Enter capcha")]
        public string Capcha { get; set; }
    }

    public class AuthModel
    {
        public string UserName { get; set; }
    }

    public class RegisterModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Retry password")]
        public string RetryPassword { get; set; }
    }
}