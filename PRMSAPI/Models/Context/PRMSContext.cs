using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRMSAPI.Models.Context
{
    public class PRMSContext : DbContext
    {
        public PRMSContext(DbContextOptions<PRMSContext> options):base(options)
        {

        }

        public DbSet<ProjectTask> ProjectTask { get; set; }
        public DbSet<MPTT> MPTT { get; set; }
    }
}
