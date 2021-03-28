<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelamentoForm.aspx.cs" Inherits="AdegaSOA.ASPX.CancelamentoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2><asp:Label ID="LabelTitulo" runat="server" Text="Cancelamento de Pedido"></asp:Label></h2>
    
        <br />
    
        <asp:Label ID="Label1" runat="server" Text="Id do Pedido:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxPedidoId" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonCancelar" runat="server" onclick="ButtonCancelar_Click" 
            Text="Cancelar Pedido" />
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/ASPX/Home.aspx">Ir à página inicial</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>