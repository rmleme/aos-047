using System;
using AdegaSOA.bpel1;

namespace AdegaSOA.ASPX
{
    public partial class CancelamentoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Cancelamento cancelamentoWS = new Cancelamento();
            CancelamentoProcessRequest request = new CancelamentoProcessRequest();
            request.input = this.TextBoxPedidoId.Text;
            CancelamentoProcessResponse response = cancelamentoWS.process(request);
            this.TextBoxPedidoId.Text = string.Empty;
        }
    }
}