using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Profileviewer : System.Web.UI.Page
    {
        object[][] proj;
        object[][] iss;
        object[] userdata;
        string userid;
        int projnum;
        int isnum;
        protected void Page_Load(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            else
            {
                Title = "Fincal: Member Profile";


                UserData user = (UserData)(Session["User"]);

                userid = Request.QueryString.Get("id");
                findata.Open();
                proj = findata.getprojects(userid);
                iss = findata.getissues(userid);

              userdata =   findata.getspecificuserinformation(userid);

                if (userdata != null)
                {
                    if (proj != null)
                    {
                        for (int i = 0; i < proj.Length; i++)
                        {
                            projnum += 1;

                        }

                    }
                    else
                    {
                        projnum = 0;

                    }

                    if (iss != null)
                    {
                        for (int i = 0; i < iss.Length; i++)
                        {
                            isnum += 1;

                        }


                    }
                    else
                    {
                        isnum = 0;


                    }

                    txtproj.Value = projnum.ToString();
                    txtiss.Value = isnum.ToString();

                }
                else
                {


                }

               


            }

        }
    }
}