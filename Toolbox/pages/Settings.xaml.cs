using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Toolbox.Config;

namespace Toolbox.pages
{
    public partial class Settings : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> DefaultPageSettingData { get; set; }
        public ObservableCollection<string> ThemeSettingData { get; set; }
        public int SelectedDefaultPageIndex { get; set; }
        public int SelectedThemeIndex { get; set; }

        // Define a dictionary to store the sub tab, main tab, and their corresponding index numbers
        private Dictionary<string, (string subTab, int subTabIndex, string mainTab, int mainTabIndex, int mainIndex)> pageSettings = new Dictionary<string, (string, int, string, int, int)>()
        {
            { "CheatSheets", ("CheatSheets", 0, "FileTools", 0, 0) },
            { "Checksum", ("Checksum", 1, "FileTools", 0, 1) },
            { "Calculator", ("Calculator", 0, "MathTools", 1, 2) },
            { "Conversion", ("Conversion", 1, "MathTools", 1, 3) },
            { "Ping tester", ("Ping tester", 0, "NetworkTools", 2, 4) },
            { "System Info", ("System Info", 0, "System", 3, 5) }
        };

        public Settings()
        {
            InitializeComponent();

            DefaultPageSettingData = new ObservableCollection<string>(pageSettings.Keys);
            ThemeSettingData = new ObservableCollection<string> { "Light", "Dark" };

            SelectedDefaultPageIndex = AppSettings.Default.TabMainIndex;
            SelectedThemeIndex = AppSettings.Default.IsDarkTheme ? 1 : 0;

            SettingsPopup.IsChecked = AppSettings.Default.SettingsPopup;
            CheatSheetsPopup.IsChecked = AppSettings.Default.CheatSheetsPopup;

            DataContext = this; // Set DataContext to this instance for data binding
        }

        private void DefaultPageSettings()
        {
            // Get the selected entry
            string selectedEntry = DefaultPageSetting.SelectedItem.ToString();

            // Retrieve the corresponding main and sub tab values from the dictionary
            var (subTab, subTabIndex, mainTab, mainTabIndex, mainIndex) = pageSettings[selectedEntry];

            // Update the settings with the retrieved values
            AppSettings.Default.DefaultMainTab = mainTabIndex;
            AppSettings.Default.DefaultSubTab = subTabIndex;
            AppSettings.Default.TabMainIndex = mainIndex;
            AppSettings.Default.Save();
        }

        private void PopupSettings()
        {
            AppSettings.Default.SettingsPopup = (bool)SettingsPopup.IsChecked;
            AppSettings.Default.CheatSheetsPopup = (bool)CheatSheetsPopup.IsChecked;
            AppSettings.Default.Save();
        }

        private void ThemeSettings()
        {
            if (ThemeSetting.SelectedIndex == 0)
            {
                AppSettings.Default.IsDarkTheme = false;
                AppSettings.Default.Save();
                App.ChangeTheme(false); // Call ChangeTheme method from App class
            }
            else
            {
                AppSettings.Default.IsDarkTheme = true;
                AppSettings.Default.Save();
                App.ChangeTheme(true); // Call ChangeTheme method from App class
            }
            if (AppSettings.Default.SettingsPopup == true)
            {
                MessageBox.Show("For all style changes to take effect please restart the application", "Settings", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveSettings(object sender, RoutedEventArgs e)
        {
            // Save the settings
            DefaultPageSettings();
            PopupSettings();
            ThemeSettings();

            if (AppSettings.Default.SettingsPopup == true)
            {
                MessageBox.Show("Settings saved successfully", "Settings", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ResetSettings_Click(object sender, RoutedEventArgs e)
        {
            // Reset the settings to their default values
            AppSettings.Default.Reset();
            DefaultPageSetting.SelectedIndex = AppSettings.Default.TabMainIndex;
        }
    }
}
