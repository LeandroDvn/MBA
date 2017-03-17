using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BigData
{
    public partial class Grafico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                montaGraficoPieChart();
            }
        }

        private void montaGraficoLineChart()
        {
            DataTable dataTable = CSVtoTable();

            string[] selectedColumns = new[] { "nmproduto", "qtvenda" };
            DataTable dt = new DataView(dataTable).ToTable(false, selectedColumns);

            GridView1.DataSource = dt;
            GridView1.DataBind();

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
                                     ['Produto', 'Vendas'],");

                    foreach (DataRow row in dt.Rows)
                    {
                        strScript.Append("['" + row["nmproduto"] + "'," + row["qtvenda"] + "],");
                    }

                    strScript.Remove(strScript.Length - 1, 1);
                    strScript.Append("]);");

                    strScript.Append("var options = {legend: {position: 'none'}, vAxis: { format: '0.0' }};");
                    strScript.Append("var chart = new google.visualization.LineChart(document.getElementById('curve_chart')); chart.draw(data, options);}</script><div id='curve_chart' style='width: 700px; height: 400px'></div>");

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

        private void montaGraficoPieChart()
        {
            DataTable dataTable = CSVtoTable();

            string[] selectedColumns = new[] { "nmproduto", "qtvenda" };
            DataTable dt = new DataView(dataTable).ToTable(false, selectedColumns);

            GridView1.DataSource = dt;
            GridView1.DataBind();

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
                                         ['Produto', 'Vendas'],");

                    foreach (DataRow row in dt.Rows)
                    {
                        strScript.Append("['" + row["nmproduto"] + "'," + row["qtvenda"] + "],");
                    }

                    strScript.Remove(strScript.Length - 1, 1);
                    strScript.Append("]);");

                    //strScript.Append("var options = {legend: {position: 'none'}, vAxis: { format: '0.0' }};");

                    strScript.Append("var options = {          title: 'Maiores Vendas'        }; ");

                    strScript.Append("var chart = new google.visualization.PieChart(document.getElementById('curve_chart')); chart.draw(data, options);}</script><div id='curve_chart' style='width: 700px; height: 400px'></div>");

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

        public DataTable CSVtoTable()
        {
            string CSVFilePathName = @"C:\csv.csv";
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);

            DataTable dt = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            for (int i = 0; i < Cols; i++)
                dt.Columns.Add(Fields[i].ToLower(), typeof(string));

            //DataTable dt = new DataTable();

            //dt.Columns.Add("cdProduto", typeof(int));
            //dt.Columns.Add("nmProduto", typeof(string));
            //dt.Columns.Add("qtvenda", typeof(int));
            //dt.Columns.Add("vlvenda", typeof(float));
            //dt.Columns.Add("vlcusto", typeof(float));

            DataRow Row;
            for (int i = 1; i < 20; i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                Row = dt.NewRow();
                for (int f = 0; f < Cols; f++)
                    Row[f] = Fields[f];
                dt.Rows.Add(Row);
            }

            return dt;
        }

        //private DataTable getDadosLista()
        //{
        //    DataTable dt = new DataTable();

        //    dt.Columns.Add("Mudança", typeof(string));
        //    dt.Columns.Add("Quantidade", typeof(int));
        //    try
        //    {
        //        using (SPSite oSiteCollection = new SPSite(SPContext.Current.Site.Url))
        //        {
        //            using (SPWeb oWebsite = oSiteCollection.OpenWeb())
        //            {
        //                SPList mudancas = oWebsite.Lists.TryGetList("Mudança");
        //                if (mudancas != null)
        //                {
        //                    SPQuery qry = new SPQuery();

        //                    qry.Query = @"   <ViewFields>
        //                                          <FieldRef Name='DataHoraFim' />
        //                                          <FieldRef Name='Title' />
        //                                       </ViewFields>
        //                                       <Where>
        //                                          <Lt>
        //                                             <FieldRef Name='DataHoraFim' />
        //                                             <Value Type='DateTime'>
        //                                                <Today />
        //                                             </Value>
        //                                          </Lt>
        //                                       </Where>";

        //                    SPListItemCollection listaMudancasEncerradas = mudancas.GetItems(qry);

        //                    if (listaMudancasEncerradas.Count > 0)
        //                    {
        //                        var busca = (from SPListItem tarefa in listaMudancasEncerradas
        //                                     group tarefa by tarefa["DataHoraFim"] into grp
        //                                     orderby grp.Key
        //                                     select new
        //                                     {
        //                                         Mudança = grp.Key,
        //                                         Quantidade = grp.Count()
        //                                     });

        //                        foreach (var item in busca)
        //                        {
        //                            DataRow dr = dt.NewRow();
        //                            dr["Mudança"] = Convert.ToDateTime(item.Mudança).ToString("dd/MM").ToString();
        //                            dr["Quantidade"] = item.Quantidade;
        //                            dt.Rows.Add(dr);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return dt;
        //}
    }
}