using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.Models.Dtos
{
    public class UserRegistrantion
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Boolean isAdmin { get; set; }

        public Boolean isShipper { get; set; }

        public Boolean isActive { get; set; }

        public int type { get; set; }

        public Boolean status { get; set; }
    }
}
