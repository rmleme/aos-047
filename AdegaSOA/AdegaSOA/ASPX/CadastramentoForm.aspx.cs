using System;
using System.Web.UI;
using AdegaSOA.bpel3;

namespace AdegaSOA
{
    public partial class CadastramentoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonCadastrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Cadastramento cadastramentoWS = new Cadastramento();
                CadastramentoProcessRequest request = new CadastramentoProcessRequest();
                request.cnpj = this.TextBoxCnpj.Text;
                request.senha = this.TextBoxSenha.Text;
                CadastramentoProcessResponse response = cadastramentoWS.process(request);
                this.TextBoxCnpj.Text = string.Empty;
                this.TextBoxSenha.Text = string.Empty;
            }
        }
    }
}