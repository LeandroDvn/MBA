using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using LiveCharts.Defaults;
using System.Threading;

namespace Grafico
{
    public partial class ChartForm : Form
    {
        int counter = 0;
        int counterProdutos = 0;
        int quantidadeLimiteIndicadores = 1000;
        Thread thread;
        LoadingForm loadingForm;

        public ChartForm()
        {
            InitializeComponent();
            loadingForm = new LoadingForm();
            cartesianChart1.UpdaterTick += CartesianChart1_UpdaterTick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            loadingForm.Show();
            ProcessChart();
        }

        public void ProcessChart()
        {
            var caminhoArquivo = ConfigurationSettings.AppSettings["caminhoArquivo"].ToString();

            var file = Directory.GetFiles(caminhoArquivo, "*csv").OrderByDescending(d => new FileInfo(d).CreationTime).First();

            List<CSV> CSVItems = File.ReadAllLines(file)
                                           .Skip(1)
                                           .Select(v => CSV.ConverteCsv(v))
                                           .Where(x => x != null && x.qtdVendida > 0)
                                           .GroupBy(x => new { x.nomeProduto, x.dataVenda })
                                           .Select(x => new CSV { dataVenda = x.Key.dataVenda, nomeProduto = x.Key.nomeProduto, qtdVendida = x.Sum(y => y.qtdVendida) })
                                           .OrderBy(x => x.qtdVendida)
                                           .ToList();

            var listaNome = new List<string>();
            var listaDataString = new List<string>();



            List<DateTime> distinctDates = CSVItems.Select(x => x.dataVenda).Distinct().OrderBy(y=>y.Date).ToList();

            foreach (var item in distinctDates)
            {
                listaDataString.Add(item.ToShortDateString());
            }

            cartesianChart1.AxisX.Add(new Axis() { Labels = listaDataString });
            cartesianChart1.AxisY.Add(new Axis { LabelFormatter = (value => value.ToString()), Separator = new Separator() });
            AddItemsToChart(CSVItems, distinctDates);
        }

        private void AddItemsToChart(List<CSV> CSVItems, List<DateTime> distinctDates)
        {
            var nomeProdutos = CSVItems.Select(x => x.nomeProduto).Distinct().Take(quantidadeLimiteIndicadores);
            counterProdutos = nomeProdutos.Count();
            thread = new Thread(() =>
            {
                SeriesCollection series = new SeriesCollection();
                foreach (var nomeProduto in nomeProdutos)
                {
                    List<ObservablePoint> values = new List<ObservablePoint>();
                    foreach (var item in CSVItems.Where(x => x.nomeProduto == nomeProduto))
                    {
                        values.Add(new ObservablePoint(distinctDates.IndexOf(item.dataVenda), item.qtdVendida));
                    }
                    Invoke(new Action(() => { series.Add(CreateSeries(nomeProduto, values)); }));
                    ChangeStatus(string.Format("Processando Dados: {0}/{1}", ++counter, counterProdutos));
                }

                ChangeStatus("Plotando " + counterProdutos + " indicadores\nIsto pode demorar um pouco");
                Invoke(new Action(() =>
                {
                    cartesianChart1.Series = series;
                    cartesianChart1.Update(true, false);
                }));
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void CartesianChart1_UpdaterTick(object sender)
        {
            if (cartesianChart1.Series.Count > 0)
            {
                ChangeStatus(string.Format("Tudo pronto agora"));
                loadingForm.Hide();
                this.Show();
            }
        }

        private void ChangeStatus(string txt)
        {
            Invoke(new Action(() =>
            {
                loadingForm.lblCarregando.Text = txt;
            }));
        }

        private ScatterSeries CreateSeries(string title, IList<ObservablePoint> values)
        {
            return new ScatterSeries()
            {
                Title = title,
                Values = new ChartValues<ObservablePoint>(values)
            };
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null && thread.IsAlive) thread.Abort();
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
