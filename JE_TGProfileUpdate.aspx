<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="JE_TGProfileUpdate.aspx.cs" Inherits="MyProject.JE_TGProfileUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="StyleSheet/SiteMasterStyle.css" rel="stylesheet" />

    <link href="StyleSheet/JE_Style.css" rel="stylesheet" />
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style type="text/css">
     
    </style>
   
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--  <script src="script/jquery.updateprofile.min.js" type="text/javascript"></script>--%>
    <script src="jquery-1.8.2.js" type="text/javascript"></script>  
  
    <script >  
        function ShowPreview(input) {
           
            if (input.files && input.files[0]) {
                if (typeof (FileReader) != "undefined") {

                    var reader = new FileReader();

                    reader.onload = function (e) {

                        $("#dvPreview img").attr("src", e.target.result);

                    }

                    reader.readAsDataURL(input.files[0]);
                }
                else {
                    
                    alert("This browser does not support FileReader.");
                   
                }


            }
        }
       
    </script>  
    <br>
    <br>
    <br>
    <form id="AddPrecautionForm" runat="server">
        <div>
            <p class="TGtitle">Profile Update </p> 
                <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
           
              
                        <asp:FileUpload CssClass="ApplicationFormUpload" ID="Updatepic" onchange="ShowPreview(this)"  runat="server" />
             <script>
        

        </script>
           
            <br />
            <div id="dvPreview">
                         <img class="imageOnAddPrecaution" runat="server" id="updateprofilepic" src="image/profile.png" /><br />
           </div>

           
            <p class="jobinfoT">Name:</p>
            <asp:Label ID="lbProfileUpdatename" runat="server"></asp:Label>
                

            <asp:TextBox ID="tbNameUpdateTG" runat="server"></asp:TextBox>
            <br />
            <br />

             <p class="jobinfoT">Introduction:</p>

                

            <asp:TextBox ID="tbIntroUpdateTG" runat="server" width="600px" Height="400px"></asp:TextBox>
            <br />
            <br />
            <p class="jobinfoT">Type Of Bank:</p>
                 <asp:DropDownList ID="UpdateddlTypeBank" runat="server" Width="220px">
               <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>--%>
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
            <asp:Label class="jobinfoT" ID="Label2" runat="server" Text="Account Number:" Width="100%"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbUpdateAccNum" runat="server" Width="317px"></asp:TextBox>

            <br>
            <br>
             <asp:Label class="jobinfoT" ID="Label4" runat="server" Text="How long have you work as a tour guide?" Width="100%"></asp:Label>
                        <br />
                         <asp:TextBox ID="tbWorkhowlong" runat="server" Width="317px"></asp:TextBox>
        </div>
        <br>
        <br>
<div class="AddPrecautionbutton">
         <asp:Button CssClass="TGButton" ID="btnUpdateProfile" runat="server" Text="Update" OnClick="btnUpdateProfile_Click" />
        </div>
        <br>
    </form>
  <%--  <script type="text/javascript">
                 alert("hello world");
           $(function () {
    
    $("#Updatepic").change(function () {
        $("#dvPreview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $("#dvPreview").show();
                $("#dvPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
                $("#dvPreview").show();

            }
            else {
                
                if (typeof (FileReader) != "undefined") {
                    $("#dvPreview").show();
                    
                    $("#dvPreview").append("<img />");
                    $("#dvPreview img").attr("class", "showimg");
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("#updateprofilepic").attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                   
                    alert("This browser does not support FileReader.");
                    $("#dvPreview").append("<img src='image/profile.png' class='applicationFormImg'/>");
                }
            }
        } else {
            alert("Please upload a valid image file.");
            $("#dvPreview").append("<img src='image/profile.png' class='applicationFormImg'/>");
           
        }
    });
    </script>--%>
    </asp:Content>
