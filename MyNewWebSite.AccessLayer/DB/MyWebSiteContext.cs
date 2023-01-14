using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using MyNewWebSite.AccessLayer.Entity;

namespace MyNewWebSite.AccessLayer.DB
{
    public class MyWebSiteContext : DbContext
    {
        public DbSet<Users>? Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost:3306;database=mynewwebsite;user=test;password=1qaz!QAZ");
        }
    }
}
