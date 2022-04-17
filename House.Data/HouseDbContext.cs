using House.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Data
{
    public class HouseDbContext : IdentityDbContext
    {
        public HouseDbContext(DbContextOptions<HouseDbContext> options) : base(options) { }
        public DbSet<Houses> Houses { get; set; }
    }
}
