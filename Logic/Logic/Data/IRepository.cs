using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormEventModelExperiments.Logic.Domain;

namespace WebFormEventModelExperiments.Logic.Data
{
    public interface IRepository
    {
        Product GetProduct(int id);
        bool SaveProduct(Product p);
    }
}
