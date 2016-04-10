<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modify.aspx.cs" Inherits="Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modify Conversion Database</title>
</head>
<body>
    <form id="form1" runat="server">
    <center><table style="width: 677px"><tr><td colspan="2">
        <h1 style="text-align: center;">Modify Database</h1></td></tr>
        <tr>
            <td colspan ="2" style="text-align:center"><asp:DropDownList ID="HoldsID" runat="server" DataSourceID="SqlDataSource1" DataTextField="Unit" DataValueField="Id" OnSelectedIndexChanged="HoldsID_SelectedIndexChanged"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Conversions]"></asp:SqlDataSource><asp:Button ID="ShowFactor" runat="server" Text="Show Factor" OnClick="ShowFactor_Click"></asp:Button><asp:Button ID="DeleteConversion" runat="server" Text="Delete" OnClick="DeleteConversion_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;"><asp:TextBox ID="ShowFactorPrint" runat="server" ReadOnly="True" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center"><asp:TextBox ID="Unit" runat="server"></asp:TextBox><asp:TextBox ID="Factor" runat="server"></asp:TextBox><asp:Button ID="AddConversion" runat="server" Text="Add" OnClick="AddConversion_Click"></asp:Button></td>
        </tr
        <tr>
            <td colspan="2" style="text-align:center; padding-top:25px;" class="auto-style1"><asp:TextBox ID="ErrorBox" runat="server" style="text-align:center" Visible="False" ReadOnly="True" Width="346px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; padding-top:25px;"><asp:Button ID="Back" runat="server" Text="Back to Converter" OnClick="Back_Click"></asp:Button></td>
        </tr>
    </table></center>
    </form>
</body>
</html>
