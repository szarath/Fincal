<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pictureedit.aspx.cs" Inherits="Fincal.Pictureedit" %>
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
  

    <div class="row" id="taskDiv" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">Edit Picture</span>
              
                <div id="Invlaidtask" runat="server" class="row red-text text-lighten-2">

                </div>

                <div  id="pictureholder" class="row" runat="server">
               
                  
                </div> 
                <div class="row">

                     <div class="input-field col s12 m12 12">
                          <i class="material-icons prefix">title</i>
                        <textarea id="txtpictitle" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtpictitle">Title</label>
                    </div>

                </div>
             
               <div class="row">
                    <div class="input-field col s12 m12 12">
                         <i class="material-icons prefix">description</i>
                        <textarea id="txtpicdescription" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtpicdescription">Description</label>
                    </div>
                </div>

                </div>
                <div class="card-action">
                <button id="btnUpdatepic" type="submit" class="btn waves-effect waves-light" runat="server"  onserverclick="btnUpdatepic_ServerClick"><i class="material-icons">save</i>Update</button> 
            <a href="#AcceptDelete" class="btn waves-effect waves-light red modal-trigger"><i class="material-icons">delete</i>Delete</a> 
              <a href="Allpictures.aspx" class="waves-effect waves-light btn orange"><i class="material-icons">cancel</i>Cancel</a>
            </div>

                 
            </div>




          
          </div>
        </div>


      <div class="modal" id="AcceptDelete">
    <div class="modal-content">
        <h4>Confirm Delete</h4>
        <p>Are you sure you wish to delete this Picture?</p>
    </div>
        <div class="modal-footer">
            <a href="#" runat="server" OnServerClick="btnDeletepic_ServerClick" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
            <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
        </div>
    </div>

</asp:Content>
