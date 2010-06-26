using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using WebFormsMvp;
using WebFormEventModelExperiments.Logic.Views;
using WebFormEventModelExperiments.Logic.Views.Model;
using System.Web;
using WebFormEventModelExperiments.Logic.Presenters;
using WebFormEventModelExperiments.Logic.Data;
using WebFormEventModelExperiments.Logic.Domain;

namespace WebFormEventModelExperiments.Tests
{
    /// <summary>
    /// Summary description for ProductEditPresenterTests
    /// </summary>
    [TestClass]
    public class ProductEditPresenterTests
    {
        public ProductEditPresenterTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ProductEditPresenter_GetId_ReturnsIdFromQueryString()
        {
            //arange
            int expectedId = 1234;
            var view = MockRepository.GenerateMock<IEditProductView<EditProductModel>>();
            view.Expect(v => v.Model).Return(new EditProductModel());

            var httpContext = MockRepository.GenerateMock<HttpContextBase>();
            var httpRequest = MockRepository.GenerateMock<HttpRequestBase>();
            httpContext.Expect(h => h.Request).Return(httpRequest);
            httpRequest.Expect(r => r.QueryString["id"]).Return(expectedId.ToString());

            var p = new ProductEditPresenter(view) { HttpContext = httpContext };

            //act
            int actualId = p.GetId();

            //assert
            Assert.AreEqual<Int32>(expectedId, actualId);
        }

        [TestMethod]
        public void ProductEditPresenter_PopulateViewModel_SupplyingAnIdExpectingEditMode()
        {
            //arange
            var view = MockRepository.GenerateMock<IEditProductView<EditProductModel>>();
            view.Expect(v => v.Model).Return(new EditProductModel());

            var httpContext = MockRepository.GenerateMock<HttpContextBase>();
            var httpRequest = MockRepository.GenerateMock<HttpRequestBase>();
            httpContext.Expect(h => h.Request).Return(httpRequest);
            httpRequest.Expect(r => r.QueryString["id"]).Return("1");

            var repo = MockRepository.GenerateMock<IRepository>();
            repo.Expect(r => r.GetProduct(1)).Return(new Product());

            var p = new ProductEditPresenter(view) { HttpContext = httpContext, Repository = repo };
            
            var expectedMode = EditMode.Edit;

            //act
            p.PopulateViewModel();

            //assert
            Assert.AreEqual<EditMode>(expectedMode, p.View.Model.PageEditMode);
        }
    }
}
