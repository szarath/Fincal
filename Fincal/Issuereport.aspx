﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Issuereport.aspx.cs" Inherits="Fincal.Issuereport" %>
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
              <span class="card-title">Report an issue</span>
              
                <div id="Invlaidproject" runat="server" class="row red-text text-lighten-2">

                </div>
               
                  <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea id="txtisst" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtisst">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea id="txtissd" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtissd">Description</label>
                    </div>
                </div>

        <div class="row">
                    <div class="input-field col  s12 m12 l12">
                          <i class="material-icons prefix">assignment</i>
                        <select id="Projectchoose" runat="server" >
                         
                           
                        </select> 
                        <label for="Projectchoose">Projects</label>
                          <blockquote>Which project is the issue reported.</blockquote>
                    </div>

                   
                     </div>

        
                 
            </div>
           <div class="card-action">
             
               <button id="btnissflagadd" class="btn waves-effect waves-light" runat="server" onserverclick="btnissflagadd_ServerClick"><i class="material-icons left">save</i>Add</button>
                  
              <a href="Issues.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">notification_important</i>Issues</a>
                   <a href="Projects.aspx" class="waves-effect waves-light btn red"><i class="material-icons left">cancel</i>Cancel</a>
            </div>
          </div>
        </div>
      </div>



</asp:Content>
