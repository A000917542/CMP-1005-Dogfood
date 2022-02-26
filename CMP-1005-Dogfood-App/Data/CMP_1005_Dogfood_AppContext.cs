using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMP_1005_Dogfood_Models.Models;

namespace CMP_1005_Dogfood_App.Data
{
    public class CMP_1005_Dogfood_AppContext : DbContext
    {
        public CMP_1005_Dogfood_AppContext (DbContextOptions<CMP_1005_Dogfood_AppContext> options)
            : base(options)
        {
        }

        public DbSet<CMP_1005_Dogfood_Models.Models.Dogfood> Dogfood { get; set; }
    }
}
