using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class dbcontext : DbContext
    {
        public dbcontext() : base("name = ConnString1")
        {

        }
        public DbSet<CNInfo> CNInfoset { get; set; }
        public DbSet<Destination> Destinationset { get; set; }
        public DbSet<PartyInfo> PartyInfoset { get; set; }
        public DbSet<RateInfo> RateInfoset { get; set; }
        public DbSet<SPOInfo> SPOInfoset { get; set; }
        public DbSet<UserInfo> UserInfoset { get; set; }

    }
}