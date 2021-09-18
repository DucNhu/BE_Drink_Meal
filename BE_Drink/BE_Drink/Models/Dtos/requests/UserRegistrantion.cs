using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.Models.Dtos
{
    public class UserRegistrantion
    {
        public string fullName { get; set; }

        [EmailAddress(ErrorMessage = "pls enter your email")]
        public string email { get; set; }

        public string password { get; set; }

        public Boolean isAdmin { get; set; }

        public Boolean isShipper { get; set; }

        public Boolean isActive { get; set; }

        public int type { get; set; }

        public Boolean status { get; set; }
    }
}
