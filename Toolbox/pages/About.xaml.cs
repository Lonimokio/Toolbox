using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Toolbox.pages
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void NuGet_Click(object sender, RoutedEventArgs e)
        {
            // Display used NuGet packages
            string message = "Used NuGet packages:\n\n" +
                             "1. Mages\n" +
                             "2. LiveCharts.Wpf\n" +
                             "3. Markdown\n";

            MessageBox.Show(message, "NuGet Packages",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

    }
}
