using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null)
                Response.Redirect("Default.aspx");

            Title = "Login";






        }

        protected void LoginUser_ServerClick(object sender, EventArgs e)
        {
            btnLogin.Disabled = true;
            loginSpinner.Visible = true;
  
            Userservice.UserserviceClient service = new Userservice.UserserviceClient();

            service.Open();

            Object[] ds = service.Authenticate(user_name.Value, Security.HashPassword(password.Value));


            UserData user = null;

            if (!(ds == null))
            {
                user = new UserData((String)ds[0], user_name.Value, (String)ds[1], (String)ds[2], Convert.ToDateTime((String)ds[3]), (String)ds[4], (String)ds[5]);

              
                Session["User"] = user;
                Response.Redirect("Default.aspx");

            }
            else
            {

                invalidLogin.InnerHtml = "<p>Invalid username or password. Please try again.</p>";
                btnLogin.Disabled = false;
                loginSpinner.Visible = false;

            }

            service.Close();

        }
    }
}