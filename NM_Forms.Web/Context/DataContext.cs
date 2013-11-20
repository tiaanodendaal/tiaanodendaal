using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NM_Forms.Web.Models;

namespace NM_Forms.Web.Context
{
    public class DataContext : DbContext
    {
        public DataContext(): base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}