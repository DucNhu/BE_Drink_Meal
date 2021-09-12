using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.DbContext
{
    public class BE_DrinkContext : IdentityDbContext
    {
        public BE_DrinkContext(DbContextOptions<BE_DrinkContext> options)
            : base(options)
        {
        }
        public DbSet<BE_Drink.Models.Product> products { get; set; }
    }
}
