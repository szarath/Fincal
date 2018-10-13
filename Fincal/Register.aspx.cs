using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Register : System.Web.UI.Page
    {
        private object[] skills;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
                Response.Redirect("Default.aspx");

            Title = "Fincal: Registration";



            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();

            skills = findata.getskills();

            

            

            if (!IsPostBack)
            {
                for (int i = 0; i < skills.Length; i++)
                {
                    skilldrop.Items.Add(new ListItem( (string)skills[i], i.ToString() ));

                }

            }
            findata.Close();
        }


        protected void RegisterUser_ServerClick(object sender, EventArgs e)
        {
            String innerHTML = "<p>";



            Boolean blnRegister = true;


            if ((txtFirstName.Value.Equals("")) || (txtLastName.Value.Equals("")) || (txtEmail.Value.Equals("")) || (txtConfirmEmail.Value.Equals("")) || (txtDoB.Value.Equals("")) || (txtUsername.Value.Equals("")) || (txtPassword.Value.Equals("")) || (txtConfirmPassword.Value.Equals("")) || skilldrop.Items[skilldrop.SelectedIndex].Text.Equals("Choose yout option"))
            {
                blnRegister = false;

                innerHTML += "*Please make sure you have filled in all the fields<br/>";
            }
            else
            {
                if (!(txtEmail.Value.Contains("@")))
                {
                    blnRegister = false;

                    innerHTML += "*Your email is not valid<br/>";
                }

                if (!(txtConfirmEmail.Value.Equals(txtEmail.Value)))
                {
                    blnRegister = false;

                    innerHTML += "*Your emails do not match<br/>";
                }



                if (!(txtPassword.Value.Length >= 8))
                {
                    blnRegister = false;

                    innerHTML += "*Your Password is too short. <br/> It has to be more than 8 characters<br/>";
                }
                if (!(txtConfirmPassword.Value.Equals(txtPassword.Value)))
                {
                    blnRegister = false;

                    innerHTML += "*Your passwords do not match<br/>";

                }

            }

            innerHTML += "</p>";


            if (blnRegister)
            {
                Userservice.UserserviceClient service = new Userservice.UserserviceClient();

                service.Open();
                int index = skilldrop.SelectedIndex;
                service.insertUser(txtUsername.Value, Security.HashPassword(txtPassword.Value), txtFirstName.Value, txtLastName.Value, txtEmail.Value, Convert.ToDateTime(txtDoB.Value), index.ToString());

                service.Close();

                changePage();

            }
            else
            {
                invalidRegister.InnerHtml = innerHTML;
            }
        }

  
        protected void changePage()
        {
        
            regCard.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";
            
            regCard.InnerHtml += "<div class=\"card white\">";
            regCard.InnerHtml += "<div class=\"card-content Black-text\">";
            regCard.InnerHtml += "<span class=\"card-title bold\">Registration Successful</span>";
            regCard.InnerHtml += "<p>You have successfully registered your account</p>";
            regCard.InnerHtml += "</div>";
            regCard.InnerHtml += "<div class=\"card-action\">";
            regCard.InnerHtml += "<a href=\"Login.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Continue</a>";
            regCard.InnerHtml += "</div>";
            regCard.InnerHtml += "</div>";
            regCard.InnerHtml += "</div>";
        }
    }
}