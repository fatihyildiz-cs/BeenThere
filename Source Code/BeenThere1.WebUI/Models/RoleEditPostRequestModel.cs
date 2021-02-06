using System;
using System.Collections.Generic;

namespace BeenThere1.WebUI.Models
{
    public class RoleEditPostRequestModel
    {
        public string RoleID { get; set; }

        public string RoleName { get; set; }

        public string[] IdsThatWillBeDeleted { get; set; }

        public string[] IdsThatWillBeAdded { get; set; }
    }
}
