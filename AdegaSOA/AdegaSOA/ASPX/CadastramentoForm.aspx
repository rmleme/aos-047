<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastramentoForm.aspx.cs" Inherits="AdegaSOA.CadastramentoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2><asp:Label ID="LabelTitulo" runat="server" Text="Cadastramento - PJ"></asp:Label></h2>
    
        <br />
        <asp:Label ID="LabelCnpj" runat="server" Text="CNPJ:"></asp:Label>
        
    
        &nbsp;&nbsp;&nbsp;&nbsp;
        
    
        <asp:TextBox ID="TextBoxCnpj" runat="server" MaxLength="14"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBoxCnpj" Display="Dynamic" 
            ErrorMessage="ID de usuário requerido" ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TextBoxCnpj" Display="Dynamic" 
            ErrorMessage="Entre com seu CNPJ" 
            ValidationExpression="\d{1,14}" 
            ValidationGroup="AllValidators"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Label ID="LabelSenha" runat="server" Text="Senha:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBoxSenha" runat="server" 
            TextMode="Password" MaxLength="10"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBoxSenha" Display="Dynamic" ErrorMessage="Senha requerida" 
            ValidationGroup="AllValidators">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="TextBoxSenha" Display="Dynamic" 
            ErrorMessage="Entre com uma senha alfanumérica de 6 até 10 dígitos" 
            ValidationExpression="\w{6,10}" 
            ValidationGroup="AllValidators"></asp:RegularExpressionValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;<br />
        <br />
      
        <asp:Button ID="ButtonCadastrar" runat="server" onclick="ButtonCadastrar_Click" Text="Cadastrar" 
            ValidationGroup="AllValidators" />
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/ASPX/Home.aspx">Ir à página inicial</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
