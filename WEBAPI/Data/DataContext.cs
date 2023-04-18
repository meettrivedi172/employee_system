using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Entity;

namespace WEBAPI.Data
{
    public class DataContext:DbContext
    {
          public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Employees{ get; set; }
    }
}