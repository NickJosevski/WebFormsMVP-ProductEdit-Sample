using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormEventModelExperiments.Logic.Domain;

namespace WebFormEventModelExperiments.Logic.Views.Model
{
    public interface IEditProductModel
    {
         Product Product { get; set; }

         EditMode PageEditMode { get; set; }

         string ActionText { get; set; }

         string HeaderText { get; set; }

         bool IsNew { get; set; }
         bool IsValid { get; set; }
    }

    public class EditProductModel : IEditProductModel
    {
        public EditProductModel()
        {
        }

        public Product Product { get; set; }

        public EditMode PageEditMode { get; set; }

        public string ActionText { get; set; }

        public string HeaderText { get; set; }

        public bool IsNew { get; set; }
        public bool IsValid { get; set; }
    }
}
