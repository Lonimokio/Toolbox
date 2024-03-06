using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Mages.Core;

namespace Toolbox.pages
{
    public partial class Calculator : UserControl
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void ToggleKeypadButton_Click(object sender, RoutedEventArgs e)
        {
            Keypad.Visibility = Keypad.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            ToggleKeypadButton.Content = Keypad.Visibility == Visibility.Visible ? "▼" : "▲";
            var keypadRows = new[] { KeypadRow1, KeypadRow2, KeypadRow3, KeypadRow4 };
            foreach (var row in keypadRows)
            {
                row.Height = Keypad.Visibility == Visibility.Visible ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            }
            InputRow.Height = Keypad.Visibility == Visibility.Visible ? new GridLength(3, GridUnitType.Star) : new GridLength(5, GridUnitType.Star);
        }


        private void Input_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Get the current line
                int lineStart = Input.Text.LastIndexOf('\n', Input.CaretIndex - 2) + 1;
                int lineEnd = Input.Text.IndexOf('\n', lineStart);
                if (lineEnd < 0) lineEnd = Input.Text.Length;
                string lineText = Input.Text.Substring(lineStart, lineEnd - lineStart);

                // Calculate the result for the current line
                string result = Calculate(lineText.Trim());

                // Append the result to the current line
                if (Input.Text.EndsWith("\n"))
                {
                    Input.Text = Input.Text.Remove(lineEnd, 1);
                }
                Input.Text = Input.Text.Insert(lineEnd - 1, " = " + result + "\n");

                // Move the caret to the next line
                Input.CaretIndex = lineEnd + result.Length + 3;
                e.Handled = true;
            }
        }

private string Calculate(string input)
    {
        try
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            // Replace the ÷ and × operators with / and *
            input = input.Replace("÷", "/");
            input = input.Replace("×", "*");
            input = input.Replace(",", ".");
            input = input.Replace(" ", "");

            // Replace the sqrt operator with a working one
            input = HandleSqrtOperation(input);

            // Replace the pi operator with a working one
            input = input.Replace("π", "pi");

            // Replace the % operator with /100
            input = input.Replace("%", "/100");

            // Use Mages to compute the result
            var engine = new Engine();

            if (engine == null)
            {
                return "Error: Engine instance is null.";
            }

            // Check for division by zero
            if (ContainsDivisionByZero(input))
            {
                return "Error: Division by zero.";
            }

            var result = engine.Interpret(input);

            if (result == null)
            {
                return "Error: Interpret method returned null.";
            }

            return result.ToString();
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

        public string HandleSqrtOperation(string input)
        {
            var regex = new Regex(@"√([^)]*)");
            while (regex.IsMatch(input))
            {
                var match = regex.Match(input);
                var num = double.Parse(match.Groups[1].Value);
                if (num < 0)
                {
                    throw new InvalidOperationException("Square root of a negative number is undefined.");
                }
                var result = "sqrt(" + num + ")";
                input = regex.Replace(input, result, 1);
            }
            return input;
        }


        private bool ContainsDivisionByZero(string input)
    {
        // Check if input contains division by zero
        return input.Contains("/0");
    }


    private void KeypadButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            // Insert the button content at the current caret position
            string updatedText = Input.Text.Insert(Input.CaretIndex, button.Content.ToString());
            int updatedCaretIndex = Input.CaretIndex + button.Content.ToString().Length;

            // Update the Text and CaretIndex properties using the Dispatcher
            Dispatcher.BeginInvoke((Action)(() =>
            {
                Input.Text = updatedText;
                Input.CaretIndex = updatedCaretIndex;
            }), System.Windows.Threading.DispatcherPriority.ContextIdle);
        }


        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Input.Text = "";
        }

        private void TriggerEntry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Input.Text))
                {
                    // Show a message or handle the empty input case accordingly
                    MessageBox.Show("Please enter a valid expression before triggering the calculation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Ensure there's a space at the end of the text
                if (!Input.Text.EndsWith(" "))
                {
                    Input.Text += " ";
                }

                // Set the CaretIndex to the end of the text
                Input.CaretIndex = Input.Text.Length;

                // Create a new KeyEventArgs with the Enter key
                KeyEventArgs enterKeyArgs = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Enter)
                {
                    RoutedEvent = Keyboard.KeyUpEvent
                };

                // Raise the KeyUp event
                Input_KeyUp(sender, enterKeyArgs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



    }
}
