﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" Async="true" CodeBehind="Issueaccept.aspx.cs" Inherits="Fincal.Issueaccept" %>
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
        <div id="projacc" runat="server" class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title bold">Accept/Reject Issue</span>
                
                <div id="invalidRegister" class="row red-text text-lighten-2" runat="server">

                </div>

                   <div class="row">
                    <div    class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">label_important</i>
                        <textarea readonly id="txtprojectname" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtprojectname">Project</label>
                    </div>
                </div>
                        
                          <div class="row">
                    <div    class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtisst" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtisst">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div   class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea readonly id="txtissd" class="materialize-textarea bold" rows="4" runat="server"></textarea>
                        <label for="txtissd">Description</label>
                    </div>
                </div>
                   <div class="row">
                    <div   class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">category</i>
                        <textarea readonly id="txtisspriority" class="materialize-textarea bold" rows="4" runat="server"></textarea>
                        <label for="txtisspriority">Priority</label>
                    </div>
                </div>
             

                    <div class="row">
                               

                  
                                    
                              <ul id="membersonissue" class="collection with-header col s12 m12 l12" runat="server">
                             <li class="collection-header"><h5>Issue members</h5></li>
                             </ul>
                    
                            </div>

                               <div class="row">

                

                      <div  class="input-field col s12 m12 l12">
                        <i class="material-icons prefix">email</i>
                        <textarea readonly id="txtexp" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtexp">Issue invite expiry date</label>
                     </div>

                </div>

                        </div>
              <div class="card-action">


  
                  <a href="#AcceptUpdate" class="btn waves-effect waves-light modal-trigger"><i class="material-icons left">save</i>Accept</a>
                            <a href="#AcceptDelete" class="btn orange waves-effect waves-light modal-trigger"><i class="material-icons left">not_interested</i>Reject</a>
              </div>

          </div>
        </div>
    </div>


         <div class="modal" id="AcceptUpdate">
                            <div class="modal-content">
                              <h4>Confirm Accept</h4>
                              <p>Are you sure you wish to be a part of this issue?</p>
                            </div>
                            <div class="modal-footer">
                              <a href="#" runat="server" OnServerClick="btnacceptproject_ServerClick" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-orange btn-flat orange-text lighten-2">Cancel</a>
                            </div>
                      </div>

     <div class="modal" id="AcceptDelete">
                            <div class="modal-content">
                              <h4>Confirm cancellation</h4>
                              <p>Are you sure you wish to not be a part of this issue?</p>
                            </div>
                            <div class="modal-footer">
                              <a href="#" runat="server" OnServerClick="btncancelprojnotification_Click" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
                            </div>
                      </div>
</asp:Content>
