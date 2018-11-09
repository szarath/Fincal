using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Usersearch : System.Web.UI.Page
    {
        string htmldata = "";
        protected void Page_Load(object sender, EventArgs e)
        {
        upev.InnerHtml = "";
           
            if (Session["User"] != null)
            {
               
                string searchterm = Request.QueryString.Get("term");
                indexTitle.InnerText = "Searching user: "+ searchterm;
                Userservice.UserserviceClient userdata = new Userservice.UserserviceClient();

                userdata.Open();

                Object[][] searchdetails = userdata.searchusers(searchterm);
                UserData user = (UserData)Session["User"];

                if (searchdetails != null)
                    {
                        for (int i = 0; i < searchdetails.Length; i++)
                        {
                        if ((string)searchdetails[i][0] == user.getID())
                        {

                        }
                        else
                        {
                            htmldata += "<a href=\"Profileviewer.aspx?uid=" + (string)searchdetails[i][0] + "\">";
                            htmldata += "<div class=\"col s12 m4 l0\">";


                            htmldata += "<div class=\"card horizontal hoverable\">";
                            /* htmldata += "<div class=\"card-image\">";

                             htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                             htmldata += "</div>";*/
                            htmldata += "<div class=\"card-stacked\">";
                            htmldata += "<div class=\"card-content black-text\">";
                            htmldata += "<span class=\"card-title\">" +
                                "<p class=\" bold trunctext\">" + (string)searchdetails[i][1] + "</p>";
                            htmldata += "</span>";
                            htmldata += "<p class=\"bold\">Email: " + (string)searchdetails[i][2] + "</p>";


                            htmldata += "</div>";
                            htmldata += "</div>";
                            htmldata += "</div>";
                            htmldata += "</div>";
                            htmldata += "</a>";
                        }

                          


                        }
                      




                    }
                    else
                    {
                    changePage();




                    }



                    userdata.Close();



                    upev.InnerHtml = htmldata;

            


            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void changePage()
        {

            htmldata+=  "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            htmldata += "<div class=\"card white\">";
            htmldata += "<div class=\"card-content Black-text\">";
            htmldata += "<span class=\"card-title bold\">No users exsist for identification</span>";
           
            htmldata += "</div>";

            htmldata += "</div>";
            htmldata += "</div>";
        }
    }
}