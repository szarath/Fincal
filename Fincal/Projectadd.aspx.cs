using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Fincal
{
    public partial class Projectadd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int numusers = 0; 
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else { 
            UserData user = (UserData)Session["User"];
            UserChoose.Multiple = true;
                if (!IsPostBack)
                {
                  
            Object[][] members = findata.getuserinformation();
           

            for (int i = 0; i < members.Length; i++)
            {
                    

                if ((string)members[i][0] == user.getID())
                {

                }
                else {

                            Object[][] userevents = findata.getalluserevents((string)members[i][0]);
                            int eventcount = 0;
                            if (userevents != null)
                            {
                               
                               
                                for (int j = 0; j < userevents.Length; j++)
                                {
                                    DateTime credate = DateTime.Parse((string)userevents[j][1]);
                                  


                                    int result = DateTime.Compare(credate, DateTime.Now.AddDays(14));

                                    if (result < 0)
                                    {
                                        eventcount += 1;
                                    }
                                   


                                }


                            }
                            if (numusers <= 30)
                            {
                                if (priority(eventcount).ToString() == "Free" || priority(eventcount).ToString() == "Occupied")
                                {
                                    UserChoose.Items.Add(new ListItem(" " + priority(eventcount).ToString() + " " + (string)members[i][1] + " " + (string)members[i][2] + " ", members[i][0].ToString()));
                                    numusers += 1;
                                }


                            }
                           
                         

                              

                         

                }


            }





            }
            
            }
            findata.Close();
        }

        protected void btnprojadd_ServerClick(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            UserData user = (UserData)Session["User"];
            Object[][] members = findata.getuserinformation();


            if(txtprojd.Value.Equals("") || txtprojt.Value.Equals("") || UserChoose.Items[UserChoose.SelectedIndex].Text.Equals("") || txtdom.Value.Equals("") || txttime.Value.Equals(""))
            {
                Invlaidproject.InnerHtml = "*Please make sure you have filled in all the fields<br/>";
                return;
            }
            else {

                int result = findata.createproject(txtprojt.Value, txtprojd.Value, user.getID(),DateTime.Now);
            //    int meeting = findata.insertmeeting("Project:" + txtprojt.Value, txtprojd.Value );

                if (result != 0 )
                {
                    foreach (ListItem item in UserChoose.Items)
                    {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());
                            findata.insertprojectnotifications(result.ToString(), id.ToString(),DateTime.Now);
                           
                        }

                    }
                    DateTime d = Convert.ToDateTime(txtdom.Value);
                    DateTime t = Convert.ToDateTime(txttime.Value);




                   DateTime dt = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
                    DateTime getdate = DateTime.Parse(XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc));


                    int createmeeting = findata.insertmeeting("Project:" + txtprojt.Value.ToString(), "First meeting for project", getdate.ToString(), result.ToString(), user.getID());


                }
            }

           
           

            findata.Close();
            changePage();
        }


        protected void changePage()
        {

            projectdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projectdiv.InnerHtml += "<div class=\"card white\">";
            projectdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projectdiv.InnerHtml += "<span class=\"card-title bold\">Project Added Successful</span>";
            projectdiv.InnerHtml += "<p>You have successfully added a Project</p>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "<div class=\"card-action\">";
            projectdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projectdiv.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn waves-effect waves-light orange\"><i class=\"material-icons left\">assignment</i>Projects</a>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }

   

        private  string priority(int num)
        {
            if (num <= 15)
            {
                return("Free");
            }
            else if (num <= 30)
            {

                return("Occupied");

            }
            else
            {
                return ("Busy");

            }
           

        }
    }
}