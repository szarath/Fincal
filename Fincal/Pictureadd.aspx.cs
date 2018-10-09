using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Pictureadd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }
        }
        protected void btnpicadd_ServerClick(object sender, EventArgs e)
        {
            UserData user = (UserData)(Session["User"]);
          
            string base64String = "";
            if (picchoice.PostedFile.ContentLength != 0 && base64String != "Nopic")
            {
                base64String = ImageFunctions.validateImage(new BinaryReader(picchoice.PostedFile.InputStream).ReadBytes(picchoice.PostedFile.ContentLength));

                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();

                findata.Open();


                findata.insertpicture(base64String, txtpicdesc.Value, user.getID().ToString());


                findata.Close();


                Response.Redirect("Allpictures.aspx");
            }
            else
            {
                Invlaidpic.InnerHtml = "<p>Please add a picture to proceed</p>";
                base64String = "Nopic";
            }









        }



    }
}