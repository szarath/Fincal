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
                        <label for="txtiss">Issues Working on</label>
                    </div>
                </div>
        
                    <div class="row">
                         <div class="input-field col s12 m6 ">
                               <i class="material-icons prefix">notification_important</i>
                          <textarea readonly id="txtschedule" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtschedule">Issues Working on</label>

                         </div>
                    </div>
                
                 
            </div>
            <div class="card-action">
             <a href="Default.aspx" class="waves-effect waves-light btn"><i class="material-icons left">home</i>Home</a>
              <a href="Projects.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">assignment</i>Projects</a>
            </div>
          </div>
        </div>
      </div>


  

</asp:Content>
