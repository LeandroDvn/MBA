using System;
using System.Data;
using System.IO;

namespace BigData
{
    public class funcoes
    {
        public static DataTable CSVtoTable(int quantidadeItens)
        {
            string CSVFilePathName = @"C:\csv.csv";
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);
            DataTable dt = new DataTable();

            dt.Columns.Add("Código", typeof(int));
            dt.Columns.Add("Produto", typeof(string));
            dt.Columns.Add("Quantidade de Vendas", typeof(decimal));
            dt.Columns.Add("Preço de venda", typeof(decimal));
            dt.Columns.Add("Custo", typeof(decimal));

            DataRow Row;
            int itensQtd = 0;

            if (quantidadeItens > 0)
                itensQtd = quantidadeItens+1;
            else
                itensQtd = Lines.GetLength(0);

            for (int i = 1; i < itensQtd; i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                Row = dt.NewRow();

                if(Fields[0] != "")
                    Row[0] = Fields[0];
                else
                    Row[0] = 0;

                if (Fields[1] != "")
                    Row[1] = Fields[1];
                else
                    Row[1] = "";

                if (Fields[2] != "")
                    Row[2] = Fields[2];
                else
                    Row[2] = "";

                if (Fields[3] != "")
                    Row[3] = Fields[3];
                else
                    Row[3] = "";

                if (Fields[4] != "")
                    Row[4] = Fields[4];
                else
                    Row[4] = 0;

                dt.Rows.Add(Row);
            }

            return dt;
        }
    }
}