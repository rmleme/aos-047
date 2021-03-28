using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using AdegaSOA.bpel4;


namespace AdegaSOA
{
    public partial class PedidoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdegaSOA.Entities.Estoque estoque = new AdegaSOA.Entities.Estoque();
            this.GridViewVinhos.DataSource = estoque.GetEstoque();
            this.GridViewVinhos.DataBind();
        }

        protected void ButtonComprar_Click(object sender, EventArgs e)
        {
            if (RadioButtonPF.Checked || RadioButtonPJ.Checked)
            {
                List<PedidoProcessRequestVinho> vinhos = new List<PedidoProcessRequestVinho>();

                int qtdeTotalVinho = 0;
                double valorTotal = 0;
                foreach (GridViewRow row in this.GridViewVinhos.Rows)
                {
                    PedidoProcessRequestVinho vinho = new PedidoProcessRequestVinho();
                    vinho.vinhoId = Convert.ToInt32(((HiddenField)row.FindControl("HiddenFieldVinhoId")).Value);
                    vinho.qtde = Convert.ToInt32(((TextBox)row.FindControl("TextBoxQtde")).Text);
                    qtdeTotalVinho = qtdeTotalVinho + vinho.qtde;
                    valorTotal += qtdeTotalVinho * Convert.ToDouble(row.Cells[3].Text);

                    if (vinho.qtde > 0)
                    {
                        vinhos.Add(vinho);
                    }
                }

                if (vinhos.Count > 0)
                {
                    Pedido pedidoWS = new Pedido();
                    PedidoProcessRequest request = new PedidoProcessRequest();
                    request.vinhos = vinhos.ToArray();
                    request.qtdeTotalVinho = qtdeTotalVinho;
                    request.valorTotal = valorTotal;

                    if (RadioButtonPF.Checked)
                    {
                        request.cpf = this.TextBoxCpf.Text;
                        request.nomePF = this.TextBoxNomePF.Text;
                        request.cartaoPF = this.TextBoxCartaoPF.Text;
                        request.enderecoPF = this.TextBoxEnderecoPF.Text;
                    }
                    else if (RadioButtonPJ.Checked)
                    {
                        request.cnpj = this.TextBoxCnpj.Text;
                        request.senha = this.TextBoxSenha.Text;
                    }

                    PedidoProcessResponse response = pedidoWS.process(request);
                }
            }
        }
    }
}