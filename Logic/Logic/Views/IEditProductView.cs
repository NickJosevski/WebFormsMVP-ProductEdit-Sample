using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;
using WebFormEventModelExperiments.Logic.Domain;
using WebFormEventModelExperiments.Logic.Views.Model;

namespace WebFormEventModelExperiments.Logic.Views
{
    public interface IEditProductView<TModel> : IView<TModel> where TModel : class, new()
    {
        event EventHandler<UpdateProductEventArgs> UpdatingProduct;
        event EventHandler<DeleteProductEventArgs> DeletingProduct;
        //event EventHandler<EventArgs> CancelAction;
    }

    public class UpdateProductEventArgs : EventArgs
    {
        public Product Product { get; private set; }
        public Product OriginalProduct { get; private set; }

        public UpdateProductEventArgs(Product p, Product oriP)
        {
            Product = p;
            OriginalProduct = oriP;
        }
    }

    public class DeleteProductEventArgs : EventArgs
    {
        public Product Product { get; private set; }

        public DeleteProductEventArgs(Product p)
        {
            Product = p;
        }
    }

    public enum EditMode
    {
        Add = 1,
        Edit = 2
    }
}
