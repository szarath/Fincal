<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Meetingaccept.aspx.cs" Inherits="Fincal.Meetingaccept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">
                 <style>
        .thumb 
        {
            height: 75px;
            margin: 10px 5px 0 0;
        }
    </style>
  

    <div class="row" id="projectdiv" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">Add Project</span>
              
                <div id="Invlaidproject" runat="server" class="row red-text text-lighten-2">

                </div>
                 <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">assignment</i>
                        <textarea readonly id="txtprojname" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojname">Project</label>
                    </div>
                      <div class="row">

                    <div  class="input-field col s12 m6 l6">
                        <i class="material-icons prefix">supervisor_account</i>
                        <textarea readonly id="txtptojectleaderuname" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtptojectleaderuname">Project Leader Username</label>
                    </div>

                      <div  class="input-field col s12 m6 l6">
                        <i class="material-icons prefix">email</i>
                        <textarea readonly id="txtptojectleaderemail" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtptojectleaderemail">Project Leader Email</label>
                     </div>

                </div>
                  <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtprojt" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojt">Meeting title</label>
                    </div>
                </div>

                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea readonly id="txtprojd" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojd">Meeting description</label>
                    </div>
                </div>

                <div class="row">
                     <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">date_range</i>
                        <textarea readonly id="Textarea1" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojd">Meeting date</label>
                    </div>

                </div>
                          </div>   
            <div class="card-action">
              <button id="btnmeetadd" class="btn waves-effect waves-light" runat="server" onserverclick="btnmeetadd_ServerClick"><i class="material-icons left">save</i>Add</button>
              <a href="Meeting.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">cancel</i>Cancel</a>
            </div>
         
        </div>
      </div>

</asp:Content>
