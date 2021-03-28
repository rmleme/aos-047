<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReposicaoForm.aspx.cs" Inherits="AdegaSOA.ASPX.ReposicaoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2><asp:Label ID="LabelTitulo" runat="server" Text="Reposição de Estoque"></asp:Label></h2>
    
        <asp:Button ID="ButtonRepor" runat="server" onclick="ButtonRepor_Click" 
            Text="Repor Estoque" />
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/ASPX/Home.aspx">Ir à página inicial</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>