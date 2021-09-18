using BE_Drink.Config;
using BE_Drink.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.Models.Dtos.response
{
    public class RegistrationResponse : AuthResult
    {
        public object Infor { get; set; }
    }
}
