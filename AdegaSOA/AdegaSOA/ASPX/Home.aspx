<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AdegaSOA.ASPX.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/ASPX/PedidoForm.aspx">Comprar Vinhos</asp:HyperLink>
    
        <br />
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/ASPX/CadastramentoForm.aspx">Cadastrar PJ</asp:HyperLink>
    
        <br />
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/ASPX/ReposicaoForm.aspx">Repor Estoque</asp:HyperLink>
    
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/ASPX/CancelamentoForm.aspx">Cancelar Pedido</asp:HyperLink>
    
        <br />
        <br />
        <asp:HyperLink ID="HyperLink5" runat="server"
        NavigateUrl="~/ASPX/AtualizarStatusPedidoForm.aspx">Atualizar Status Pedido</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
