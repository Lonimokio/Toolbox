using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Toolbox.pages
{
    public partial class Ping_Tester : UserControl, INotifyPropertyChanged
    {
        private DispatcherTimer timer;
        private string targetAddress = "google.com"; // Change this to your desired domain or IP address
        public SeriesCollection PingSeriesCollection { get; } = new SeriesCollection();

        public Ping_Tester()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Adjust the interval as needed
            timer.Tick += Timer_Tick;
            DataContext = this;
            SetupChart();
        }

        private void SetupChart()
        {
            var lineSeries = new LineSeries
            {
                Title = "Ping Results",
                Values = new ChartValues<ObservablePoint>(),
                LineSmoothness = 0
            };
            PingSeriesCollection.Add(lineSeries);
        }

        private void btnPing_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                btnPing.Content = "Stop Ping";
                timer.Start();
            }
            else
            {
                btnPing.Content = "Start Ping";
                timer.Stop();
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = await ping.SendPingAsync(targetAddress);
                    if (reply != null)
                    {
                        if (reply.Status == IPStatus.Success)
                        {
                            Dispatcher.Invoke(() =>
                            {
                                string pingResult = $"Ping to {targetAddress}: Success, Time: {reply.RoundtripTime} ms";
                                lbResults.Items.Add(pingResult);

                                // Scroll the ListBox to the bottom
                                var scrollViewer = GetDescendantByType(lbResults, typeof(ScrollViewer)) as ScrollViewer;
                                if (scrollViewer != null)
                                {
                                    scrollViewer.ScrollToBottom();
                                }

                                // Add data point to the chart
                                ((ChartValues<ObservablePoint>)PingSeriesCollection[0].Values).Add(new ObservablePoint(PingSeriesCollection[0].Values.Count + 1, reply.RoundtripTime));

                                // Update the chart viewport to display only the latest data points
                                int maxDataPoints = 10; // Adjust this value as needed
                                if (PingSeriesCollection[0].Values.Count > maxDataPoints)
                                {
                                    pingChart.AxisX[0].MaxValue = PingSeriesCollection[0].Values.Count;
                                    pingChart.AxisX[0].MinValue = PingSeriesCollection[0].Values.Count - maxDataPoints;
                                }
                            });
                        }
                        else
                        {
                            Dispatcher.Invoke(() =>
                            {
                                lbResults.Items.Add($"Ping to {targetAddress}: {reply.Status}");
                            });
                        }
                    }
                    else
                    {
                        Dispatcher.Invoke(() =>
                        {
                            lbResults.Items.Add("Ping reply is null");
                        });
                    }
                }
            }
            catch (PingException ex)
            {
                // Handle ping errors
                Dispatcher.Invoke(() =>
                {
                    lbResults.Items.Add($"Error pinging {targetAddress}: {ex.Message}");
                });
            }
        }




        // Helper method to get child element by type
        private DependencyObject GetDescendantByType(DependencyObject element, Type type)
        {
            if (element == null) return null;
            if (element.GetType() == type) return element;

            DependencyObject result = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);
                result = GetDescendantByType(child, type);
                if (result != null) break;
            }
            return result;
        }


        private void txtDomain_TextChanged(object sender, TextChangedEventArgs e)
        {
            targetAddress = txtDomain.Text;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
