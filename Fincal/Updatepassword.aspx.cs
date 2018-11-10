using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Updatepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) //Logged in
            {
                Title = "Fincal: Password Update ";
                lblup.InnerHtml =((UserData)Session["User"]).getFirstName() + "     Change your password";
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnupdate_ServerClick(object sender, EventArgs e)
        {
            Userservice.UserserviceClient userdata = new Userservice.UserserviceClient();
            userdata.Open();
            Object[] userinfo = userdata.Authenticate(txte.Value, Security.HashPassword(txtop.Value));

            userdata.Close();
            userdata = null;
            if (userinfo != null)
            {
                if (txtnp.Value.Length <= 8)
                {
                    invalidp.InnerHtml = "Error!!!</br> Make sure all details are filled";
                }

            


                if (txtnp.Value.Equals(txtnpc.Value))
                {


                    Userservice.UserserviceClient userservice = new Userservice.UserserviceClient();
                    userservice.Open();
                    int changed = 0;
                    changed = userservice.updatepass (((UserData)Session["User"]).getID(), Security.HashPassword(txtop.Value), Security.HashPassword(txtnp.Value), txte.Value);
                    userservice.Close();
                    if (changed == 1)
                    {
                        Session["User"] = null;
                        changepage();
                    }
                    else
                    {
                        invalidp.InnerHtml = "Error!!!</br> Make sure all details are filled";
                    }
                }
                else
                {
                    invalidp.InnerHtml = "*Please retype email correctly</br>";
                }
            }
            else
            {
               invalidp.InnerHtml = "*Current password or Email is wrong</br>";
            }
        }

        protected void changepage()
        {
            updatepc.InnerHtml = "<span class='card-title bold'>Password Updated</span>";
            updatepc.InnerHtml += "<p>Password changed</br></br>Login using new password</p>";
            updatepc.InnerHtml += "</div>";
            updatepc.InnerHtml += "<div class='card-action'>";
            updatepc.InnerHtml += "<a href=\"Login.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Continue</a>";
        }

       
    }
}