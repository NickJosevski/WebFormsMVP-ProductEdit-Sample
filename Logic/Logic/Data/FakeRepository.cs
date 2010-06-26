using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormEventModelExperiments.Logic.Domain;

namespace WebFormEventModelExperiments.Logic.Data
{
    public class FakeRepository : IRepository
    {
        public Product GetProduct(int id)
        {
            if (id > 0)
            {
                return new Product()
                {
                    Id = id,
                    IsDeleted = false,
                    ProductName = "Sample Product",
                    ProductDescription = "Is teh awesome"
                };
            }
            else
                return new Product();
        }

        public bool SaveProduct(Product p)
        {
            bool fakeSaveComplete = true;

            return fakeSaveComplete;
        }
    }
}
