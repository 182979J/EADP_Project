<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JE_ApplicationForm.aspx.cs" Inherits="MyProject.JE_ApplicationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="StyleSheet/JE_Style.css" rel="stylesheet" />
    <title>Application Form</title>
    <style type="text/css">
        #tickprofile {
            visibility: hidden;
        }
        #ticknric {
            visibility: hidden;
        }
         #ticklicense {
            visibility: hidden;
        }
          #tickacra {
            visibility: hidden;
        }
        #tickbank {
            visibility: hidden;
        }
        #tickpersonal {
            visibility: hidden;
        }
         #tickdeclare {
            visibility: hidden;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 379px;
        }
        .showimg{
            max-width:400px;
display: block;
    margin-left: auto;
    margin-right: auto;

        }
        .tick{
           color:black;
           display:inline-flex;
           

        }
        /*.showimg:hover {
   max-width: 700px;
   height:auto;
   display: block;
    margin-left: auto;
    margin-right: auto;
    cursor: zoom-in;
  
}*/
        .applicationFormImg{
            width:400px;
            height:400px;
            display: block;
    margin-left: auto;
    margin-right: auto;
        }
        

    </style>
</head>
<body>

    <script src="https://www.google.com/recaptcha/api.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<%--<script language="javascript" type="text/javascript">--%>

    <script>
//    function yourFunction(){
//        // do whatever you like here
//        alert("hello")
//        lbwelcome.color = red;
//    setTimeout(yourFunction, 10);
//}

//    $(document).ready(function(){
//        var intervalFunction = setInterval(function () {
//            alert("helo");
//             if (cbDeclare1.Checked==true && cbDeclare2.Checked==true)
//            {
//                litDeclare.Text = "<style> #tickdeclare{ visibility: visible;}</style>";
                
//            }
//            else
//            {
//                litDeclare.Text = "<style> #tickdeclare{ visibility: hidden;}</style>";
                
