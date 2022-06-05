<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="JohanePetStore.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style4 {
            width: 249px;
            text-align: right;
        }
        .auto-style5 {
            width: 249px;
            text-align: right;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <h1><strong>Johane Pet Store</strong></h1>
        </div>
        <p>
            <asp:TextBox ID="txtPetID" runat="server" Visible="False"></asp:TextBox>
        </p>
        <table class="auto-style2" align="center">
            <tr>
                <td class="auto-style4">Pet Name</td>
                <td>
                    <asp:TextBox ID="txtPetName" runat="server" Width="553px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Pet Age</td>
                <td>
                    <asp:TextBox ID="txtPetAge" runat="server" Width="553px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Pet Sex</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="dropdownSex" runat="server">
                        <asp:ListItem Selected="True">Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Pet Breed</td>
                <td>
                    <asp:TextBox ID="txtPetBreed" runat="server" Width="553px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Pet Status</td>
                <td>
                    <asp:TextBox ID="txtPetStatus" runat="server" Width="553px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Pet Price</td>
                <td>
                    <asp:TextBox ID="txtPetPrice" runat="server" Width="553px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
            <asp:Button ID="btnAdd" runat="server" Height="36px" OnClick="btnAdd_Click" Text="Add" Width="161px" />
            <asp:Button ID="btnUpdate" runat="server" Height="36px" OnClick="btnUpdate_Click" Text="Update" Width="161px" />
            <asp:Button ID="btnDelete" runat="server" Height="36px" OnClick="btnDelete_Click" Text="Delete" Width="161px" />
            <asp:Button ID="btnClear" runat="server" Height="36px" OnClick="btnClear_Click" Text="Clear" Width="161px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:GridView ID="gridviewPets" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridviewPets_SelectedIndexChanged">
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
