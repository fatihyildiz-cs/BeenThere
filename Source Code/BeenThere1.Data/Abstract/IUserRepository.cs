using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.Data.Abstract
{
    public interface IUserRepository
    {
        List<BeenThereUser> AllUsersWithExperiences();

        BeenThereUser GetUserWithExperiencesByName(string userName);


    }
}
