using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.Models.Customer
{
    public class User : IdentityUser
    {
        public Boolean isAdmin { get; set; }

        public Boolean isShipper { get; set; }

        public Boolean isActive { get; set; }

        public int type { get; set; }

        public Boolean status { get; set; }
    }
}