//            }
//    //Do your code that execute after 5 mins
//    }, 5000);
//});





        $(function () {
     $("tickprofile").css("visibility", "visible");
    $("#imgProfile").change(function () {
        $("#dvPreview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvPreview").show();
                $("#dvPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
                $("#dvPreview").show();
                $(init);
                

            }
            else {
                
                if (typeof (FileReader) != "undefined") {
                    $("#dvPreview").show();
                    
                    $("#dvPreview").append("<img />");
                    $("#dvPreview img").attr("class", "showimg");
                    var reader = new FileReader();
                    reader.onload = function (e) {
                         $("#tickprofile").css("visibility", "visible");
                        $("#dvPreview img").attr("src", e.target.result);
                    }
                   
                    $("#dvPreview img").attr("data-toggle", "modal");
                    $("#dvPreview img").attr("data-target", "#ProfileModal");



                    //$(init);
                    //$("tickprofile").css("visibility", "visible");
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                     $("#tickprofile").css("visibility", "hidden");
                    alert("This browser does not support FileReader.");
                    $("#dvPreview").append("<img src='image/profile.png' class='applicationFormImg'/>");
                }
            }
        } else {
            $("#tickprofile").css("visibility", "hidden");
            alert("Please upload a valid image file.");
            $("#dvPreview").append("<img src='image/profile.png' class='applicationFormImg'/>");
           
        }
    });

     $("#imgNRICFront").change(function () {
        $("#dvNRICFrontPreview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvNRICFrontPreview").show();
                $("#dvNRICFrontPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
            }
            else {
                
                if (typeof (FileReader) != "undefined") {
                    $("#dvNRICFrontPreview").show();
                    $("#dvNRICFrontPreview").append("<img />");
                    $("#dvNRICFrontPreview img").attr("class", "showimg");
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("#dvNRICFrontPreview img").attr("src", e.target.result);
                    }
                    //if ($("#imgNRICFront").HasFile == true && $("#imgNRICBack").HasFile == true)
                    if($('#imgNRICFront').get(0).files.length != 0 && $('#imgNRICBack').get(0).files.length != 0){
                        $("#ticknric").css("visibility", "visible");
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    $("#ticknric").css("visibility", "hidden");
                    alert("This browser does not support FileReader.");
                    $("#dvNRICFrontPreview").append("<img src='image/uploadimage.png' class='applicationFormImg' />");
                }
            }
        } else {
            $("#ticknric").css("visibility", "hidden");
            alert("Please upload a valid image file.");
            $("#dvNRICFrontPreview").append("<img src='image/uploadimage.png' class='applicationFormImg' />");
        }
    });

     $("#imgNRICBack").change(function () {
        $("#dvNRICBackPreview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvNRICBackPreview").show();
                $("#dvNRICBackPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
            }
            else {
                
                if (typeof (FileReader) != "undefined") {
                    $("#dvNRICBackPreview").show();
                    $("#dvNRICBackPreview").append("<img />");
                    $("#dvNRICBackPreview img").attr("class", "showimg");
                    var reader = new FileReader();
                    reader.onload = function (e) {

                        $("#dvNRICBackPreview img").attr("src", e.target.result);
                    }
                     if($('#imgNRICFront').get(0).files.length != 0 && $('#imgNRICBack').get(0).files.length != 0){
                        $("#ticknric").css("visibility", "visible");
                    }
                    //if ($("#imgNRICFront").HasFile == true && $("#imgNRICBack").HasFile == true) {
                    //    $("#ticknric").css("visibility", "visible");
                    //}
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    $("#ticknric").css("visibility", "hidden");
                    alert("This browser does not support FileReader.");
                    $("#dvNRICBackPreview").append("<img src='image/uploadimage.png' class='applicationFormImg' />");
                }
            }
        } else {
            $("#ticknric").css("visibility", "hidden");
            alert("Please upload a valid image file.");
            $("#dvNRICBackPreview").append("<img src='image/uploadimage.png' class='applicationFormImg' />");
        }
    });


     $("#imgLicenseFront").change(function () {
        $("#dvLicenseFrontPreview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvLicenseFrontPreview").show();
                $("#dvLicenseFrontPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
            }
            else {
               
                if (typeof (FileReader) != "undefined") {
                    $("#dvLicenseFrontPreview").show();
                    $("#dvLicenseFrontPreview").append("<img />");
                    $("#dvLicenseFrontPreview img").attr("class", "showimg");
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("#dvLicenseFrontPreview img").attr("src", e.target.result);
                    }
                    if($('#imgLicenseFront').get(0).files.length != 0 && $('#imgLicenseBack').get(0).files.length != 0){
                        $("#ticklicense").css("visibility", "visible");
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    $("#ticklicense").css("visibility", "hidden");
                    alert("This browser does not support FileReader.");
                    $("#dvLicenseFrontPreview").append("<img src='image/uploadimage.png' class='applicationFormImg'/>");
                }
            }
        } else {
            $("#ticklicense").css("visibility", "hidden");
            alert("Please upload a valid image file.");
            $("#dvLicenseFrontPreview").append("<img src='image/uploadimage.png' class='applicationFormImg' />");
        }
    });



    
     $("#imgLicenseBack").change(function () {
        $("#dvLicenseBackPreview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvLicenseBackPreview").show();
                $("#dvLicenseBackPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
            }
            else {
               
                if (typeof (FileReader) != "undefined") {
                    $("#dvLicenseBackPreview").show();
                    $("#dvLicenseBackPreview").append("<img />");
                    $("#dvLicenseBackPreview img").attr("class", "showimg");
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("#dvLicenseBackPreview img").attr("src", e.target.result);
                    }
                    if($('#imgLicenseFront').get(0).files.length != 0 && $('#imgLicenseBack').get(0).files.length != 0){
                        $("#ticklicense").css("visibility", "visible");
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    $("#ticklicense").css("visibility", "hidden");
                    alert("This browser does not support FileReader.");
                    $("#dvLicenseBackPreview").append("<img src='image/uploadimage.png'  class='applicationFormImg'/>");
                }
            }
        } else {
            $("#ticklicense").css("visibility", "hidden");
            alert("Please upload a valid image file.");
            $("#dvLicenseBackPreview").append("<img src='image/uploadimage.png' class='applicationFormImg'/>");
        }
    });



     $("#imgACRA1").change(function () {
        $("#dvACRA1Preview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvACRA1Preview").show();
                $("#dvACRA1Preview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
            }
            else {
              
                if (typeof (FileReader) != "undefined") {
                    $("#dvACRA1Preview").show();
                    $("#dvACRA1Preview").append("<img />");
                    $("#dvACRA1Preview img").attr("class", "showimg");
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("#dvACRA1Preview img").attr("src", e.target.result);
                    }
                    if($('#imgACRA1').get(0).files.length != 0 && $('#imgACRA2').get(0).files.length != 0 && $('#imgACRA3').get(0).files.length != 0){
                        $("#tickacra").css("visibility", "visible");
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    $("#tickacra").css("visibility", "hidden");
                    alert("This browser does not support FileReader.");
                    $("#dvACRA1Preview").append("<img src='image/uploadimage.png' class='applicationFormImg' />");
                }
            }
        } else {
            $("#tickacra").css("visibility", "hidden");
            alert("Please upload a valid image file.");
            $("#dvACRA1Preview").append("<img src='image/uploadimage.png' class='applicationFormImg'/>");
        }
    });


     $("#imgACRA2").change(function () {
        $("#dvACRA2Preview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvACRA2Preview").show();
                $("#dvACRA2Preview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
            }
            else {
               
                if (typeof (FileReader) != "undefined") {
                    $("#dvACRA2Preview").show();
                    $("#dvACRA2Preview").append("<img />");
                    $("#dvACRA2Preview img").attr("class", "showimg");
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("#dvACRA2Preview img").attr("src", e.target.result);
                    }
                     if($('#imgACRA1').get(0).files.length != 0 && $('#imgACRA2').get(0).files.length != 0 && $('#imgACRA3').get(0).files.length != 0){
                        $("#tickacra").css("visibility", "visible");
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    $("#tickacra").css("visibility", "hidden");
                    alert("This browser does not support FileReader.");
                    $("#dvACRA2Preview").append("<img src='image/uploadimage.png' class='applicationFormImg'/>");
                }
            }
        } else {
            $("#tickacra").css("visibility", "hidden");
            alert("Please upload a valid image file.");
            $("#dvACRA2Preview").append("<img src='image/uploadimage.png' class='applicationFormImg'/>");
        }
    });



     $("#imgACRA3").change(function () {
        $("#dvACRA3Preview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvACRA3Preview").show();
                $("#dvACRA3Preview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
            }
            else {
                
                if (typeof (FileReader) != "undefined") {
                    $("#dvACRA3Preview").show();
                    $("#dvACRA3Preview").append("<img />");
                    $("#dvACRA3Preview img").attr("class", "showimg");
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("#dvACRA3Preview img").attr("src", e.target.result);
                    }
                     if($('#imgACRA1').get(0).files.length != 0 && $('#imgACRA2').get(0).files.length != 0 && $('#imgACRA3').get(0).files.length != 0){
                        $("#tickacra").css("visibility", "visible");
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    $("#tickacra").css("visibility", "hidden");
                    alert("This browser does not support FileReader.");
                    $("#dvACRA3Preview").append("<img src='image/uploadimage.png' class='applicationFormImg' />");
                }
            }
        } else {
            $("#tickacra").css("visibility", "hidden");
            alert("Please upload a valid image file.");
            $("#dvACRA3Preview").append("<img src='image/uploadimage.png' class='applicationFormImg'/>");
        }
    });

});
</script>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="applicationformrightcenter">
            <br />
            <br />
             
            <table class="auto-style1">
                
                <tr>
                    <td class="auto-style2" rowspan="8">
                         <asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>
                        <%--<asp:Timer ID="Timer1" runat="server" ></asp:Timer>--%>
                      <%--  <asp:UpdatePanel UpdateMode="Always" ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <asp:Literal runat="server" ID="litacrA"></asp:Literal>--%>
                        <div class="ApplicationFormsidenav">
                        <ul class="ApplicationFormNavGroup">
                            <li><a href="#lbProfilePhoto" class="ApplicationFormNav"> Profile Photo*<asp:Label class="tick" id="tickprofile" text="✔" runat="server"/></a></li>
                            <li><a href="#lbNRIC" class="ApplicationFormNav"> NRIC*<asp:Label class="tick" id="ticknric" text="✔" runat="server"/></a></li>
                            <li><a href="#lbGL" class="ApplicationFormNav"> Tour Guide License<asp:Label class="tick" id="ticklicense" text="✔" runat="server"/></a></li>
                            <li><a href="#lbACRA" class="ApplicationFormNav"> ACRA Business Profile<asp:Label class="tick" id="tickacra" text="✔" runat="server"/></a></li>
                            <li><a href="#lbBank" class="ApplicationFormNav"> Bank Information*<asp:Label class="tick" id="tickbank" text="✔" runat="server"/></a></li>
                            <li><a href="#lbPersonal" class="ApplicationFormNav"> Personal Information*<asp:Label class="tick" id="tickpersonal" text="✔" runat="server"  /></a></li>
                            <li><a href="#lbDeclaration" class="ApplicationFormNav"> Declaration*<asp:Label class="tick" id="tickdeclare" text="✔" runat="server"/></a></li>
                        </ul>
                            </div>
                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        <%-- <asp:Menu ID="menuApplicationForm" runat="server">
                <Items>
                    <asp:MenuItem Text="1.Profile Photo" Value="1.Profile Photo"></asp:MenuItem>
                    <asp:MenuItem Text="2.NRIC" Value="2.NRIC"></asp:MenuItem>
                    <asp:MenuItem Text="3.Tour Guide License" Value="3.Tour Guide License"></asp:MenuItem>
                    <asp:MenuItem Text="4.ACRA Business Profile" Value="4.ACRA Business Profile"></asp:MenuItem>
                    <asp:MenuItem Text="5.Bank Information" Value="5.Bank Information"></asp:MenuItem>
                    <asp:MenuItem Text="6.Declaration" Value="6.Declaration"></asp:MenuItem>
                </Items>
            </asp:Menu>--%>
                    </td>
                   
                    <td>
       
                        &nbsp;

                        <p class="TGtitle">Application Form</p>

                        <p class="ApplicationFormSubTitle" ID="lbwelcome" runat="server" ></p>
                        <p class="ApplicationFormSubTitle" runat="server" ><b>
                                    <asp:Label ID="lbMsg" runat="server" />
                                    </b></p>

            <asp:Label CssClass="ApplicationFormInsideTitle" ID="lbProfilePhoto" runat="server" Text="1. Profile Photo" Width="100%"></asp:Label>
                        <br />
                        <%--<input class="ApplicationFormUpload" type="file" name="myFile1" size="20" id="imgProfile" runat="server" /><br />--%>
                        <asp:FileUpload ID="imgProfile" runat="server" class="ApplicationFormUpload" onchange="readURL(this)" type="file" size="20"/>
                        <br />
                        <br />

                        <div id="dvPreview">
                           
                            <a id="pop"><img src="image/profile.png" id="imgProfilelol" class="applicationFormImg" data-toggle="modal" data-target="#ProfileModal" /> </a>
                          <%--   <script type="text/javascript">
                          
                                $("#pop").on("click", function() {
                                $('#ProfileModal').modal('show');});
                            </script>--%>
                              <div class="modal fade" id="ProfileModal" role="dialog">
                                     <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            hi
                            <%--<img src="image/profile.png" class="applicationFormImg"/>--%> 
                                        </div>
                                         </div>
                                  </div>
