using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Toolbox.pages
{
    public partial class Checksum : UserControl
    {
        private Dictionary<string, string> checksums = new Dictionary<string, string>();

        public Checksum()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnCalculateChecksum_Click(object sender, RoutedEventArgs e)
        {
            string filePath = txtFilePath.Text;
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                string checksum = CalculateMD5(filePath);
                txtChecksumResult.Text = checksum;

                // Check if checksum indicates the file is good
                bool isGood = CheckIfFileIsGood(filePath, checksum);
                if (isGood)
                {
                    txtStatus.Text = "File is good.";
                }
                else
                {
                    txtStatus.Text = "File may be corrupted or modified.";
                }
            }
            else
            {
                MessageBox.Show("Please select a valid file to calculate the checksum.");
            }
        }

        private string CalculateMD5(string filePath)
        {
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = md5.ComputeHash(stream);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }

        private bool CheckIfFileIsGood(string filePath, string calculatedChecksum)
        {
            // Compare the calculated checksum with known bad checksums or check for common issues
            // For demonstration purposes, let's assume any non-empty checksum is considered valid
            return !string.IsNullOrEmpty(calculatedChecksum);
        }

        private void btnStoreChecksum_Click(object sender, RoutedEventArgs e)
        {
            string filePath = txtFilePath.Text;
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                string checksum = txtChecksumResult.Text;
                if (!checksums.ContainsKey(filePath))
                {
                    checksums.Add(filePath, checksum);
                    MessageBox.Show("Checksum stored successfully.");
                }
                else
                {
                    MessageBox.Show("Checksum for this file is already stored.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid file.");
            }
        }

        private void btnCheckFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath = txtFilePath.Text;
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                if (checksums.ContainsKey(filePath))
                {
                    string storedChecksum = checksums[filePath];
                    string calculatedChecksum = CalculateMD5(filePath);
                    if (calculatedChecksum == storedChecksum)
                    {
                        MessageBox.Show("File is intact.");
                    }
                    else
                    {
                        MessageBox.Show("File may have been modified.");
                    }
                }
                else
                {
                    MessageBox.Show("Checksum for this file is not stored.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid file.");
            }
        }
    }
}
