<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Retrival.aspx.cs" Inherits="corona_management_project.Retrival" %>


<html>

<head id="Head1" runat="server">
    <title>Page</title>
    <style type="text/css">
        .Gridview {
            font-family: Verdana;
            font-size: 12pt;
            font-weight: normal;
            color: darkturquoise;
            align-content: center;
            position: center;
            margin-left: auto;
            margin-right: auto;
        }

       .button {
            border:solid;
            color: darkturquoise;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
            position: center;
            background-color:white;
            border-color: black;
            
        }
        .button:hover {
         background-color: darkturquoise; 
         color: white;
         }

        .body {
            font-family: Arial;
            font-size: 10pt;
            text-align:center;
        }

        .table {
            border: 1px solid #ccc;
            border-collapse: collapse;
            position: center;
            margin-left: auto;
            margin-right: auto;
            padding: 15px 32px;
        }

        .h1 {
            color: darkturquoise;
            text-align: center;
        }

        .table th {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }

        .table th, table td {
            padding: 5px;
            border-color: #ccc;
        }
    </style>
    <script type="text/javascript">  
</script>
</head>

<body class="body">
    <form id="form1" runat="server">
        <div >
            <h1 class="h1">Members of the HMO System </h1>
            <asp:Button ID="Button1" runat="server" 
               Class="button" Text="home"
                PostBackUrl="~/Default.aspx"/>
            <asp:Button ID="ButtonAddMember" runat="server"
               Class="button" Text="Add Member" OnClick="ButtonAddMember_Click"/>
        </div>
 
        <div runat="server" id="theDiv">
            <h2 class="h1"> Adding a member to HMO</h2>
            <table id="table1" class="table">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server"
                        Text="Enter full Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="full_name" runat="server"
                         placeholder="Enter Name"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server"
                         Text="Enter id"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="identity_card" runat="server"
                         placeholder="Enter  9 digitis"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server"
                         Text="Enter address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="address" runat="server" 
                         placeholder="Enter address"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server"
                         Text="Enter mobile phone"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="mobile_phone" runat="server" 
                        placeholder="Enter 10 digitis"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" 
                         Text="Enter phone"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="phone" runat="server"
                         placeholder="Enter 10 digitis"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" 
                         Text="Enter brith date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="date_birth" runat="server"
                         placeholder="format: yyyy-MM-dd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="ButtonSaveMember" runat="server" CssClass="button"
                         Text="Save Data" OnClick="ButtonSaveMember_Click"/>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="ButtonBack" runat="server" Text="Back"
                         OnClick="ButtonBack_Click" CssClass="button" />
                    </td>

                </tr>
            </table>
        </div>

        <div runat="server" id="DivTable">
            <asp:GridView class="Gridview" 
                ID="GridView_HMO_member" 
                runat="server" 
                AutoGenerateColumns="false" 
                DataKeyNames="code_HMO_member"
                OnPageIndexChanging="GridView_HMO_member_PageIndexChanging1"
                OnRowCancelingEdit="GridView_HMO_member_RowCancelingEdit1"
                OnRowDeleting="GridView_HMO_member_RowDeleting1"
                OnRowCommand="GridView_HMO_member_RowCommand">
                <Columns>
                    <asp:BoundField DataField="full_name" HeaderText=" Full Name " />
                    <asp:BoundField DataField="identity_card" HeaderText=" ID " />
                    <asp:CommandField ShowDeleteButton="true" />
                    <asp:ButtonField ButtonType="Button" CommandName="Get_Corone_Member"
                    Text="More" ControlStyle-BackColor="darkturquoise" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
