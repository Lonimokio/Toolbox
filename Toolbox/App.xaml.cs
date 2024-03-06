using System;
using System.Windows;
using Toolbox.Config;

namespace Toolbox
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Load the appropriate theme based on the IsDarkTheme setting
            if (AppSettings.Default.IsDarkTheme)
            {
                // Load DarkTheme.xaml
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("styling/DarkTheme.xaml", UriKind.Relative)
                });
            }
            else
            {
                // Load LightTheme.xaml
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("styling/LightTheme.xaml", UriKind.Relative)
                });
            }
        }

        public static void ChangeTheme(bool isDarkTheme)
        {
            // Clear existing resources
            Application.Current.Resources.MergedDictionaries.Clear();

            // Load the appropriate resource dictionary based on the theme
            if (isDarkTheme)
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("styling/DarkTheme.xaml", UriKind.Relative)
                });
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("styling/LightTheme.xaml", UriKind.Relative)
                });
            }
        }
    }
}