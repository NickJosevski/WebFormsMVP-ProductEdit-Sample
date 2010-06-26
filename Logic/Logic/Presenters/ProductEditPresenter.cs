using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebFormsMvp;
using WebFormEventModelExperiments.Logic.Domain;
using WebFormEventModelExperiments.Logic.Views.Model;
using WebFormEventModelExperiments.Logic.Views;
using WebFormEventModelExperiments.Logic.Data;

namespace WebFormEventModelExperiments.Logic.Presenters
{
    public class ProductEditPresenter : Presenter<IEditProductView<EditProductModel>>
    {
        public IRepository Repository;
        public Int32 Id { get; set; }
        public String Home { get; set; }
        
        public ProductEditPresenter(IEditProductView<EditProductModel> view)
            : base(view)
        {
            View.Load += View_Load;
            View.UpdatingProduct += View_Update;
            View.DeletingProduct += View_Delete;

        }

        public override void ReleaseView()
        {
            // Standard:
            View.Load -= View_Load;
            View.UpdatingProduct -= View_Update;
            View.DeletingProduct -= View_Delete;
        }

        void View_Load(object sender, EventArgs e)
        {
            Repository = new FakeRepository();
            PopulateViewModel();
            Home = "Default.aspx";
        }

        void View_Update(object sender, UpdateProductEventArgs e)
        {
            Save(e.Product);
            Response.Redirect(Home);
        }

        void View_Delete(object sender, DeleteProductEventArgs e)
        {
            Delete(e.Product);
            Response.Redirect(Home);
        }

        public void PopulateViewModel()
        {
            Id = GetId();

            var mode = EditMode.Add;

            View.Model.Product = Repository.GetProduct(Id);

            if (Id > 0)
            {
                //Edit mode setup:
                mode = EditMode.Edit;
                View.Model.ActionText = "Update";
                View.Model.HeaderText = "Edit Product";
            }
            else
            {
                View.Model.ActionText = "Create";
                View.Model.HeaderText = "Add New Product";
            }

            View.Model.PageEditMode = mode;
            View.Model.IsValid = true;
        }

        public int GetId()
        {
            int id = 0;

            Int32.TryParse(Request.QueryString["id"], out id);

            return id;
        }

        public void Save(Product p)
        {
            Repository.SaveProduct(p);
        }

        public void Delete(Product p)
        {
            p.IsDeleted = true;
            Repository.SaveProduct(p);
        }
    }

}
