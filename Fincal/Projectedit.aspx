﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Projectedit.aspx.cs" Inherits="Fincal.Projectedit" %>
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
  

    <div class="row" id="projecteditdiv" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">Edit Project</span>
              
                <div id="Invlaidproject" runat="server" class="row red-text text-lighten-2">

                </div>

                  <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea id="txtprojt" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojt">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea id="txtprojd" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojd">Description</label>
                    </div>
                </div>

                 <div class="row">
                    <div class="input-field col  s12 m12 l12">
                          <i class="material-icons prefix">people</i>
                        <select id="Currentmembers" runat="server" multiple>
                         
                           
                        </select> 
                        <label for="Currentmembers">Current Members</label>
                             <blockquote>Remove members from the project.</blockquote>
                    </div>

                   
                     </div>
          <div class="row">
                    <div class="input-field col  s12 m12 l12">
                          <i class="material-icons prefix">people</i>
                        <select id="Othermembers" runat="server" multiple>
                         
                           
                        </select> 
                        <label for="Othermembers">Other Members</label>
                             <blockquote>Add members to the project.</blockquote>
                    </div>

                   
                     </div>
             
        
                    
                
                 
            </div>
            <div class="card-action">
                  <a href="#AcceptUpdate" class="btn waves-effect waves-light modal-trigger"><i class="material-icons left">save</i>Accept</a>

              <a href="Projects.aspx" class="waves-effect waves-light btn red"><i class="material-icons left">cancel</i>Cancel</a>
            </div>
          </div>
        </div>
      </div>

                          <div class="modal" id="AcceptUpdate">
                            <div class="modal-content">
                              <h4>Confirm Accept</h4>
                              <p>Are you sure you want to edit the project?</p>
                            </div>
                            <div class="modal-footer">
                              <a href="#" runat="server" OnServerClick="btnprojedit_ServerClick" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-orange btn-flat orange-text lighten-2">Cancel</a>
                            </div>
                          </div>

</asp:Content>
