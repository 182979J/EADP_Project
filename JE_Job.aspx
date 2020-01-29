<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="JE_Job.aspx.cs" Inherits="MyProject.JE_Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link href="StyleSheet/JE_Style.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

  
    <style type="text/css">
       
        .jobtable {
    border: 1px solid black;
    color:black;
    align-content:center;
    text-align:center;
    
    
}
    .jobtable tr:nth-child(even) {
        background-color: rgb(255, 161, 175);
    }

.jobtable tr:hover {
    background-color: #ddd;
}

.jobtable tr{
     min-width:250px;
}

.jobtable th {
    padding-top: 12px;
    padding-bottom: 12px;
    text-align: left;
    background-color: red;
    color: white;
    text-align:center;
   
    /*min-width:250px;*/
}
    </style>
    
    </asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <p class="TGtitle">Jobs You Have Accepted</p> 

         <asp:GridView  align="center" class="jobtable"  ID="GridViewChosen" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridViewChoose_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="PurchaseId" HeaderText="PurchaseId" />
            <asp:BoundField DataField="packageName" HeaderText="Package Name" />
            <asp:BoundField DataField="tripDate" HeaderText="Trip Date" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [PurchaseId], [packageName], [tripDate], [tourGuideId] FROM [PurchasedPackage] where [tourGuideId] is null"></asp:SqlDataSource>

<%--<table align="center" class="jobtable">
  <tr>
    <th class="style2">Package Name</th>
    <th>Date</th> 
    <th class="style1">Time</th>
    <th class="style4">Duration</th>
    <th class="style5">Tourist Name</th>
    <th>Click</th>
  </tr>
  <tr>
    <td class="style2">Wonderland</td>
    <td>23/04/2020</td>
    <td class="style1">9am</td>
    <td class="style4">3 days 2 night</td>
    <td class="style5">Amy Lee</td>
    <td><a>Read More</a></td>
  </tr>
</table>--%>
<br>
    


    <p class="TGtitle">Which Jobs Are You Picking Up?</p> 
          <input class="form-control" id="ChooseSearch" type="text" placeholder="Search">
        <br>
       <script>
$(document).ready(function(){
  $("#ChooseSearch").on("keyup", function() {
    var value = $(this).val().toLowerCase();
    $("#ContentPlaceHolder1_GridViewChoose tbody tr").filter(function() {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
  });
});
</script>

  <%--  <table class="jobtable" align="center">
  <tr>
    <th class="style2">Package Name</th>
    <th class="style3">Date</th> 
    <th class="style1">Time</th>
    <th class="style4">Duration</th>
    <th class="style5">Tourist Name</th>
    <th>Click</th>
  </tr>
  <tr>
    <td class="style2">Wonderland</td>
    <td class="style3">24/04/2020</td>
    <td class="style1">9am</td>
    <td class="style4">3 days 2 night</td>
    <td class="style5">Clarie Tang</td>
    <td><a>Read More</a></td>
  </tr>
     <tr>
    <td class="style2">Amazing Merlion</td>
    <td class="style3">27/04/2020</td>
    <td class="style1">11am</td>
    <td class="style4">2 days 1 night</td>
    <td class="style5">Jia Ming</td>
    <td><a>Read More</a></td>
  </tr>
</table>--%>
     <%--   <asp:Panel ID="Panel1" runat="server"></asp:Panel>--%>
    <asp:GridView  align="center" class="jobtable table"  ID="GridViewChoose" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridViewChoose_SelectedIndexChanged">
       
        <Columns>
            <asp:BoundField DataField="PurchaseId" HeaderText="PurchaseId" />
            <asp:BoundField DataField="packageName" HeaderText="Package Name" />
            <asp:BoundField DataField="tripDate" HeaderText="Trip Date" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
          
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [PurchaseId], [packageName], [tripDate], [tourGuideId] FROM [PurchasedPackage] where [tourGuideId] is null"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</form>
    
</asp:Content>


