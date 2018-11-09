using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Meetingview : System.Web.UI.Page
    {
        string meetid;
        string mlid;
        string htmldata;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {

                meetid = Request.QueryString.Get("id");
              
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                findata.Open();
                object[] getmeetinginfo = findata.getmeetinginformation(meetid);
                object[] getmlinfo = findata.getmeetinglink(mlid);
                Object[][] getmeetingattendance = findata.getmeetingattendance(meetid);
             

                if (getmeetinginfo != null)
                {
                    object[] gerporjectdetails = findata.getprojectdetails((string)getmeetinginfo[4]);
                    object[] getuserinformaion = findata.getspecificuserinformation((string)getmeetinginfo[5]);
                    txtprojname.Value = (string)gerporjectdetails[1];
                  
                    txtmeett.Value = (string)getmeetinginfo[1];
                    txtmeetd.Value = (string)getmeetinginfo[2];
                    txtmeetdate.Value = (string)getmeetinginfo[3];

                    if (getmeetingattendance != null)
                    {
                        for (int i = 0; i < getmeetingattendance.Length; i++)
                        {


                            htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">Username: " + (string)getmeetingattendance[i][0] + "&nbsp&nbsp&nbsp      Attending: " + (string)getmeetingattendance[i][1] + "</span></li>";

                        }

                    }

                    else
                    {
                        htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">No memebrs yet</span></li>";
                    }


                    membersattending.InnerHtml += htmldata;


                }





                findata.Close();



            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnmeetdel_ServerClick(object sender, EventArgs e)
        {



        }
    }
}