<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Issueflagviewer.aspx.cs" Inherits="Fincal.Issueflagviewer" %>
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
              <span class="card-title">Flagged issue</span>
              
                <div id="Invlaidproject" runat="server" class="row red-text text-lighten-2">

                </div>

                <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtruser" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtruser">Reporting user</label>
                    </div>


                </div>


                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtprojname" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojname">Project Title</label>
                    </div>
                </div>
                  <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea id="txtisstitle" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtisstitle">Issue Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea id="txtissdesc" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtissdesc">Issue Description</label>
                    </div>
                </div>

              <!--     <div class="row">
                    <div class="input-field col  s12 m12 l12">
                          <i class="material-icons prefix">assignment</i>
                        <select id="Projectchoose" runat="server" >
                         
                           
                        </select> 
                        <label for="Projectchoose">Projects</label>
                    </div>

                   
                     </div>-->

    <div class="row">
                    <div class="input-field col  ss12 m6 l6 ">
                          <i class="material-icons prefix">people</i>
                        <select id="UserChoose" runat="server" multiple>
                          <option value="" disabled selected>Choose Member</option>
                           
                        </select> 
                        <label for="UserChoose">Members to invite</label>
                         <blockquote>Must choose at least a member to invite</blockquote>
                    </div>

                      <div class="input-field col s12 m6 l6">
                              <i class="material-icons prefix">category</i>
                        <select id="LevelDrop" runat="server">
                              <option value="" disabled selected>Choose Level</option>
                           
                        </select> 
                        <label for="LevelDrop">Level</label>
                    </div>
                     </div>
          
             
        
                    
                
                 
            </div>

           <div class="card-action">
              <button id="btnissadd" class="btn waves-effect waves-light" runat="server" onserverclick="btnissueadd_ServerClick"><i class="material-icons left">save</i>Accept</button>
              <button id="btnissreject" class="btn waves-effect waves-light red" runat="server" onserverclick="btnissreject_ServerClick"><i class="material-icons left">not_interested</i>Reject</button>
              <a href="Issues.aspx" class="waves-effect waves-light btn blue"><i class="material-icons left">notification_important</i>Issue</a>
              <a href="Default.aspx" class="waves-effect waves-light btn "><i class="material-icons left">home</i>Home</a>
            </div>
          </div>
        </div>
      </div>

</asp:Content>
