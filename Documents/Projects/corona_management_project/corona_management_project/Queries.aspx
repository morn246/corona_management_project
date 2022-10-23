<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Queries.aspx.cs" Inherits="corona_management_project.Queries" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
                <h1 class="h1">Queries</h1>
                <h1 class="h1">HMO Management System</h1>
            </div>

            <table class="table">
                <tr>
                    <td>
                        <asp:Button ID="ButtonHome" runat="server"
                            Class="button" Text="home"
                            PostBackUrl="~/Default.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonNumNotVaccinatedMember" runat="server"
                            Class="button" Text="Number of members of the Copa who are not vaccinated at all"
                            OnClick="ButtonNumNotVaccinatedMember_Click" />
                    </td>
                    <td>
                        <div>
                            <asp:TextBox ID="NumNotVaccinatedMember" runat="server"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonPatientGraphLastMonth" runat="server"
                            Class="button" Text="query Graph"
                            OnClick="ButtonPatientGraphLastMonth_Click1" />                                                    
                    </td>
                    <td>                       
                     </td>
                       
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
