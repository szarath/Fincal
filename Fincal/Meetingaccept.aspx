﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Meetingaccept.aspx.cs" Async="true" Inherits="Fincal.Meetingaccept" %>
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
              <span class="card-title">Meeting Invite</span>
              
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
                        <label for="txtptojectleaderuname">Project leader</label>
                    </div>

                      <div  class="input-field col s12 m6 l6">
                        <i class="material-icons prefix">email</i>
                        <textarea readonly id="txtptojectleaderemail" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtptojectleaderemail">Project leader email</label>
                     </div>

                </div>
                  <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtmeett" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtmeett">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea readonly id="txtmeetd" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtmeetd">Description</label>
                    </div>
                </div>

                <div class="row">
                     <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">date_range</i>
                        <textarea readonly id="txtmeetdate" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtmeetdate">Meeting date</label>
                    </div>

                </div>

                  <div class="row">
                               

                  
                                    
                              <ul id="membersattending" class="collection with-header col s12 m12 l12" runat="server">
                           <li class="collection-header"><h5>Members</h5></li>
                          </ul>
                    
                          </div>  


                          </div>   
            <div class="card-action">
           
                   <a runat="server" id="btnaccept" href="#AcceptInvite" class="btn  waves-effect waves-light modal-trigger red"><i class="material-icons left">save</i>Accept</a>
              <a href="Meeting.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">cancel</i>Cancel</a>
            </div>
         
        </div>
      </div>
        </div>

     <div class="modal" id="AcceptInvite">
    <div class="modal-content">
        <h4>Confirm Meeting</h4>
        <p>Once confirmed it will be added to your calendar and cant be changed!<p>
    </div>
        <div class="modal-footer">
            <a href="#" runat="server" OnServerClick="btnmeetadd_ServerClick" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
            <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
        </div>
    </div>
</asp:Content>
