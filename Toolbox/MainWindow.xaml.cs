using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Toolbox.Config;
using Toolbox.pages;

namespace Toolbox
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Tab> MainNavBarTabs { get; } = new ObservableCollection<Tab>();
        public ObservableCollection<Tab> SubNavBarTabs { get; } = new ObservableCollection<Tab>();
        public ObservableCollection<Tab> ExtraNavBarTabs { get; } = new ObservableCollection<Tab>();
        public ObservableCollection<Tab> SelectedContent { get; } = new ObservableCollection<Tab>();

        private readonly string pagesDirectory;

        public class Tab
{
    private string name;

    public string Name
    {
        get => name;
        set
        {
            name = value.Replace("_", " ");
        }
    }

    public UserControl Content { get; set; }
}


        public MainWindow()
        {
            pagesDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            int index = pagesDirectory.LastIndexOf("Toolbox");
            if (index != -1) // Check if "Toolbox" was found
            {
                pagesDirectory = pagesDirectory.Substring(0, index) + "Toolbox\\pages";
            }
            else
            {
                MessageBox.Show("Error: Could not find the 'Toolbox' directory");
                Environment.Exit(1);
            }

            InitializeComponent();

            LoadMainNavBarTabs();
            LoadExtraNavBarTabs();
            GeneratePageSettings();

            DataContext = this;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the default tab
            MainNavBar.SelectedIndex = AppSettings.Default.DefaultMainTab;
            SubNavBar.SelectedIndex = AppSettings.Default.DefaultSubTab;
        }

        private void LoadMainNavBarTabs()
        {
            MainNavBarTabs.Clear();

            if (Directory.Exists(pagesDirectory))
            {
                var directories = Directory.GetDirectories(pagesDirectory);
                foreach (var directory in directories)
                {
                    var tabName = Path.GetFileName(directory);
                    MainNavBarTabs.Add(new Tab() { Name = tabName });
                }
            }
        }

        private void LoadSubNavBarTabs(string mainTabName)
        {
            SubNavBarTabs.Clear();

            var mainTabDirectory = Path.Combine(pagesDirectory, mainTabName);
            if (Directory.Exists(mainTabDirectory))
            {
                var files = Directory.GetFiles(mainTabDirectory, "*.xaml");
                foreach (var file in files)
                {
                    var controlName = Path.GetFileNameWithoutExtension(file);
                    try
                    {
                        var controlType = Type.GetType($"Toolbox.pages.{controlName}");
                        if (controlType != null)
                        {
                            var controlInstance = Activator.CreateInstance(controlType) as UserControl;
                            SubNavBarTabs.Add(new Tab() { Name = controlName, Content = controlInstance });
                        }
                        else
                        {
                            MessageBox.Show($"Error loading UserControl for '{controlName}': Type not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception and continue to the next file
                        Console.WriteLine($"Error loading UserControl for '{controlName}': {ex.Message}");
                    }
                }
            }
        }


        private void LoadExtraNavBarTabs()
        {
            ExtraNavBarTabs.Add(new Tab() { Name = "About", Content = new About() });
            ExtraNavBarTabs.Add(new Tab() { Name = "Settings", Content = new Settings() });
        }

        private void MainNavBarTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is TabControl mainNavBarTabs && mainNavBarTabs.SelectedItem is Tab selectedTab)
            {
                LoadSubNavBarTabs(selectedTab.Name);
            }
        }

        private void NavBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is TabControl senderTabControl && senderTabControl.SelectedItem is Tab selectedTab)
            {
                SelectedContent.Clear();
                if (senderTabControl.Name == "SubNavBar")
                {
                    ExtraNavBar.SelectedIndex = -1;
                }
                else if (senderTabControl.Name == "ExtraNavBar")
                {
                    SubNavBar.SelectedIndex = -1;
                }
                MainContent.Content = selectedTab.Content;
            }
        }

        public static class PageSettings
        {
            public static Dictionary<string, (string subTab, int subTabIndex, string mainTab, int mainTabIndex, int mainIndex)> pageSettings = new Dictionary<string, (string, int, string, int, int)>();
        }

        private void GeneratePageSettings()
        {
            PageSettings.pageSettings.Clear(); // Clear existing settings
            int mainIndex = 0;
            int mainTabIndex = 0;
            foreach (var mainTab in MainNavBarTabs)
            {
                LoadSubNavBarTabs(mainTab.Name);

                int subTabIndex = 0;
                foreach (var subTab in SubNavBarTabs)
                {
                    // Associate sub tab with the current main tab and generate settings
                    PageSettings.pageSettings[subTab.Name] = (subTab.Name, subTabIndex, mainTab.Name, mainTabIndex, mainIndex);
                    subTabIndex++;
                    mainIndex++;
                }

                mainTabIndex++;
            }
        }


    }

}
