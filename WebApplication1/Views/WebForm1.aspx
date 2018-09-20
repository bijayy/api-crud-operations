<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <asp:label runat="server" text="Id: "></asp:label>
        <asp:TextBox runat="server" id="txtId"></asp:TextBox>
    </div>
    <div>
        <asp:label runat="server" text="Name: "></asp:label>
        <asp:TextBox runat="server" id="txtName"></asp:TextBox>
    </div>
        <div>
        <asp:label runat="server" text="Email: "></asp:label>
        <asp:TextBox runat="server" id="txtEmail"></asp:TextBox>
    </div>
    <div>
        <asp:Button runat="server" Text="Save" OnClick="ButtonSave_Click" />
        <asp:Button runat="server" Text="Udpate" OnClick="ButtonUpdate_Click" />
    </div>
    </form>
</body>
</html>
