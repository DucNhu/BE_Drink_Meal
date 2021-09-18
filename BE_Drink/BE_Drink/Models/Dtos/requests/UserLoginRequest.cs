using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.Models.Dtos.requests
{
    public class UserLoginRequest
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}
