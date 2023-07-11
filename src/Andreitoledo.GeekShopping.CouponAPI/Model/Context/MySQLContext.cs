﻿using Microsoft.EntityFrameworkCore;

namespace Andreitoledo.GeekShopping.CouponAPI.Model.Context
{
    public class MySQLContext : DbContext
    {        
        public MySQLContext(DbContextOptions<MySQLContext> options) 
            : base(options) { }
                
        public DbSet<Coupon> Coupons { get; set; }        
     
    }
}