</div></div>
                        <%--<img id="dvPreview" src="image/profile.png" class="applicationFormImg" />--%>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>

            <asp:Label CssClass="ApplicationFormInsideTitle" ID="lbNRIC" runat="server" Text="2. NRIC" Width="100%"></asp:Label>
                        <br />
                        <br />
                        <p class="ApplicationFormSubTitle">Front of NRIC</p><br />

           <asp:FileUpload onchange="readURL(this)" ID="imgNRICFront" runat="server" class="ApplicationFormUpload" type="file" size="20"/><br />
                        <div id="dvNRICFrontPreview">
<img src="image/uploadimage.png" class="applicationFormImg"/>
</div>
                        

                        <br />
                        <p class="ApplicationFormSubTitle">Back of NRIC</p><br />

           <asp:FileUpload onchange="readURL(this)" ID="imgNRICBack" runat="server" class="ApplicationFormUpload" type="file" size="20"/><br />
                          <div id="dvNRICBackPreview">
<img src="image/uploadimage.png" class="applicationFormImg"/>
</div>
                        

                    </td>

                </tr>
                <tr>
                    <td>
                        <br />
            <asp:Label CssClass="ApplicationFormInsideTitle" ID="lbGL" runat="server" Text="3. Tour Guide License" Width="100%"></asp:Label>
                        <br />
                        <div id="ApplicationFormRadioButton">
                        <asp:RadioButton ID="rbTrueGL" runat="server" Checked="True" onclick="show();" GroupName="LicenseYorN" Text="Have"  />
