using System;
using AdegaSOA.Entities;

namespace AdegaSOA.ASPX
{
    public partial class AtualizarStatusPedidoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonPedidoId_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido = pedido.ConsultarPedido(Convert.ToInt32(this.TextBoxPedidoId.Text));
            if (pedido.pedidoId == 0)
            {
                this.LabelAlterado.Visible = false;
                this.LabelNaoEncontrado.Visible = true;
            }
            else
            {
                Estoque estoque = new Estoque();
                estoque.AtualizarStatusPedido(pedido);
                this.LabelNaoEncontrado.Visible = false;
                this.LabelAlterado.Visible = true;
            }
        }
    }
}