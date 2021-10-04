using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Drink.Models.BlogF;
using BE_Drink.Models;
using BE_Drink.Models.Blog;
using BE_Drink.Models.Product;

namespace BE_Drink.DbContext
{
    public class BE_DrinkContext : IdentityDbContext
    {
        public BE_DrinkContext(DbContextOptions<BE_DrinkContext> options)
            : base(options)
        {
        }
        public DbSet<BE_Drink.Models.ProductTable> products { get; set; }
        public DbSet<BE_Drink.Models.Customer.User> users { get; set; }

        public DbSet<BE_Drink.Models.BlogF.Metarial> metarials { get; set; }
        public DbSet<BE_Drink.Models.BlogF.Content> contents { get; set; }
        public DbSet<BE_Drink.Models.Blog.Step> Step { get; set; }
        public DbSet<BE_Drink.Models.Bloger> Blogers { get; set; }
        public DbSet<BE_Drink.Models.Product.ImgProductFeature> ImgProductFeature { get; set; }
    }
}
