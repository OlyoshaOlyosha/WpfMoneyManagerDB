using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace MoneyManagerX
{
    public partial class IncomePage : Page
    {
        public IncomePage()
        {
            InitializeComponent();
            pieChart.Series = new SeriesCollection
            {
                 new PieSeries()
                 {
                     Values = new ChartValues<double>
                     {
                         10
                     },
                     DataLabels = true,
                     Fill = new SolidColorBrush(Colors.White),
                     LabelPoint = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P})"
                 },
                 new PieSeries()
                 {
                     Values = new ChartValues<double>
                     {
                         20
                     },
                     DataLabels = true,
                     Fill = new SolidColorBrush(Colors.Blue),
                     LabelPoint = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P})"
                 },
                 new PieSeries()
                 {
                     Values = new ChartValues<double>
                     {
                         30
                     },
                     DataLabels = true,
                     Fill = new SolidColorBrush(Colors.Red),
                     LabelPoint = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P})"
                 },
            };
            pieChart.LegendLocation = LegendLocation.Right;
        }
    }
}