&nbsp;<asp:RadioButton ID="rbFalseGL" runat="server" GroupName="LicenseYorN" onclick="hide();" Text="Don't Have"  />
                        </div>
                        <script>
                            function show(){
                                  document.getElementById('GuideLicenseVisible').style.Visibility ='visible';
                                }
                                function hide(){
                                  document.getElementById('GuideLicenseVisible').style.Visibility = 'hidden';
                                }
                            </script>
                            <br />
                        <br />
                        <div id="GuideLicenseVisible" >
                        <p class="ApplicationFormSubTitle" runat="server" id="hide1" >Front of Guide License</p><br />

            <asp:FileUpload onchange="readURL(this)" ID="imgLicenseFront" runat="server" class="ApplicationFormUpload" type="file" size="20"/><br />
                        <div id="dvLicenseFrontPreview">
<img src="image/uploadimage.png" class="applicationFormImg"/>
</div>
                            
                        <br />
                        
                        <br />
                        <p class="ApplicationFormSubTitle">Back of Guide License</p><br />

            <asp:FileUpload onchange="readURL(this)" ID="imgLicenseBack" runat="server" class="ApplicationFormUpload" type="file" size="20"/><br />
                         <div id="dvLicenseBackPreview">
 <img src="image/uploadimage.png" class="applicationFormImg"/>
