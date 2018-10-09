<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fincal.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">

        <div class="row">
          <div class="col s12 m10 l8 ">
            <h3 id="indexTitle" class="bold" runat="server">Welcome, Please Register/Login</h3>
        </div>
        
    </div>

    <div runat="server" id="eventmain" visible="false">
         <div class="row">
          <div class="col s12 m10 l8 ">
            <h4 id="H1" class="bold" runat="server">Events</h4>
        </div>  
     
   
    </div>

      <div class="row"  id="upev" runat="server">

  
    </div>
        </div>

    <div id="taskmain" runat="server" visible="false">
                <div class="row">
          <div class="col s12 m10 l8 ">
            <h4 id="H2" class="bold" runat="server">Tasks</h4>
        </div>
        
    </div>

      
      
    <div class =" row">

         
         
         <h4 id="H6" class="thin col m10 s12 " runat="server">Inprogress</h4> 

          </div>


<div id="taskinprogress" class="row" runat="server">
  
    </div>
        
 
   
       
   

        <div class =" row">
      <h4 class="thin col m10 s12 " runat="server">Completed</h4> 
            </div>


   <div id="completedtask" class="row" runat="server">
   
     </div>
 



    </div>


    <div id="picturemain" runat="server" visible="false">

          <div class="row">
          <div  class="col s12 m10 l8">
            <h4 id="H3" class="bold"  runat="server">Pictures</h4>
        </div>  
     
   
    </div>
  


      

    
                <div class="row">
                 
                   <div class="card">
                        <div id="picturecarousel" class="col" runat="server">
                          

                        </div>
                     </div>


                        </div>


    </div>


    <div id="collabrationmain" runat="server" visible="false">




    </div>
</asp:Content>
