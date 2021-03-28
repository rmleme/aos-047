<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtualizarStatusPedidoForm.aspx.cs" Inherits="AdegaSOA.ASPX.AtualizarStatusPedidoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2><asp:Label ID="LabelTitulo" runat="server" Text="Atualizar status do pedido"></asp:Label></h2>
    
        <br />
        <asp:Label ID="LabelPedidoId" runat="server" Text="ID do Pedido:"></asp:Label>
    &nbsp;
        <asp:TextBox ID="TextBoxPedidoId" runat="server"></asp:TextBox>
&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelNaoEncontrado" runat="server" visible="False" 
            Text="Pedido não encontrado" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Button ID="ButtonPedidoId" runat="server" Text="Atualizar" 
            onclick="ButtonPedidoId_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelAlterado" runat="server" visible="False" Text="Status alterado com sucesso"></asp:Label>
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/ASPX/Home.aspx">Ir à página inicial</asp:HyperLink>
    </div>
    </form>
</body>
</html>