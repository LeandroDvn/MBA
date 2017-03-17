using System;
using System.Data;
using System.Text;
using System.Web.UI;

namespace BigData.Graficos
{
    public partial class Quantidade : System.Web.UI.Page
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
            string script;

            DataTable dataTable = funcoes.CSVtoTable(10);

            string[] selectedColumns = new[] { "Código", "Produto", "Quantidade de Vendas" };
            DataTable dt = new DataView(dataTable).ToTable(false, selectedColumns);

            gvProdutos.DataSource = dt;
            gvProdutos.DataBind();

            //DataTable dt = new DataTable();
            //dt = lerCSV();
            StringBuilder strScript = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                try
                {
                    script = @"<script type='text/javascript'>  
                                       google.charts.load('current', {'packages':['corechart']});
                                       google.charts.setOnLoadCallback(drawChart);

                                       function drawChart() {
                                         var data = google.visualization.arrayToDataTable([
                                         ['Produto', 'Quantidade de Vendas'],";

                    foreach (DataRow row in dt.Rows)
                    {
                        script += "['" + row["Produto"] + "'," + row["Quantidade de Vendas"] + "],";
                    }

                    script.Remove(script.Length - 1, 1);
                    script += "]);";

                    //strScript.Append("var options = {legend: {position: 'none'}, vAxis: { format: '0.0' }};");

                    ltScripts.Text = script;

                    ltScripts.Text += "var options = {          title: 'Produtos mais Vendidos (Quantidade)'        }; ";                    
                    ltScripts.Text += "var chart = new google.visualization.ColumnChart(document.getElementById('curve_chart')); chart.draw(data, options);}</script><div id='curve_chart' style='width: 700px; height: 400px'></div>";

                    ltScripts2.Text = script;
                    ltScripts2.Text += "var options = {          title: 'Produtos mais Vendidos (%)'        }; ";
                    ltScripts2.Text += "var chart = new google.visualization.PieChart(document.getElementById('curve_chart2')); chart.draw(data, options);}</script><div id='curve_chart2' style='width: 700px; height: 400px'></div>";
                    
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