using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Toolbox.pages
{
    public partial class Conversion_Tools : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Please select a category.");
                    return;
                }

                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                PopulateUnits();
            }
        }


        private string _selectedInputUnit;
        public string SelectedInputUnit
        {
            get { return _selectedInputUnit; }
            set
            {
                _selectedInputUnit = value;
                OnPropertyChanged(nameof(SelectedInputUnit));
                ConvertInput();
            }
        }

        private string _selectedOutputUnit;
        public string SelectedOutputUnit
        {
            get { return _selectedOutputUnit; }
            set
            {
                _selectedOutputUnit = value;
                OnPropertyChanged(nameof(SelectedOutputUnit));
                ConvertInput();
            }
        }

        private string _inputValue;
        public string InputValue
        {
            get { return _inputValue; }
            set
            {
                _inputValue = value;
                OnPropertyChanged(nameof(InputValue));
                ConvertInput();
            }
        }

        private string _outputValue;
        public string OutputValue
        {
            get { return _outputValue; }
            set
            {
                _outputValue = value;
                OnPropertyChanged(nameof(OutputValue));
            }
        }

        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<string> InputUnits { get; set; }
        public ObservableCollection<string> OutputUnits { get; set; }

        public ICommand ClearCommand { get; set; }

        public Conversion_Tools()
        {
            InitializeComponent();
            DataContext = this;
            Initialize();
        }

        private void Initialize()
        {
            Categories = new ObservableCollection<string>
            {
                "Length",
                "Mass",
                "Volume",
                "Temperature",
                "Time"
            };
            InputUnits = new ObservableCollection<string>();
            OutputUnits = new ObservableCollection<string>();
            ClearCommand = new RelayCommand(ExecuteClearCommand, CanExecuteClearCommand);
            PopulateUnits();
        }

        private void PopulateUnits()
        {
            InputUnits.Clear();
            OutputUnits.Clear();

            switch (SelectedCategory)
            {
                case "Length":
                    foreach (var unit in new[] { "Inches", "Feet", "Meters", "Centimeters", "Millimeters" })
                    {
                        InputUnits.Add(unit);
                        OutputUnits.Add(unit);
                    }
                    break;
                case "Mass":
                    foreach (var unit in new[] { "Ounces", "Pounds", "Kilograms", "Grams", "Milligrams" })
                    {
                        InputUnits.Add(unit);
                        OutputUnits.Add(unit);
                    }
                    break;
                case "Volume":
                    foreach (var unit in new[] { "Gallons", "Liters", "Quarts", "Pints", "Cups" })
                    {
                        InputUnits.Add(unit);
                        OutputUnits.Add(unit);
                    }
                    break;
                case "Temperature":
                    foreach (var unit in new[] { "Celsius", "Fahrenheit", "Kelvin" })
                    {
                        InputUnits.Add(unit);
                        OutputUnits.Add(unit);
                    }
                    break;
                case "Time":
                    foreach (var unit in new[] { "Seconds", "Minutes", "Hours", "Days", "Weeks" })
                    {
                        InputUnits.Add(unit);
                        OutputUnits.Add(unit);
                    }
                    break;
            }
        }

        private bool CanExecuteClearCommand(object parameter)
        {
            return true;
        }

        private void ExecuteClearCommand(object parameter)
        {
            InputValue = "";
            OutputValue = "";
        }

        private static Dictionary<string, Dictionary<string, Func<double, double>>> conversionTable = new Dictionary<string, Dictionary<string, Func<double, double>>>
        {
            ["Length"] = new Dictionary<string, Func<double, double>>
            {
                ["InchesToFeet"] = inches => inches / 12.0,
                ["FeetToInches"] = feet => feet * 12.0,
                ["MetersToFeet"] = meters => meters * 3.28084,
                ["FeetToMeters"] = feet => feet * 0.3048,
                ["CentimetersToInches"] = cm => cm * 0.393701,
                ["InchesToCentimeters"] = inches => inches * 2.54,
                ["MillimetersToInches"] = mm => mm * 0.0393701,
                ["InchesToMillimeters"] = inches => inches * 25.4,
                ["KilometersToMiles"] = km => km * 0.621371,
                ["MilesToKilometers"] = miles => miles * 1.60934,
                ["YardsToMeters"] = yd => yd * 0.9144,
                ["MetersToYards"] = m => m * 1.09361,
                ["MilesToFeet"] = miles => miles * 5280,
                ["FeetToMiles"] = feet => feet / 5280,
                ["NauticalMilesToMeters"] = nm => nm * 1852,
                ["MetersToNauticalMiles"] = m => m / 1852,
                ["MetersToKilometers"] = m => m / 1000,
                ["KilometersToMeters"] = km => km * 1000,
                ["MetersToMiles"] = m => m * 0.000621371,
                ["MilesToMeters"] = miles => miles / 0.000621371,
                ["InchesToMiles"] = inches => inches / 63360,
                ["MilesToInches"] = miles => miles * 63360,
                ["YardsToMiles"] = yd => yd / 1760,
                ["MilesToYards"] = miles => miles * 1760,
                ["YardsToFeet"] = yd => yd * 3,
                ["FeetToYards"] = feet => feet / 3,
                ["YardsToInches"] = yd => yd * 36,
                ["InchesToYards"] = inches => inches / 36,
                ["YardsToCentimeters"] = yd => yd * 91.44,
                ["CentimetersToYards"] = cm => cm / 91.44,
                ["InchesToMeters"] = inches => inches * 0.0254,
                ["MetersToInches"] = m => m / 0.0254,
                ["FeetToKilometers"] = feet => feet / 3280.84,
                ["KilometersToFeet"] = km => km * 3280.84,
                ["MilesToCentimeters"] = miles => miles * 160934,
                ["CentimetersToMiles"] = cm => cm / 160934,
                ["MilesToMillimeters"] = miles => miles * 1609340,
                ["MillimetersToMiles"] = mm => mm / 1609340,
                ["MilesToNauticalMiles"] = miles => miles / 1.15078,
                ["NauticalMilesToMiles"] = nm => nm * 1.15078,
                ["FeetToCentimeters"] = feet => feet * 30.48,
                ["CentimetersToFeet"] = cm => cm / 30.48,
                ["FeetToMillimeters"] = feet => feet * 304.8,
                ["MillimetersToFeet"] = mm => mm / 304.8,
                ["InchesToNauticalMiles"] = inches => inches / 72913.4,
                ["NauticalMilesToInches"] = nm => nm * 72913.4,
                ["KilometersToNauticalMiles"] = km => km / 1.852,
                ["NauticalMilesToKilometers"] = nm => nm * 1.852,
                ["MetersToMillimeters"] = m => m * 1000,
                ["MillimetersToMeters"] = mm => mm / 1000,
                ["MetersToCentimeters"] = m => m * 100,
                ["CentimetersToMeters"] = cm => cm / 100,
                ["CentimetersToMillimeters"] = cm => cm * 10,
                ["MillimetersToCentimeters"] = mm => mm / 10
            },
            ["Mass"] = new Dictionary<string, Func<double, double>>
            {
                ["KilogramsToPounds"] = kg => kg * 2.20462,
                ["PoundsToKilograms"] = lbs => lbs * 0.453592,
                ["GramsToOunces"] = g => g * 0.035274,
                ["OuncesToGrams"] = oz => oz * 28.3495,
                ["MilligramsToOunces"] = mg => mg * 0.000035274,
                ["OuncesToMilligrams"] = oz => oz * 28349.5,
                ["KilogramsToGrams"] = kg => kg * 1000,
                ["GramsToKilograms"] = g => g / 1000,
                ["PoundsToOunces"] = lbs => lbs * 16,
                ["OuncesToPounds"] = oz => oz / 16,
                ["KilogramsToMilligrams"] = kg => kg * 1000000,
                ["MilligramsToKilograms"] = mg => mg / 1000000,
                ["PoundsToMilligrams"] = lbs => lbs * 453592,
                ["MilligramsToPounds"] = mg => mg / 453592,
                ["KilogramsToOunces"] = kg => kg * 35.274,
                ["OuncesToKilograms"] = oz => oz / 35.274,
                ["GramsToMilligrams"] = g => g * 1000,
                ["MilligramsToGrams"] = mg => mg / 1000,
                ["PoundsToGrams"] = lbs => lbs * 453.592,
                ["GramsToPounds"] = g => g / 453.592,
            },
            ["Volume"] = new Dictionary<string, Func<double, double>>
            {
                ["LitersToGallons"] = l => l * 0.264172,
                ["GallonsToLiters"] = gal => gal * 3.78541,
                ["LitersToCubicFeet"] = l => l * 0.0353147,
                ["CubicFeetToLiters"] = cf => cf * 28.3168,
                ["LitersToQuarts"] = l => l * 1.05669,
                ["QuartsToLiters"] = q => q * 0.946353,
                ["LitersToPints"] = l => l * 2.11338,
                ["PintsToLiters"] = pt => pt * 0.473176,
                ["LitersToCups"] = l => l * 4.22675,
                ["CupsToLiters"] = c => c * 0.236588,
                ["GallonsToCubicFeet"] = gal => gal * 0.133681,
                ["CubicFeetToGallons"] = cf => cf * 7.48052,
                ["GallonsToQuarts"] = gal => gal * 4,
                ["QuartsToGallons"] = q => q * 0.25,
                ["GallonsToPints"] = gal => gal * 8,
                ["PintsToGallons"] = pt => pt * 0.125,
                ["GallonsToCups"] = gal => gal * 16,
                ["CupsToGallons"] = c => c * 0.0625,
                ["CubicFeetToQuarts"] = cf => cf * 29.9221,
                ["QuartsToCubicFeet"] = q => q * 0.0334201,
                ["CubicFeetToPints"] = cf => cf * 59.8442,
                ["PintsToCubicFeet"] = pt => pt * 0.0167101,
                ["CubicFeetToCups"] = cf => cf * 119.688,
                ["CupsToCubicFeet"] = c => c * 0.00835503,
                ["QuartsToPints"] = q => q * 2,
                ["PintsToQuarts"] = pt => pt * 0.5,
                ["QuartsToCups"] = q => q * 4,
                ["CupsToQuarts"] = c => c * 0.25,
                ["PintsToCups"] = pt => pt * 2,
                ["CupsToPints"] = c => c * 0.5
            },
            ["Temperature"] = new Dictionary<string, Func<double, double>>
            {
                ["CelsiusToFahrenheit"] = c => c * 9.0 / 5.0 + 32,
                ["FahrenheitToCelsius"] = f => (f - 32) * 5.0 / 9.0,
                ["CelsiusToKelvin"] = c => c + 273.15,
                ["KelvinToCelsius"] = k => k - 273.15,
                ["FahrenheitToKelvin"] = f => (f - 32) * 5.0 / 9.0 + 273.15,
                ["KelvinToFahrenheit"] = k => (k - 273.15) * 9.0 / 5.0 + 32,
            },
            ["Time"] = new Dictionary<string, Func<double, double>>
            {
                ["SecondsToMinutes"] = s => s / 60.0,
                ["MinutesToSeconds"] = min => min * 60.0,
                ["HoursToMinutes"] = h => h * 60.0,
                ["MinutesToHours"] = min => min / 60.0,
                ["HoursToSeconds"] = h => h * 3600.0,
                ["SecondsToHours"] = s => s / 3600.0,
                ["DaysToHours"] = d => d * 24.0,
                ["HoursToDays"] = h => h / 24.0,
                ["WeeksToDays"] = w => w * 7.0,
                ["DaysToWeeks"] = d => d / 7.0,
                ["WeeksToHours"] = w => w * 168.0,
                ["HoursToWeeks"] = h => h / 168.0,
                ["WeeksToMinutes"] = w => w * 10080.0,
                ["MinutesToWeeks"] = min => min / 10080.0,
                ["WeeksToSeconds"] = w => w * 604800.0,
                ["SecondsToWeeks"] = s => s / 604800.0,
                ["DaysToMinutes"] = d => d * 1440.0,
                ["MinutesToDays"] = min => min / 1440.0,
                ["DaysToSeconds"] = d => d * 86400.0,
                ["SecondsToDays"] = s => s / 86400.0,
                ["HoursToMinutes"] = h => h * 60.0,
                ["MinutesToHours"] = min => min / 60.0,
                ["HoursToSeconds"] = h => h * 3600.0,
                ["SecondsToHours"] = s => s / 3600.0,
            }
        };


        private void ConvertInput()
        {
            if (string.IsNullOrEmpty(InputValue))
            {
                OutputValue = ""; // If input value is empty, clear the output value
                return;
            }

            double inputValue;
            if (!double.TryParse(InputValue, out inputValue))
            {
                // If input value cannot be parsed to a double, clear the output value
                OutputValue = "";
                return;
            }

            Func<double, double> conversionFunction;
            if (!conversionTable.ContainsKey(SelectedCategory) || !conversionTable[SelectedCategory].TryGetValue($"{SelectedInputUnit}To{SelectedOutputUnit}", out conversionFunction))
            {
                // If the conversion function is not found, clear the output value
                OutputValue = "Conversion not supported";
                return;
            }

            // Perform conversion
            double outputValue = conversionFunction(inputValue);

            OutputValue = outputValue.ToString();
        }




        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                InputValue = textBox.Text; // Update the input value property

                // Trigger the conversion logic
                ConvertInput();
            }
        }


        private void OutputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // You can implement the conversion logic here for cases where the output text changes
            // For this example, let's leave it empty
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
