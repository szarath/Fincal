using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Projectedit : System.Web.UI.Page
    {
        string pid;
        Object[][] members;
        object[] project;
        object[] projectmembers;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Title = "Fincal: Edit Project ";

                pid = Request.QueryString.Get("id");
                UserData user = (UserData)Session["User"];
                Currentmembers.Multiple = true;
                Othermembers.Multiple = true;
                if (!IsPostBack)
                {
                    Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                    findata.Open();
                  members = findata.getuserinformation();
                  project = findata.getprojectdetails(pid);
                     projectmembers = findata.getprojectmembers(pid);

                    txtprojt.Value = (string)project[1];
                    txtprojd.Value = (string)project[2];

                    for (int i = 0; i < members.Length; i++)
                    {
                        if ((string)members[i][0] == user.getID())
                        {

                        }
                        else
                        {
                            Boolean userisamember = false;
                            if(projectmembers != null)
                            { 
                            for (int j = 0; j < projectmembers.Length; j++)
                            {
                                if ((string)members[i][0] == (string)projectmembers[j])
                                {
                                    userisamember = true;
                                }


                            }
                            }

                            if (userisamember == true)
                            {
                                Currentmembers.Items.Add(new ListItem(" " + (string)members[i][1] + " " + (string)members[i][2] + " ", members[i][0].ToString()));
                            }
                            else
                            {
                                Othermembers.Items.Add(new ListItem(" " + (string)members[i][1] + " " + (string)members[i][2] + " ", members[i][0].ToString()));
                            }



                        }

                    }

                    findata.Close();

                }
            }
        }


        protected void btnprojedit_ServerClick(object sender, EventArgs e)
        {
            pid = Request.QueryString.Get("id");
            UserData user = (UserData)Session["User"];

            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            if (txtprojd.Value.Equals("") || txtprojt.Value.Equals(""))
            {

                projecteditdiv.InnerHtml += "*Please make sure you have filled in all the fields<br/>";

            }
            else
            {

              int result =  findata.updateproject(txtprojt.Value, txtprojd.Value, pid);


                if (result == 1)
                {
                    foreach (ListItem item in Currentmembers.Items)
                    {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());
                            
                            findata.deleteassiguserfromteam(id.ToString(), pid);
                        }

                    }
                    foreach (ListItem item in Othermembers.Items)
                    {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());
                            findata.insertprojectnotifications(pid, id.ToString());

                        }

                    }


                }


            }
            
            findata.Close();
            Response.Redirect("Projects.aspx");
        }




    }
}