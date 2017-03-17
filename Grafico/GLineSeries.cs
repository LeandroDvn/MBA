using System.Drawing;

namespace Grafico
{
    internal class GLineSeries
    {
        public Brush Fill { get; set; }
        public object PointGeometry { get; set; }
        public double StrokeThickness { get; set; }
        public object Values { get; set; }
    }
}