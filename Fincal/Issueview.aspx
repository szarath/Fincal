<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Issueview.aspx.cs" Inherits="Fincal.Issueview" %>
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
            <div id="regCard" runat="server" class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title bold">Accept/Reject Projects</span>
                
                <div id="invalidRegister" class="row red-text text-lighten-2" runat="server">

                </div>
                         <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">label_important</i>
                        <textarea readonly id="txtprojname" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojname">Project</label>
                    </div>
                </div>
                          <div class="row">
                    <div    class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtisstitle" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtisstitle">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div   class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea readonly id="txtissdesc" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtissdesc">Description</label>
                    </div>
                </div>

                <div class="row">
                    <div  class="input-field col s12 m12 l12">
                        <i class="material-icons prefix">account_circle</i>
                        <textarea readonly id="txtprojleader" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojleader">Project leader</label>
                    </div>
                </div>
                        
                    <div class="row">
                               

                  
                                    
                              <ul id="membersonissue" class="collection with-header col s12 m12 l12" runat="server">
                           <li class="collection-header"><h5>Issue members</h5></li>
                          </ul>
                    
                          </div>  

                        </div>
              <div class="card-action">

                  
        <a href="#AcceptDelete" class="btn red waves-effect waves-light modal-trigger red"><i class="material-icons left">delete</i>Delete</a>
               <a href="Issues.aspx" runat="server"  class="waves-effect waves-light btn orange"><i class="material-icons left">notification_important</i>Issues</a>

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
</asp:Content>
