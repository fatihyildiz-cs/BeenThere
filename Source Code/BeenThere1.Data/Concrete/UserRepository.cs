using System;
using System.Collections.Generic;
using System.Linq;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;
using Microsoft.EntityFrameworkCore;

namespace BeenThere1.Data.Concrete
{
    public class UserRepository : IUserRepository
    {
        public List<BeenThereUser> AllUsersWithExperiences()
        {
            using (var context = new BTContext())
            {
                return context.Users.Include(l => l.Experiences).ToList();
            }
        }

        public BeenThereUser GetUserWithExperiencesByName(string userName)
        {
            using (var context = new BTContext())
            {
                return context.Users.Where(u=>u.UserName==userName).Include(l => l.Experiences).FirstOrDefault();
            }
        }
    }
}
