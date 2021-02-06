using System;
using BeenThere1.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeenThere1.WebUI.Identity
{
    public class ApplicationContext: IdentityDbContext<BeenThereUser>
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {

        }


    }
}
