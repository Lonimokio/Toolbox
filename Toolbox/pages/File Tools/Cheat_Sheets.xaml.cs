using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HeyRed.MarkdownSharp;
using Toolbox.Config;

namespace Toolbox.pages
{
    // MarkdownFile class definition
    public class MarkdownFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public partial class Cheat_Sheets : UserControl
    {
        private string markdownFolderPath;
        private ObservableCollection<MarkdownFile> markdownFilesList;

        public Cheat_Sheets()
        {
            InitializeComponent();

            string folderName = "CheatSheets";

            markdownFolderPath = System.AppDomain.CurrentDomain.BaseDirectory;
            markdownFolderPath = markdownFolderPath.Substring(0, markdownFolderPath.IndexOf("Toolbox")) + "Toolbox\\"+folderName;

            // Create the folder if it doesn't exist
            if (!Directory.Exists(markdownFolderPath))
            {
                Directory.CreateDirectory(markdownFolderPath);
            }

            PopulateCheatSheetsNavigation();
        }

        private void ShowMessageBox(params object[] messages)
        {
            if (AppSettings.Default.CheatSheetsPopup)
            {
                string messageText = string.Join(Environment.NewLine, messages);
                MessageBoxResult result = MessageBox.Show(messageText, "Message", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.Cancel)
                {
                    DisablePopups();
                }
            }
        }


        private static void DisablePopups()
        {
            // Toggle the CheatSheetsPopup setting
            AppSettings.Default.CheatSheetsPopup = false;
            AppSettings.Default.Save();
        }



        private void PopulateCheatSheetsNavigation()
        {
            markdownFilesList = new ObservableCollection<MarkdownFile>();
            foreach (var filePath in Directory.GetFiles(markdownFolderPath, "*.md"))
            {
                markdownFilesList.Add(new MarkdownFile { Name = System.IO.Path.GetFileName(filePath), Path = filePath });
            }
            CheatSheetsNav.ItemsSource = markdownFilesList;
        }

        private void LoadMarkdownFile(string filePath)
        {
            // Read the markdown file
            string markdownContent = File.ReadAllText(filePath, Encoding.UTF8);

            // Check if the file is empty
            if (string.IsNullOrWhiteSpace(markdownContent))
            {
                ShowMessageBox("The markdown file is empty: " + filePath);
                return;
            }

            // Transform and display the markdown content
            string htmlContent = "<html><head><meta charset=\"UTF-8\"></head><body>" + new Markdown().Transform(markdownContent) + "</body></html>";
            webBrowser.NavigateToString(htmlContent);
        }

        private void CheatSheetsNav_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFile = (MarkdownFile)CheatSheetsNav.SelectedItem;
            if (selectedFile != null)
            {
                // If the "Edit" button was clicked, show the content in the editTextBox
                if (editTextBox.Visibility == Visibility.Visible)
                {
                    string markdownContent = File.ReadAllText(selectedFile.Path);
                    editTextBox.Text = markdownContent;
                }
                // If the "View" button was clicked, show the content in the webBrowser
                else if (webBrowser.Visibility == Visibility.Visible)
                {
                    LoadMarkdownFile(selectedFile.Path);
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedFile = (MarkdownFile)CheatSheetsNav.SelectedItem;
            if (selectedFile != null)
            {
                // Show the TextBox for editing
                editTextBox.Visibility = Visibility.Visible;
                // Hide the WebBrowser for viewing
                webBrowser.Visibility = Visibility.Collapsed;

                // Highlight the "Edit" button
                EditButton.Background = Brushes.LightGray;
                ViewButton.Background = Brushes.Transparent;

                // Load the content of the Markdown file into the editTextBox
                string markdownContent = File.ReadAllText(selectedFile.Path);
                editTextBox.Text = markdownContent;
            }
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedFile = (MarkdownFile)CheatSheetsNav.SelectedItem;
            if (selectedFile != null)
            {
                // Show the WebBrowser for viewing
                webBrowser.Visibility = Visibility.Visible;
                // Hide the TextBox for editing
                editTextBox.Visibility = Visibility.Collapsed;

                // Highlight the "View" button
                ViewButton.Background = Brushes.LightGray;
                EditButton.Background = Brushes.Transparent;

                LoadMarkdownFile(selectedFile.Path);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedFile = (MarkdownFile)CheatSheetsNav.SelectedItem;
            if (selectedFile != null)
            {
                // Save the content of the editTextBox back to the selected Markdown file
                File.WriteAllText(selectedFile.Path, editTextBox.Text);
                ShowMessageBox("Markdown file saved successfully: " + selectedFile.Path);
                // If the WebBrowser is currently visible (meaning the "View" button was clicked),
                // reload the content to reflect the changes made in the editTextBox
                if (webBrowser.Visibility == Visibility.Visible)
                {
                    LoadMarkdownFile(selectedFile.Path);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedFile = (MarkdownFile)CheatSheetsNav.SelectedItem;
            if (selectedFile != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the markdown file: " + selectedFile.Path + "?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    File.Delete(selectedFile.Path);
                    ShowMessageBox("Markdown file deleted successfully: " + selectedFile.Path, "File Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    PopulateCheatSheetsNavigation();
                }
            }
        }


        private void CreateSheetButton_Click(object sender, RoutedEventArgs e)
        {
            // Prompt the user for the sheet name
            string sheetName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the new sheet:", "Create New Sheet");

            if (!string.IsNullOrEmpty(sheetName))
            {
                // Check for invalid characters in the sheet name
                char[] invalidChars = Path.GetInvalidFileNameChars();
                if (sheetName.IndexOfAny(invalidChars) != -1)
                {
                    ShowMessageBox("The sheet name contains invalid characters. Please use a valid name.", "Invalid Sheet Name", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Check if a file with the same name already exists
                string newMarkdownFilePath = Path.Combine(markdownFolderPath, sheetName + ".md");
                if (File.Exists(newMarkdownFilePath))
                {
                    ShowMessageBox("A file with the same name already exists: " + newMarkdownFilePath, "File Exists", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Create a new markdown file with the given name
                File.WriteAllText(newMarkdownFilePath, "");

                ShowMessageBox("New markdown file created successfully: " + newMarkdownFilePath, "File Created", MessageBoxButton.OK, MessageBoxImage.Information);
                PopulateCheatSheetsNavigation();
            }
            else
            {
                ShowMessageBox("Please provide a valid sheet name.", "Invalid Sheet Name", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
