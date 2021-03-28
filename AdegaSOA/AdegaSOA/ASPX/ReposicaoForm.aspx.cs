using System;
using AdegaSOA.bpel2;

namespace AdegaSOA.ASPX
{
    public partial class ReposicaoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonRepor_Click(object sender, EventArgs e)
        {
            Reposicao reposicaoWS = new Reposicao();
            ReposicaoProcessRequest request = new ReposicaoProcessRequest();
            ReposicaoProcessResponse response = reposicaoWS.process(request);
        }
    }
}