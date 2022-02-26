using System;
using System.ComponentModel.DataAnnotations;

namespace CMP_1005_Dogfood_Models.Models
{
    public class Dogfood
    {
        [Key]
        public string UPC { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
