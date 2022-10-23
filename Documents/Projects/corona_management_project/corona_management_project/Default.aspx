<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="corona_management_project.Default" %>

<html>
<head runat="server">

    <style type="text/css">
        .button {
            border: solid;
            color: darkturquoise;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
            position: center;
            background-color: white;
            border-color: black;

        }
        .button:hover {
         background-color: darkturquoise; 
         color: white;
         }
        .body {
            font-family: Arial;
            font-size: 10pt;
        }

        .table {
            border: 1px solid #ccc;
            border-collapse: collapse;
            position: center;
            margin-left: auto;
            margin-right: auto;
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
</head>
<body>
    <form id="form1" runat="server">
        <div id="menu">
            <div>
                <h1 class="h1">Welcome!</h1>
                <h1 class="h1">HMO Management System</h1>
            </div>

            <table class="table">
                
                <tr>
                    <td>
                        <asp:Button ID="ButtonDisplayMember" runat="server"
                            Class="button" Text="Members of HMO"
                            PostBackUrl="~/Retrival.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonDisplayReport" runat="server"
                            Class="button" Text="Report"
                            PostBackUrl="~/Report.aspx" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>



