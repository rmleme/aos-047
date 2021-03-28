<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PedidoForm.aspx.cs" Inherits="AdegaSOA.PedidoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Adega</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
    
        <h2><asp:Label ID="LabelTitulo" runat="server" Text="Pedido de Vinhos"></asp:Label></h2>
    
        <table class="style1">
            <tr>
                <td>
                    <asp:RadioButton ID="RadioButtonPF" runat="server" GroupName="TipoPessoa" 
                        Text="PF" />
                </td>
                <td>
                    <asp:Label ID="LabelCpf" runat="server" Text="CPF:"></asp:Label>
                    <asp:TextBox ID="TextBoxCpf" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelNomePF" runat="server" Text="Nome:"></asp:Label>
                    <asp:TextBox ID="TextBoxNomePF" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelCartaoPF" runat="server" Text="Cartão:"></asp:Label>
                    <asp:TextBox ID="TextBoxCartaoPF" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelEnderecoPF" runat="server" Text="Endereço:"></asp:Label>
                    <asp:TextBox ID="TextBoxEnderecoPF" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="RadioButtonPJ" runat="server" GroupName="TipoPessoa" 
                        Text="PJ" />
                </td>
                <td>
                    <asp:Label ID="LabelCnpj" runat="server" Text="CNPJ:"></asp:Label>
                    <asp:TextBox ID="TextBoxCnpj" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelSenha" runat="server" Text="Senha:"></asp:Label>
                    <asp:TextBox ID="TextBoxSenha" runat="server" MaxLength="10" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
    </table>
    <br />
    <asp:Button ID="ButtonComprar" runat="server" onclick="ButtonComprar_Click" 
        Text="Comprar" />
    <br />
<h3><asp:label id="labelEstoque" runat="server" visible="false">Vinhos disponíveis e prazos de entrega</asp:label></h3>    
        <asp:GridView ID="GridViewVinhos" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenFieldVinhoId" runat="server" Value='<%# Bind("vinhoId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Nome" DataField="nome" />
                <asp:BoundField HeaderText="Tipo" DataField="tipo" />
                <asp:BoundField HeaderText="Preço (R$)" DataField="preco" />
                <asp:BoundField HeaderText="Prazo (Dias)" DataField="prazo" />
                <asp:BoundField HeaderText="Qtde. Disponível" DataField="qtdeAtual" />
                <asp:TemplateField HeaderText="Qtde. Desejada">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxQtde" runat="server" Text='<%# Bind("qtdeAtual") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
    <br />
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/ASPX/Home.aspx">Ir à página inicial</asp:HyperLink>
</form>
</body>
</html>