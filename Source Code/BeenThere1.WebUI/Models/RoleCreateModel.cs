using System;
using System.ComponentModel.DataAnnotations;

namespace BeenThere1.WebUI.Models
{
    public class RoleCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
