using CMP_1005_Dogfood_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP_1005_Dogfood_Models.Data
{
    class DogFoodContext : DbContext
    {
        public DogFoodContext(DbContextOptions<DogFoodContext> options)
            : base(options) { }

        public DbSet<Dogfood> DogFoods { get; set; }
    }
}
