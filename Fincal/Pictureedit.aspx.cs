using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Pictureedit : System.Web.UI.Page
    {
        private UserData user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString.Get("id");
                string htmldata = "";
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                 user = (UserData)(Session["User"]);
                findata.Open();

                object[] picture = findata.getpic(id,user.getID());

                findata.Close();



                htmldata += "<div class=\"card-image\">";

                htmldata += "<img  class= \"responsive-img\" src = 'data:image/jpeg;base64," + (string)picture[1] + "'/>";


                htmldata += "</div>";
                txtpictitle.Value = (string)picture[2];
                txtpicdescription.Value = (string)picture[3];




                pictureholder.InnerHtml = htmldata;
            }


        }




        protected void btnUpdatepic_ServerClick(object sender, EventArgs e)
        {

            Boolean postad = true;

            user = (UserData)(Session["User"]);

            if (txtpicdescription.Value.Equals(""))
            {
                Invlaidtask.InnerHtml = "<p>Please provide a description</p>";
                postad = false;
                return;
            }

            if (postad)
            {
                string id = Request.QueryString.Get("id");
               Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();

                findata.Open();



                int success = findata.updatepic(id, txtpictitle.Value, txtpicdescription.Value, user.getID());




                findata.Close();
                Response.Redirect("Allpictures.aspx");

            }

        }


        protected void btnDeletepic_ServerClick(object sender, EventArgs e)
        {
            user = (UserData)(Session["User"]);
            string id = Request.QueryString.Get("id");
            Dataservice.DatamanagementClient findatae = new Dataservice.DatamanagementClient();

            findatae.Open();
            findatae.deletepicture(id,user.getID());

            findatae.Close();
            Response.Redirect("Allpictures.aspx");

        }
    }
}