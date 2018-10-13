using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issueaccept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string htmldata = "";
            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            if (!IsPostBack)
            {





            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}