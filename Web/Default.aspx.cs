using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEventModelExperiments
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected override void OnPreRenderComplete(EventArgs e)
        {

            base.OnPreRenderComplete(e);
        }
    }
}
