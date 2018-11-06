using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issueview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string htmldata = "";

            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
          
            if (!IsPostBack)
            {
                string id = Request.QueryString.Get("id");
                findata.Open();
                object[] issdetails = findata.getissuedetails(id);

                if (issdetails != null)
                {
                    object[] projdetails = findata.getprojectdetails((string)issdetails[3]);


                    txtprojname.Value = (string)projdetails[1];

                    object[] userdetails = findata.getspecificuserinformation((string)projdetails[3]);

                    txtprojleader.Value = (string)userdetails[1];

                    txtissdesc.Value = (string)issdetails[2];

                    txtisstitle.Value = (string)issdetails[1];



                }





               findata.Close();
            }
               
        }
    }
}