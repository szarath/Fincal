<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Issueadd.aspx.cs" Inherits="Fincal.Issueadd" %>
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
              <span class="card-title">Add Issue</span>
              
                <div id="Invlaidproject" runat="server" class="row red-text text-lighten-2">

                </div>
                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">assignment</i>
                        <textarea readonly id="txtprojname" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojname">Project</label>
                    </div>
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
                        <textarea id="txtprojd" class="materialize-textarea" rows="4" runat="server"></textarea>
                        <label for="txtprojd">Description</label>
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
                    <div class="input-field col  s12 m6 l6 ">
                          <i class="material-icons prefix">people</i>
                        <select id="UserChoose" runat="server" multiple>
                         <option value="" disabled selected>Choose Member</option>
                           
                        </select> 
                        <label for="UserChoose">Members</label>
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
              <a id="btnprojadd" class="btn waves-effect waves-light" runat="server" onserverclick="btnprojadd_ServerClick"><i class="material-icons left">save</i>Add</a>
              <a href="Issues.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">cancel</i>Cancel</a>
            </div>
          </div>
        </div>
      </div>


</asp:Content>
