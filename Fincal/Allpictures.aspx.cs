using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Allpictures : System.Web.UI.Page
    {
        private string htmldata = "<div class='row'>";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                findata.Open();
                // UserData currentUser = (UserData)(Session["User"]);
                UserData user = (UserData)Session["User"];
                Object[][] pictures = findata.getalluserpictures(user.getID().ToString());


                if (pictures != null)
                { 
                for (int i = 0; i < pictures.Length; i++)
                {
                    // htmldata += "<a class=\"carousel - item\" href=\"Pictureedit?id=" + (string)pictures[i][0] + "\"><img style='width:250px;height:250px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + (string)pictures[i][1] + "'/></a>";


                    htmldata += "<a href=\"Pictureedit?id=" + (string)pictures[i][0] + "\">";
                    htmldata += "<div class=\"col s12 m2 10 \">";
                    htmldata += "<div class=\"card hoverable card-image\">";

                    //   htmldata += "<div class=\" card-content\">";


                    htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + (string)pictures[i][1] + "'/>";



                    //htmldata += "</div>";

                    htmldata += "</div>";
                    htmldata += "</div>";

                }
                }
                // htmldata += "<a class=\"carousel - item\" href=\"#one!\"><img style='width:300px;height:300px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/></a>";
                htmldata += "</div>";



                findata.Close();
                picturecarousel.InnerHtml = htmldata;
            }
            else
            {
                Response.Redirect("Allpictures.aspx");
            }
        }
    }
}