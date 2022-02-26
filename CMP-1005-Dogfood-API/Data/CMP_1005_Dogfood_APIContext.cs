using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMP_1005_Dogfood_Models.Models;

namespace CMP_1005_Dogfood_API.Data
{
    public class CMP_1005_Dogfood_APIContext : DbContext
    {
        public CMP_1005_Dogfood_APIContext (DbContextOptions<CMP_1005_Dogfood_APIContext> options)
            : base(options)
        {
        }

        public DbSet<CMP_1005_Dogfood_Models.Models.Dogfood> Dogfood { get; set; }
    }
}
