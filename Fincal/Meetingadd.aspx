<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Meetingadd.aspx.cs" Inherits="Fincal.Meetingadd" %>
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
              <span class="card-title">Add Meeting</span>
              
                <div id="Invlaidproject" runat="server" class="row red-text text-lighten-2">

                </div>

                  <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea id="txtmeettitle" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojt">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea id="txtmeetd" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtmeetd">Description</label>
                    </div>
                </div>


                 <div class="row">
                    <div class="input-field col  s12 m12 l12">
                          <i class="material-icons prefix">assignment</i>
                        <select id="Projchoose" runat="server" >
                         
                           
                        </select> 
                        <label for="Projchoose">Choose project</label>
                        <blockquote>Choose the project the meeting needs to set up for</blockquote>
                    </div>

                   
                     </div>
          
                
        
                    
                <div class="row">
                     
                                    <div class="input-field col s12 m6 l6">
                                       <i class="material-icons prefix">today</i>
                                        <input  id="txtdom" runat="server" class="datepicker black-text"/>
                                        <label for="txtdom">Date of meeting</label>
                                    </div>

                                     <div class="input-field col s12 m6 l6">
                                       <i class="material-icons prefix">access_time</i>
                                        <input  id="txttime" runat="server" class="timepicker black-text"/>
                                        <label for="txttime">Time of meeting  </label>
                                    </div>


                            </div>
                 <div class="row">
                               

                  
                                    
                              <ul id="membersattending" class="collection with-header col s12 m12 l12" runat="server">
                           <li class="collection-header"><h5>Attending members</h5></li>
                          </ul>
                    
                          </div>  
                 
            </div>
            <div class="card-action">
       
                    <a runat="server" id="btnaccept" href="#AcceptAdd" class="btn  waves-effect waves-light modal-trigger "><i class="material-icons left">save</i>Add</a>
              <a href="Projects.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">cancel</i>Cancel</a>
            </div>
          </div>
        </div>
      </div>

    <div class="modal" id="AcceptAdd">
    <div class="modal-content">
        <h4>Confirm Meeting Invite</h4>
        <p>Are you sure you want to set up this meeting!<p>
    </div>
        <div class="modal-footer">
            <a href="#" runat="server" OnServerClick="btnmeetadd_ServerClick" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
            <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
        </div>
    </div>
</asp:Content>