</div>
                           
                        <br />
                        <br />
                        <br />
                             </div>
                           

                    </td>
                </tr>
                <tr>
                    <td>
                       
                        
            <asp:Label CssClass="ApplicationFormInsideTitle" ID="lbACRA" runat="server" Text="4.ACRA Business Profile" Width="100%"></asp:Label>
                        <br />
                        <br />
                        <p class="ApplicationFormSubTitle">ACRA Document Page 1</p><br />

            <asp:FileUpload onclick="acraCheck" onchange="readURL(this)" ID="imgACRA1" runat="server" class="ApplicationFormUpload" type="file" size="20"/><br />
                         <div id="dvACRA1Preview">
 <img src="image/uploadimage.png" class="applicationFormImg"/>
</div>
                       
                        <br />
                        <p class="ApplicationFormSubTitle">ACRA Document Page 2</p><br />

            <asp:FileUpload onclick="acraCheck" onchange="readURL(this) " ID="imgACRA2" runat="server" class="ApplicationFormUpload" type="file" size="20"/><br />
                        <div id="dvACRA2Preview">
<img src="image/uploadimage.png" class="applicationFormImg"/>
</div>
                        
                        <br />
                        <p class="ApplicationFormSubTitle">ACRA Document Page 3</p><br />

            <asp:FileUpload onclick="acraCheck" onchange="readURL(this)" ID="imgACRA3" runat="server" class="ApplicationFormUpload" type="file" size="20"/><br />
                         <div id="dvACRA3Preview">
