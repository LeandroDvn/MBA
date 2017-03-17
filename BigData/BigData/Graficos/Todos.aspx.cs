using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BigData.Graficos
{
    public partial class Todos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvProdutos.DataSource = funcoes.CSVtoTable(0);
                gvProdutos.DataBind();
            }
        }

        protected void gvProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProdutos.PageIndex = e.NewPageIndex;
            gvProdutos.DataSource = funcoes.CSVtoTable(0);
            gvProdutos.DataBind();
        }
    }
}