<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unit Converter</title>
</head>
<body>
    <form id="form1" runat="server">
    <center><table style="width: 677px"><tr><td colspan="2">
    <h1 style="text-align: center;">Unit Conversion</h1></td></tr>
        <tr>
            <td colspan="2" style="text-align:center"><asp:TextBox ID="num1" runat="server"></asp:TextBox><asp:DropDownList ID="fromList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Unit" DataValueField="Unit"></asp:DropDownList> 
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Unit] FROM [Conversions]"></asp:SqlDataSource>
                = <asp:TextBox ID="num2" runat="server" ReadOnly="True"></asp:TextBox><asp:DropDownList ID="toList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Unit" DataValueField="Unit"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; padding-top:25px;">
                <asp:Button ID="Convert" runat="server" Text="Convert" OnClick="Convert_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; padding-top:25px;" class="auto-style1"><asp:TextBox ID="ErrorBox" runat="server" style="text-align:center" Visible="False" ReadOnly="True" Width="346px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center; padding-top:25px;"><asp:Button ID="DBEdit" runat="server" Text="Modify Database" OnClick="DBEdit_Click"></asp:Button></td>
        </tr>
    </table></center>
    </form>
</body>
</html>
