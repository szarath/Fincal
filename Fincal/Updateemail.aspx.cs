using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Updateemail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {
                Title = "Email Update";
                lblupdateemail.InnerHtml = ((UserData)Session["User"]).getFirstName() + "     Change your email";

            }
            else
            { Response.Redirect("Login.aspx"); }
         

        }

        protected void btnemailupdate_ServerClick(object sender, EventArgs e)
        {
            Userservice.UserserviceClient userdata = new Userservice.UserserviceClient();
            userdata.Open();
            Object[] userinfo = userdata.Authenticate(txtoe.Value,Security.HashPassword(txtpass.Value));

            userdata.Close();
            userdata = null;
            if (userinfo != null)
            {
                if (txtne.Value.Equals(txtoe.Value))
                {
                    Userservice.UserserviceClient userservice = new Userservice.UserserviceClient();
                    userservice.Open();
                    int changed = 0;

                    changed = userservice.updateemail(((UserData)Session["User"]).getID(), Security.HashPassword(txtpass.Value), txtoe.Value, txtne.Value);
                    userservice.Close();

                    if (changed == 1)
                    {
                        Session["User"] = null;
                        changepage();

                    }
                    else
                    {
                        invalide.InnerHtml += "Error!!!</br> Make sure all details are filled";

                    }
                }
                else
                {
                    invalide.InnerHtml = "*Please retype email correctly</br>";


                }

            }
            else
            {
                invalide.InnerHtml = "*Current password or Email is wrong</br>";
            }


        }

        protected void changepage()
        {
            updatec.InnerHtml = "<span class='card-title bold'>Update Email</span>";
            updatec.InnerHtml += "<p>Email changed</br></br>Login using new email</p>";
            updatec.InnerHtml += "</div>";
            updatec.InnerHtml += "<div class='card-action'>";
            updatec.InnerHtml += "<a href=\"Login.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Continue</a>";
        }
    }
}