using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico
{
    public class CSV
    {
        public DateTime dataVenda;
        public string nomeProduto;
        public double qtdVendida;

        public static CSV ConverteCsv(string csvLine)
        {
            CSV csvValues = null;
            if (!string.IsNullOrEmpty(csvLine))
            {
                string[] values = csvLine.Split(',');
                csvValues = new CSV();
                csvValues.dataVenda = Convert.ToDateTime(values[1]);
                csvValues.nomeProduto = values[3];
                csvValues.qtdVendida = Convert.ToDouble(values[4]);
            }
            return csvValues;
        }
    }
}
