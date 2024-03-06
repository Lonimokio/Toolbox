using System;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LibreHardwareMonitor.Hardware;
using Timer = System.Timers.Timer;

namespace Toolbox.pages
{
    /// <summary>
    /// Interaction logic for SystemInformation.xaml
    /// </summary>
    public partial class System_Information : UserControl, IVisitor
    {
        private StackPanel InfoStackPanel;
        private Computer computer; // Declare computer as a class-level variable

        public System_Information()
        {
            InitializeComponent();
            InfoStackPanel = new StackPanel();

            // Initialize the timer
            _timer = new Timer(1000);
            // Subscribe the Timer_Elapsed method to the Elapsed event
            _timer.Elapsed += Timer_Elapsed;

            // Initialize the computer object
            computer = new Computer
            {
                IsGpuEnabled = true,
                IsCpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsControllerEnabled = true,
                IsNetworkEnabled = true,
                IsStorageEnabled = true
            };
        }

        private Timer _timer;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Start the timer asynchronously
            await Task.Run(() =>
            {
                computer.Open();
                _timer.Start();
            });
        }

        public async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                computer.Reset();
                // Clear the InfoStackPanel and any other relevant state asynchronously
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    InfoStackPanel.Children.Clear();
                });

                // Update the system information asynchronously
                await Task.Run(() =>
                {
                    computer.Accept(this);
                    UpdateUi();
                });
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("An error occurred during timer iteration: " + ex.Message);
            }
        }



        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }

        public void VisitHardware(IHardware hardware)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Create a text block for the hardware name and type
                TextBlock hardwareText = new TextBlock();
                hardwareText.Text = $"{hardware.Name} ({hardware.HardwareType})";
                hardwareText.FontWeight = FontWeights.Bold;
                hardwareText.Margin = new Thickness(0, 10, 0, 0);
                hardwareText.HorizontalAlignment = HorizontalAlignment.Left;
                hardwareText.VerticalAlignment = VerticalAlignment.Top;
                hardwareText.FontSize = 16; // Adjust the font size as needed

                // Add the text block to the stack panel
                InfoStackPanel.Children.Add(hardwareText);

                foreach (IHardware subHardware in hardware.SubHardware)
                {
                    subHardware.Accept(this);
                }

                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.Value.HasValue)
                    {
                        // Create a text block for the sensor name
                        TextBlock sensorNameText = new TextBlock();
                        sensorNameText.Text = $"{sensor.Name}: ";
                        sensorNameText.FontSize = 16;
                        sensorNameText.Margin = new Thickness(20, 0, 0, 0);

                        // Add the sensor name text block to the stack panel
                        InfoStackPanel.Children.Add(sensorNameText);

                        // Create a text block for the sensor type
                        TextBlock sensorTypeText = new TextBlock();
                        sensorTypeText.Text = $"{sensor.SensorType}";
                        sensorTypeText.FontSize = 16;
                        sensorTypeText.Margin = new Thickness(20, 0, 0, 0);

                        // Add the sensor type text block to the stack panel
                        InfoStackPanel.Children.Add(sensorTypeText);

                        // Create a text block for the sensor value
                        TextBlock sensorValueText = new TextBlock();
                        sensorValueText.Text = $"{sensor.Value} ";
                        sensorValueText.FontSize = 16;
                        sensorValueText.Margin = new Thickness(25, 0, 0, 10);
                        sensorValueText.Foreground = Brushes.Red; 

                        // Add the sensor value text block to the stack panel
                        InfoStackPanel.Children.Add(sensorValueText);
                    }
                }

            });
        }


        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }

        private void UpdateUi()
        {
            // Update the UI with the new information
            InformationStackPanel.Dispatcher.Invoke(() =>
            {
                InformationStackPanel.Children.Clear();
                InformationStackPanel.Children.Add(InfoStackPanel);
            });

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // Stop the timer
            computer.Close();
            _timer.Stop();
        }

    }
}
