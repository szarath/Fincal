<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pictureadd.aspx.cs" Inherits="Fincal.Pictureadd" %>
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
        <div class="col l4 s8 push-m4 push-l4">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">Add Picture</span>
              
                <div id="Invlaidpic" runat="server" class="row red-text text-lighten-2">

                </div>

                <div class="row">

                         <div id="picchoiceThumb" runat="server" ClientIDMode="static"></div>
                    
                     <div class="file-field input-field col s12">
                          <div class="btn waves-effect waves-light">
                            <span>Picture</span>
                            <input id="picchoice" type="file" name="picchoice[]" ClientIDMode="static" runat="server"/>
                          </div>
                          <div class="file-path-wrapper">
                            <input id="txtpicchoice" class="file-path validate" type="text" placeholder="Upload Photo" runat="server"/>
                          </div>
                        </div>
               

                  
                    </div>

                 <div class="row">
                      <div class="input-field col s12"> 
                        <input id="txtpictitle" type="text" class="validate autocomplete-content" runat="server"/>
                        <label for="txtpictitle">Picture title</label>
                    </div>
                </div>

                  
               
                   <div class="row">
                      <div class="input-field  col  s12"> 
                     <textarea  type="text"  id="txtpicdesc" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtpicdesc">Picture Description</label>
                    </div>
                </div>

                 <script>
                  function handleFileSelect(evt) {
                      var picchoice = evt.target.files; // FileList object

                    // Loop through the FileList and render image files as thumbnails.
                      for (var i = 0, f; f = picchoice[i]; i++) {

                      // Only process image files.
                      if (!f.type.match('image.*')) {
                        continue;
                      }

                      var reader = new FileReader();

                      // Closure to capture the file information.
                      reader.onload = (function(theFile) {
                        return function(e) {
                          // Render thumbnail.
                            document.getElementById('picchoiceThumb').innerHTML = ['<img class="responsive-img" src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                        };
                      })(f);

                      // Read in the image file as a data URL.
                      reader.readAsDataURL(f);
                    }
                  }

                     document.getElementById('picchoice').addEventListener('change', handleFileSelect, false);
                </script>

                </div> 



           <div class="card-action">
              <button id="btnpicadd" class="btn waves-effect waves-light" runat="server" onserverclick="btnpicadd_ServerClick"><i class="material-icons left">save</i>Add</button>
              <a href="Allpictures.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">cancel</i>Cancel</a>
            </div>

         
                    
                
                 
            </div>
            
          </div>
        </div>
</asp:Content>
