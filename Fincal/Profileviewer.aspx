<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profileviewer.aspx.cs" Inherits="Fincal.Profileviewer" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">

   

    <div class="row" id="projectdiv" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">User Information</span>
              
                <div id="Invlaidproject" runat="server" class="row red-text text-lighten-2">

                </div>
               
                  <div class="row">
                    <div class="input-field col s12 m6 ">
                         <i class="material-icons prefix">account_circle</i>
                        <textarea readonly id="txtusername" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtusername">Username</label>
                    </div>
                      <div class="input-field col s12 m6 ">
                         <i class="material-icons prefix">email</i>
                        <textarea readonly id="txtemail" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtemail">Email</label>
                    </div>
                </div>

                 <div class="row">
                       <div class="input-field col s12 m6 ">
                         <i class="material-icons prefix">assignment</i>
                        <textarea readonly id="txtproj" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtproj">Projects working on</label>
                    </div>
                      <div class="input-field col s12 m6 ">
                         <i class="material-icons prefix">notification_important</i>
                        <textarea readonly id="txtiss" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtiss">Issues working on</label>
                    </div>
                </div>
        
                    <div class="row">
                         <div class="input-field col s12 m6 ">
                               <i class="material-icons prefix">schedule</i>
                          <textarea readonly id="txtschedule" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtschedule">Schedule</label>

                         </div>
                          <div class="input-field col s12 m6 ">
                               <i class="material-icons prefix">code</i>
                          <textarea readonly id="txtskill" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtskill">Skill</label>

                         </div>
                    </div>
                
                   <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">link</i>
                        <textarea readonly id="txtgit" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtgit">GitHub link</label>
                    </div>
                  </div>

                <div class="row">
                    <div class="input-field col  s12 m12 l12">
                          <i class="material-icons prefix">assignment</i>
                        <select id="Projectchoose" runat="server" >
                            <option value="" disabled selected>Choose Project</option>
                           
                        </select> 
                        <label for="Projectchoose">Projects</label>
                          <blockquote>Choose the project to invite the user on.</blockquote>
                    </div>

                   
                     </div> 



            </div>
            <div class="card-action">
                  <a runat="server" id="btnaccept" href="#AcceptAdd" class="btn  waves-effect waves-light modal-trigger "><i class="material-icons left">save</i>Invite</a>
             <a href="Default.aspx" class="waves-effect waves-light red btn"><i class="material-icons left">cancel</i>Cancel</a>
          
            </div>
          </div>
        </div>
      </div>
    
    <div class="modal" id="AcceptAdd">
    <div class="modal-content">
        <h4>Confirm Project Invite</h4>
        <p>Are you sure you want to invite user to project<p>
    </div>
        <div class="modal-footer">
            <a href="#" runat="server" OnServerClick="btninviteadd_ServerClick" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
            <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
        </div>
    </div>

  

</asp:Content>
