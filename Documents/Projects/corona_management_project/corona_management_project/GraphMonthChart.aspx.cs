using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace corona_management_project
{
    public partial class GraphMonthChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            h1.InnerText = "Month:" + (DateTime.Now).Month + " Year:" + (DateTime.Now).Year;
          
        }
    }
}