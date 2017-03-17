using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BigData.Graficos
{
    public partial class Custo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                montaGraficoPieChart();
            }
        }

        private void montaGraficoPieChart()
        {
            //Busca Informações
            DataTable dataTable = funcoes.CSVtoTable(10);

            //Ordena pela Coluna Desejada
            EnumerableRowCollection<DataRow> query = from order in dataTable.AsEnumerable()
                                                     orderby order.Field<decimal>("Custo") descending
                                                     select order;

            //Escolha quais colunas devem ir pro Grid
            string[] selectedColumns = new[] { "Código", "Produto", "Custo" };
            DataTable dt = new DataView(dataTable).ToTable(false, selectedColumns);

            gvProdutos.DataSource = dt;
            gvProdutos.DataBind();

            //Escolha quais colunas devem ir pro Grid
            //string[] selectedColumns = new[] { "Produto", "R$ Custo" };
            //DataTable dt = new DataView(dataTable).ToTable(false, selectedColumns);

            gvProdutos.DataSource = dt;
            gvProdutos.DataBind();

            //DataTable dt = new DataTable();
            //dt = lerCSV();
            StringBuilder strScript = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                try
                {
                    strScript.Append(@"<script type='text/javascript'>  
                                       google.charts.load('current', {'packages':['corechart']});
                                       google.charts.setOnLoadCallback(drawChart);

                                       function drawChart() {
                                         var data = google.visualization.arrayToDataTable([
                                         ['Produto', 'Custo'],");

                    foreach (DataRow row in dt.Rows)
                    {
                        strScript.Append("['" + row["Produto"] + "'," + row["Custo"] + "],");
                    }

                    strScript.Remove(strScript.Length - 1, 1);
                    strScript.Append("]);");

                    //strScript.Append("var options = {legend: {position: 'none'}, vAxis: { format: '0.0' }};");

                    strScript.Append("var options = {          title: 'Produtos com Maiores Custos'        }; ");

                    strScript.Append("var chart = new google.visualization.ColumnChart(document.getElementById('curve_chart')); chart.draw(data, options);}</script><div id='curve_chart' style='width: 700px; height: 400px'></div>");

                    ltScripts.Text = strScript.ToString();
                }
                catch
                {
                }
                finally
                {
                    dt.Dispose();
                    strScript.Clear();
                }
            }
            else
                ltScripts.Text = "<div class=''><br/><div style='margin: 5px'><div class='titulo-box' style='margin-left: 15px'>Não existem mudanças Cadastradas.</div></div></div><br/>";
        }
    }
}