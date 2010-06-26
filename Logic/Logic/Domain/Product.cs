using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormEventModelExperiments.Logic.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public String ProductName { get; set; }
        public String ProductDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        List<ProductImage> Images { get; set; }
    }
}
