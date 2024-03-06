using System.Windows;
using System.Windows.Controls;

namespace Toolbox.pages
{
    /// <summary>
    /// Interaction logic for RandomNumberGenerator.xaml
    /// </summary>
    public partial class Random_Number_Generator : UserControl
    {
        public Random_Number_Generator()
        {
            InitializeComponent();
        }
        private void GenerateRandomNumber_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int minValue = int.Parse(txtMinValue.Text);
                int maxValue = int.Parse(txtMaxValue.Text);

                if (minValue >= maxValue)
                {
                    MessageBox.Show("Min Value must be less than Max Value");
                    return;
                }

                Random rnd = new Random();
                int randomNumber = rnd.Next(minValue, maxValue + 1); // Adding 1 to include the maxValue in the range

                txtResult.Text = $"{randomNumber}";
                txtResult.Visibility = Visibility.Visible;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid integer values.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtMinValue.Text = "";
            txtMaxValue.Text = "";
            txtResult.Text = "";
            txtResult.Visibility = Visibility.Hidden;
        }
        private void txtMinValue_GotFocus(object sender, RoutedEventArgs e)
        {
            txtMinValue.SelectAll();
        }
        private void txtMaxValue_GotFocus(object sender, RoutedEventArgs e)
        {
            txtMaxValue.SelectAll();
        }
        private void copyResult_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtResult.Text);
        }
    }
}
