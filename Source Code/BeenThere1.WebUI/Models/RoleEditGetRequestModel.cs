using System;
using System.Collections.Generic;
using BeenThere1.Entity;
using BeenThere1.WebUI.Identity;
using Microsoft.AspNetCore.Identity;

namespace BeenThere1.WebUI.Models
{
    public class RoleEditGetRequestModel
    {
        public IdentityRole Role { get; set; }

        public IEnumerable<BeenThereUser> RoleMembers { get; set; }

        public IEnumerable<BeenThereUser> RoleNonMembers { get; set; }
    }
}
