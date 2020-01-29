<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JE_SignInToApply.aspx.cs" Inherits="MyProject.JE_SignInToApply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%; margin: 0;">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script> 
        var modal = document.getElementById("OTPModal");
        var btn = document.getElementById("btntry");
        btn.onclick = function () {
            modal.style.display = "block";
        }


    </script>
    <link href="StyleSheet/JE_Style.css" rel="stylesheet" />
    <title>Sign In To Apply As A Tour Guide</title>
    <style type="text/css">
        ::-webkit-scrollbar{
            background-color: lightgray;
            width: 2px;
        }

        body{
            /*background-color: lightgray;*/
            background: url('/image/tourblur.jpg') no-repeat center;
            background-size: cover;
        }

        .auto-style1 {
            margin-left: 40px;
        }

        .ApplyBackground {
            background-image: url('/image/tour.jpg');
            height: 525px;
            width: 52%;
            /* Center and scale the image nicely */
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>


</head>

<body style="height: 100%;">
  
    <div class="row" style="align-content: center; border: 6px solid crimson; padding:0; background-color: rgba(255, 255,255, 0.8); width: 95%; margin: 30px;">
        <div class="col-md-5 ApplyBackground" >
            <!--<img src="image/tour.jpg" style="width: 200px; height: 200px;" />-->
        </div>
        <div class="col-md-5" style="padding: 20px;">

            <form id="ApplyForm" runat="server">

                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="30pt" style="font-family: Centaur;" Text="Applying As A Tour Guide"></asp:Label>
                <br />
                <asp:Label ID="lbErrorExist" runat="server"></asp:Label>
                <br />

                <asp:TextBox ID="tbFirstName" Width="200px" runat="server" placeholder="First Name"></asp:TextBox>
                <asp:TextBox ID="tbLastName" Width="200px" runat="server" placeholder="Last Name"></asp:TextBox>
                <br />
                <asp:Label ID="lbErrorName" runat="server"></asp:Label>
                <br />
             

                <asp:TextBox ID="tbMobile" runat="server" Width="200px" placeholder="Mobile Phone"></asp:TextBox>
                <asp:TextBox ID="tbEmail" runat="server" Width="200px" placeholder="Email"></asp:TextBox>
                <br />
                <asp:Label ID="lbErrorMobile" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lbErrorEmail" runat="server"></asp:Label>
                <br />

         
              
                <asp:CheckBox ID="cbTick" runat="server" Text="By proceeding, I agree that Singaplore can collect, use and disclose the information provided by me in accordance with the Privacy Policy and I fully comply with Terms &amp; Conditions which I have read and understand." />
                <br />
                <asp:Label ID="lbErrorTick" runat="server"></asp:Label>
                <br />
                <asp:Button CssClass="TGButton" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="137px" />
                
                <asp:Button CssClass="TGButton" ID="btntry" runat="server" Text="try trey hnbfkebf jek weij g " Width="137px" OnClick="btntry_Click" />
                <br />


            </form>

        </div>
    </div>


</body>
</html>
