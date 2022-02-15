using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualityReport.Models
{
    public class ProjectNameRepeatContext : IdentityDbContext
    {
        public ProjectNameRepeatContext(DbContextOptions<ProjectNameRepeatContext> options)
            : base(options)
        {
        }
        public DbSet<ProjectName> ProjectNameRepeat { get; set; }
    }
}
