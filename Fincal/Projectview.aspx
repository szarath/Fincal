<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Projectview.aspx.cs" Inherits="Fincal.Projectview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">

    <div class="container">
          <div id="projview" runat="server" class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title bold">Project Specfication</span>
                
                <div id="invalidRegister" class="row red-text text-lighten-2" runat="server">

                </div>
                        
                          <div class="row">
                    <div    class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtprojt" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtprojt">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div   class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea readonly id="txtprojd" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtprojd">Description</label>
                    </div>
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
                               

                              <ul id="membersonproject" class="collection with-header col s12 m12 l12" runat="server">
                                <li class="collection-header"><h2><i class="material-icons prefix">people</i>Project members</h2></li>

                          </ul>
                    
                          </div>

                        </div>
              <div class="card-action">


  
                              
                               <a href="#AcceptDelete" class="btn red waves-effect waves-light modal-trigger red"><i class="material-icons left">delete</i>Delete</a>
                    <a href="Projects.aspx" runat="server"  class="btn orange waves-effect waves-light"><i class="material-icons left">assignment</i>Projects</a>
              </div>
              
          </div>
        </div>
    </div>
      <div class="modal" id="AcceptDelete">
    <div class="modal-content">
        <h4>Confirm Delete</h4>
        <p>Are you sure you wish to not be a part of this project anymore?</p>
    </div>
        <div class="modal-footer">
            <a href="#" runat="server" OnServerClick="btnDeletefromteam_ServerClick" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
            <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
        </div>
    </div>
        </div>
</asp:Content>
