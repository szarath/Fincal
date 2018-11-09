<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Projectadd.aspx.cs" Inherits="Fincal.Projectadd" %>
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
              <span class="card-title">Add Project</span>
              
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
                        <select id="UserChoose" runat="server" multiple>
                         
                           
                        </select> 
                        <label for="UserChoose">Members to invite</label>
                             <blockquote>Choose members to invite from the list or invite members later</blockquote>
                    </div>

                   
                     </div>
          
                
        
                    
                <div class="row">
                     
                                    <div class="input-field col s12 m6 l6">
                                       <i class="material-icons prefix">today</i>
                                        <input  id="txtdom" runat="server" class="datepicker black-text"/>
                                        <label for="txtdom">Date of first meeting</label>
                                    </div>

                                     <div class="input-field col s12 m6 l6">
                                       <i class="material-icons prefix">access_time</i>
                                        <input  id="txttime" runat="server" class="timepicker black-text"/>
                                        <label for="txttime">Time of first meeting  </label>
                                    </div>


                            </div>
                
                 
            </div>
            <div class="card-action">
              <button id="btnprojadd" class="btn waves-effect waves-light" runat="server" onserverclick="btnprojadd_ServerClick"><i class="material-icons left">save</i>Add</button>
              <a href="Projects.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">cancel</i>Cancel</a>
            </div>
          </div>
        </div>
      </div>

</asp:Content>
