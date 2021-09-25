using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitCatAgarwadu.Models;

namespace RecruitCatAgarwadu.Data
{
    public class RecruitCatAgarwaduContext : DbContext
    {
        public RecruitCatAgarwaduContext (DbContextOptions<RecruitCatAgarwaduContext> options)
            : base(options)
        {
        }

        public DbSet<RecruitCatAgarwadu.Models.Candidate> Candidate { get; set; }

        public DbSet<RecruitCatAgarwadu.Models.Company> Company { get; set; }

        public DbSet<RecruitCatAgarwadu.Models.Industry> Industry { get; set; }

        public DbSet<RecruitCatAgarwadu.Models.JobTitle> JobTitle { get; set; }
    }
}
