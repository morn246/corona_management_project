<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordForm.aspx.cs" Inherits="corona_management_project.RecordForm1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Untitled Page</title>
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
            text-align: center;
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
    <script type="text/javascript">  
</script>
</head>

<body class="body">
    <form id="form1" runat="server">
        <div>
            <h1 runat="server" id="NameMember" class="h1"></h1>
            <h1 runat="server" id="IdMember" class="h1"></h1>
        </div>

        <table class="table">
            <tr>
                <td>
                    <div>
                        <h2 class="h1">Personal Details</h2>
                    </div>
                    <div runat="server" id="DivGridViewHMOMember">
                        <asp:GridView ID="GridViewHmoMember" runat="server" CssClass="Gridview"
                            AutoGenerateColumns="false" DataKeyNames="code_HMO_member"
                            OnPageIndexChanging="GridViewHmoMember_PageIndexChanging" 
                            OnRowCancelingEdit="GridViewHmoMember_RowCancelingEdit"
                            OnRowEditing="GridViewHmoMember_RowEditing" 
                            OnRowUpdating="GridViewHmoMember_RowUpdating" >

                            <Columns>
                                <asp:BoundField DataField="address" HeaderText="address" />
                                <asp:BoundField DataField="mobile_phone" HeaderText="mobile_phone" />
                                <asp:BoundField DataField="phone" HeaderText="phone" />
                                <asp:BoundField DataField="date_birth" HeaderText="date_birth" />
                                <asp:CommandField ShowEditButton="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>

        <table class="table">
            <tr>
                <td>
                    <div>
                        <h2 class="h1">Corona Vaccines</h2>
                    </div>
                    <div runat="server" id="DivButtonAddVc">
                        <asp:Button ID="ButtonAddVc" runat="server" 
                            Class="button" Text="Add Vaccination"
                            OnClick="Add_vc_Click" CssClass="button" />
                    </div>
                    <div runat="server" id="DivAddVaccination">
                        <table id="table1" class="table">
                            <tr>
                                <td>
                                    <asp:Label ID="vaccination_date_Label" runat="server"
                                        Text="Enter vaccination_date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="vaccination_date" runat="server" 
                                     placeholder=" Format:yyyy-MM-dd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="code_manufacturer_Label" 
                                     runat="server" Text="code_manufacturer"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ManufacturerDropDownList" 
                                        runat="server" AutoPostBack="true"
                                        placeholder="select manufacturer name"
                                        DataValueField="code_manufacturer"
                                        DataTextField="name_manufacturer">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnSaveVc" runat="server"
                                     Text="Save Data" OnClick="btnSave_vaccination_Click" />
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="ButtonBackClick" runat="server"
                                     Text="Back" OnClick="Back_Click" />
                                </td>

                            </tr>
                        </table>
                    </div>
                    <div runat="server" id="DivVaccinationTable">
                        <asp:GridView ID="GridViewVaccination" runat="server" CssClass="Gridview"
                            AutoGenerateColumns="false" DataKeyNames="vaccination_date"
                            OnPageIndexChanging="GridViewVaccination_PageIndexChanging"
                            OnRowCancelingEdit="GridViewVaccination_RowCancelingEdit"
                            OnRowDeleting="GridViewVaccination_RowDeleting" 
                            OnRowEditing="GridViewVaccination_RowEditing"
                            OnRowUpdating="GridViewVaccination_RowUpdating">

                            <Columns>
                                <asp:BoundField DataField="vaccination_date" 
                                    HeaderText=" Date Corona vaccination " />

                                <asp:TemplateField HeaderText=" vaccination Type ">
                                    <ItemTemplate>
                                        <asp:DropDownList runat="server"
                                            ID="ManufacturerDropDownListEdit"                                          
                                            DataValueField="code_manufacturer"
                                            DataTextField="name_manufacturer">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowEditButton="true" />
                                <asp:CommandField ShowDeleteButton="true" />

                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>

        <table class="table">
            <tr>
                <td>
                    <div>
                        <h2 class="h1">Corona - more details</h2>
                    </div>
                    <div runat="server" id="DivAddCoronaButton">
                        <asp:Button ID="AddCoronaButton" runat="server"
                            Class="button"  CssClass="button"
                            Text="Adding dates of illness or recovery"
                            OnClick="Add_corona_Click" />
                    </div>
                    <div runat="server" id="DivAddPositivaCorona">
                        <table id="table2" class="table">
                            <tr>
                                <td>
                                    <asp:Label ID="date_positive_corona_Label" 
                                    runat="server" Text="Enter date_positive_corona"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="date_positive_corona" runat="server"
                                    placeholder=" Fprmat:yyyy-MM-dd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="date_recovery_corona_Label" runat="server"
                                    Text="Enter date_recovery_corona"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="date_recovery_corona" runat="server"
                                    placeholder=" Fprmat:yyyy-MM-dd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="ButtonSaveCorona" runat="server" CssClass="button"
                                    Text="Save Data" OnClick="btnSave_Corona_Click"  />
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="ButtonBack" runat="server" Text="Back"
                                    OnClick="Back_Click_Corona" CssClass="button" />
                                </td>

                            </tr>
                        </table>
                    </div>
                    <div runat="server" id="DivPositivaCoronaTable">
                        <asp:GridView ID="GridViewCorona" runat="server" CssClass="Gridview"
                         AutoGenerateColumns="false" DataKeyNames="code_HMO_member"
                         OnPageIndexChanging="GridViewCorona_PageIndexChanging" 
                         OnRowCancelingEdit="GridViewCorona_RowCancelingEdit"
                         OnRowDeleting="GridViewCorona_RowDeleting" 
                         OnRowEditing="GridViewCorona_RowEditing"
                         OnRowUpdating="GridViewCorona_RowUpdating">
                            <Columns>
                                <asp:BoundField DataField="date_positive_corona" 
                                 HeaderText=" Date receiving the coronavirus " />
                                <asp:BoundField DataField="date_recovery_corona"
                                 HeaderText=" Date recovery from coronavirus " />
                                <asp:CommandField ShowEditButton="true" />
                                <asp:CommandField ShowDeleteButton="true" />

                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