<img src="image/uploadimage.png" class="applicationFormImg"/>
</div>
                        
                        <br />
               
                    </td>
                </tr>
                <tr>
                    <td>
                      
                        <asp:UpdatePanel UpdateMode="Always" ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                       <asp:Literal runat="server" ID="litBank"></asp:Literal>
                        <br />
            <asp:Label CssClass="ApplicationFormInsideTitle" ID="lbBank" runat="server" Text="5. Bank Information" Width="100%"></asp:Label>
                        <br />
            <asp:Label class="ApplicationFormSubTitle" ID="Label1" runat="server" Text="Type Of Bank:" Width="100%"></asp:Label>
                        <br />
                
            <asp:DropDownList ID="ddlTypeBank" OnTextChanged="ddlTypeBank_TextChanged" runat="server" Width="220px">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
               <asp:ListItem>Citibank</asp:ListItem>
                <asp:ListItem>DBS</asp:ListItem>
                <asp:ListItem>HSBC</asp:ListItem>
                <asp:ListItem>Maybank</asp:ListItem>
                <asp:ListItem>OCBC</asp:ListItem>
                <asp:ListItem>POSB</asp:ListItem>
                <asp:ListItem>Standard Chartered</asp:ListItem>
                <asp:ListItem>UOB</asp:ListItem>
            </asp:DropDownList>
                        <br />
                        <br />
            <asp:Label class="ApplicationFormSubTitle" ID="Label2" runat="server" Text="Account Number:" Width="100%"></asp:Label>
                        <br />
                        <asp:TextBox OnTextChanged="tbAccountNum_TextChanged" ID="tbAccountNum" runat="server" Width="317px"></asp:TextBox>
                 </ContentTemplate>
                            </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                        <asp:UpdatePanel UpdateMode="Always" ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Literal runat="server" ID="litPersonal"></asp:Literal>
                        <asp:Label CssClass="ApplicationFormInsideTitle" ID="lbPersonal" runat="server" Text="Personal Information" Width="100%"></asp:Label>
                        <br />
                         <asp:Label class="ApplicationFormSubTitle" ID="Label3" runat="server" Text="Area of Expertise:" Width="100%"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbExpertise" runat="server"  AutoPostBack="true" Width="600px" TextMode="MultiLine" Height="300px" OnTextChanged="tbExpertise_TextChanged"></asp:TextBox>
                         <br />
                         <asp:Label class="ApplicationFormSubTitle" ID="Label4" runat="server" Text="How long have you work as a tour guide?" Width="100%"></asp:Label>
                        <br />
                         <asp:TextBox OnTextChanged="tbWorkHowLong_TextChanged"  AutoPostBack="true" ID="tbWorkhowlong" runat="server" Width="317px"></asp:TextBox>
                 </ContentTemplate>
        </asp:UpdatePanel>   
                </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel UpdateMode="Always" ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                 <asp:Literal runat="server" ID="litDeclare"></asp:Literal>
                        <br />
            <asp:Label CssClass="ApplicationFormInsideTitle" ID="lbDeclaration" runat="server" Text="6. Declaration" Width="100%"></asp:Label>
                        <br />
                        <br />
                        <asp:CheckBox ID="cbDeclare1" runat="server" Text="I hereby declare that all the particulars given herein are true and correct, and I have not wilfully suppressed any material fact." OnCheckedChanged="cbDeclare1_CheckedChanged" />
                        <br />
                        <br />
                        <asp:CheckBox ID="cbDeclare2" runat="server" Text="I hereby give consent to collection, use and disclosure of my personal data by the company (or its agents) for the purpose of the processing and administration by the company relating to this attached job application." OnCheckedChanged="cbDeclare2_CheckedChanged" />
                    </ContentTemplate>
        </asp:UpdatePanel>   
                        </td>
                </tr>
                
                   
                        
                            
                
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td><b>
                                    <asp:Label ID="lblForMessage" runat="server" />
                                    </b></td>
                                </tr>
                            <tr>
                                <td>
                                    <div class="g-recaptcha" data-sitekey="6Le8vMoUAAAAAHoLfcEcKfRBuHE91z5c2KKXqFUL"></div>
                                
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Button OnClick="btnValidateReCaptcha_Click" Text="Validate"
                                        ID="btnValidateReCaptcha" runat="server" />
                                </td>
                            </tr>
                            </table>
                        <br />
                        <br />
                        <div class="buttonsDiv">
            <asp:Button CssClass="Buttonss" ID="btnSubmitApplication" runat="server" Text="Submit" OnClick="btnSubmitApplication_Click" />
                    </div>
                            </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
