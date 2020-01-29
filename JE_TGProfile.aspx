<%@ Page Title="Profile" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="JE_TGProfile.aspx.cs" Inherits="MyProject.JE_TGProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet/JE_Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            width: 557px;
        }
        .auto-style3 {
            width: 277px
        }
        .auto-style4 {
            text-align: center;
            height: 46px;
            width: 420px;
            padding: 0 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">&nbsp;
    <br>
    
    <img class="ProfilePPic" runat="server" id="ProfilePicDisplay"  src="image/profile.png" /><br>
    <br>
    <form  runat="server">
     <div class="PrecautionAdd"> <asp:Button CssClass="TGButton" ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" /></div>
        </form>
    <br>
    <table class="nav-justified ProfileTGInfo">
        <tr>
            <td class="auto-style2">
    
                <br />
                <br />
                <p class="jobinfoT">License/Certification:</p>
                
    <img class="ProfileCertPic" runat="server"  id="profilenricfront" src="image/uploadimage.png" /><br />
                <img class="ProfileCertPic" runat="server" id="profilenricback" src="image/uploadimage.png" /><br />
                <p class="jobinfoT">Guide Rating:</p>

                <div class="auto-style4"><div class="rate">
    <input type="radio" id="star5" name="rate" value="5" />
    <label for="star5" title="text">5 stars</label>
    <input type="radio" id="star4" name="rate" value="4" />
    <label for="star4" title="text">4 stars</label>
    <input type="radio" id="star3" name="rate" value="3" />
    <label for="star3" title="text">3 stars</label>
    <input type="radio" id="star2" name="rate" value="2" />
    <label for="star2" title="text">2 stars</label>
    <input type="radio" id="star1" name="rate" value="1" />
    <label for="star1" title="text">1 star</label>
  </div>
                    </div>
            </td>
            <td>
    <p class="jobinfoT">Name:</p>
                 <p runat="server" class="jobinfoAns" id="ProfilePageTGName"></p>
    <p class="jobinfoT">Introduction:</p>
                 <p class="jobinfoAns" id="ProfilePageTGIntro" runat="server"></p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <br />
                <p class="jobinfoT">Reviews:</p>
                <br />
                <table class="nav-justified ProfileReviewTable" align="center">
                    <tr>
                        <td class="auto-style3"> <div class="rate">
    <input type="radio" id="star5" name="rate" value="5" />
    <label for="star5" title="text">5 stars</label>
    <input type="radio" id="star4" name="rate" value="4" />
    <label for="star4" title="text">4 stars</label>
    <input type="radio" id="star3" name="rate" value="3" />
    <label for="star3" title="text">3 stars</label>
    <input type="radio" id="star2" name="rate" value="2" />
    <label for="star2" title="text">2 stars</label>
    <input type="radio" id="star1" name="rate" value="1" />
    <label for="star1" title="text">1 star</label>
  </div></td>
                        <td rowspan="3">The trip is very nice. Thanks to this tour guide</td>
                    </tr>
                    <tr>
                        <td class="auto-style3"><p class="ProfileReviewName">Tommy</p></td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <img class="ProfileReviewPic" src="image/profile.png" /></td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
    

<br />
    <br />
    <br />

</asp:Content>
