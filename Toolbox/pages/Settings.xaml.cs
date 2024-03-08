using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Toolbox.Config;
using static Toolbox.MainWindow;

namespace Toolbox.pages
{
    public partial class Settings : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> DefaultPageSettingData { get; set; }
        public ObservableCollection<string> ThemeSettingData { get; set; }
        public int SelectedDefaultPageIndex { get; set; }
        public int SelectedThemeIndex { get; set; }

        public Settings()
        {
            InitializeComponent();

            // Set the data context to this instance for data binding
            ThemeSettingData = new ObservableCollection<string> { "Light", "Dark" };

            SelectedDefaultPageIndex = AppSettings.Default.TabMainIndex;
            SelectedThemeIndex = AppSettings.Default.IsDarkTheme ? 1 : 0;

            SettingsPopup.IsChecked = AppSettings.Default.SettingsPopup;
            CheatSheetsPopup.IsChecked = AppSettings.Default.CheatSheetsPopup;

            DataContext = this; // Set DataContext to this instance for data binding
            Loaded += Settings_Loaded;
        }

        private void Settings_Loaded(object sender, RoutedEventArgs e)
        {
            DefaultPageSettingData = new ObservableCollection<string>(PageSettings.pageSettings.Keys);
            DefaultPageSetting.ItemsSource = DefaultPageSettingData;
            DefaultPageSetting.SelectedIndex = SelectedDefaultPageIndex;
            ThemeSetting.SelectedIndex = SelectedThemeIndex;
        }

        private void DefaultPageSettings()
        {
            // Get the selected entry
            string selectedEntry = DefaultPageSetting.SelectedItem.ToString();

            // Retrieve the corresponding main and sub tab values from the dictionary
            var (subTab, subTabIndex, mainTab, mainTabIndex, mainIndex) = PageSettings.pageSettings[selectedEntry];

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
