using System;
using System.ComponentModel.DataAnnotations;

namespace BeenThere1.WebUI.Models
{
    public class LoginModel
    {

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool IsNewAccount { get; set; }

        public bool PasswordReset { get; set; }

        public string Popup { get; set; }

    }
}
