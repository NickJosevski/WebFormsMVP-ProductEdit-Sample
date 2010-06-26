using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebFormsMvp;
using WebFormsMvp.Web;

using WebFormEventModelExperiments.Logic.Presenters;

using WebFormEventModelExperiments.Logic.Views;
using WebFormEventModelExperiments.Logic.Views.Model;
using WebFormEventModelExperiments.Logic.Domain;

namespace WebFormEventModelExperiments.Controls
{
    public partial class ProductEditControl : MvpUserControl<EditProductModel>, IEditProductView<EditProductModel>
    {
        //This fires twice on entry...
        public Product GetProduct(int maximumRows, int startRowIndex)
        {
            return Model.Product;
        }

        public void UpdateProduct(Product p, Product originalp)
        {
            OnUpdatingProductEventArgs(p, originalp);
        }

        public event EventHandler<UpdateProductEventArgs> UpdatingProduct;
        private void OnUpdatingProductEventArgs(Product p, Product oriP)
        {
            if (UpdatingProduct != null)
            {
                UpdatingProduct(this, new UpdateProductEventArgs(p, oriP));
            }
        }

        public void DeleteProduct(Product p)
        {
            OnDeletingProduct(p);
        }

        public event EventHandler<DeleteProductEventArgs> DeletingProduct;
        private void OnDeletingProduct(Product p)
        {
            if (DeletingProduct != null)
            {
                DeletingProduct(this, new DeleteProductEventArgs(p));
            }
        }

    }

}