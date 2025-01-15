using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace PassGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // temp stored passwords
        List<PasswordEntry> passwordEntries = new List<PasswordEntry>();

        public MainWindow()
        {
            InitializeComponent();
            sliderLong.ValueChanged += SliderLong_ValueChanged;
        }

        // calculate if slider changed the value
        private void SliderLong_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtLong.Text = ((int)sliderLong.Value).ToString();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            // create characters group
            StringBuilder cgroup = new StringBuilder();

            // add options if check is marked
            cgroup.Append(string.Concat(chkNumbers.IsChecked == true ? CharacterSets.numbers : "", chkMayus.IsChecked == true ? CharacterSets.mayusLetters : "",
            chkMinus.IsChecked == true ? CharacterSets.minusLetters : "", chkSpecials.IsChecked == true ? CharacterSets.specialChars : ""));

            // check if all selection is off
            if (cgroup.Length == 0) { MessageBox.Show("Select 1 option to continue.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); return; }

            // generate password
            int length = (int)sliderLong.Value;
            string password = generatePass(length, cgroup.ToString());
            txtPass.Text = password;

            // evaluate password strenght
            evaluatePasswdStrength(password);
        }
      
        private string generatePass(int lon, string charactersGroup)
        {
            StringBuilder passw = new StringBuilder();
            Random r = new Random();

            // put random chars in builder
            for (int i = 0; i < lon; i++)
            {
                int idx = r.Next(charactersGroup.Length);
                passw.Append(charactersGroup[idx]);
            }
            return passw.ToString();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            // check if txtPass is null to copy to the clipboard
            if(!string.IsNullOrEmpty(txtPass.Text))
            {
                Clipboard.SetText(txtPass.Text);
                MessageBox.Show("Password copied to the clipboard.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            } else { MessageBox.Show("There is not a password generated to copy.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }

        // evaluate passwd strength
        private void evaluatePasswdStrength(string passwd)
        {
            // init conditionals
            bool hasUpper = passwd.Any(char.IsUpper);
            bool hasLower = passwd.Any(char.IsLower);
            bool hasDigit = passwd.Any(char.IsDigit);
            bool hasSpecial = passwd.Any(ch => !char.IsLetterOrDigit(ch));
            int criteriaMet = new[] { hasUpper, hasLower, hasDigit, hasSpecial }.Count(c => c);

            // determinate text & color
            string strengthTxt;
            Brush strengthColor;

            switch (criteriaMet)
            {
                case 4:
                    strengthTxt = "Strong";
                    strengthColor = Brushes.Green;
                    break;
                case 3:
                    strengthTxt = "Moderate";
                    strengthColor = Brushes.Orange;
                    break;
                case 2:
                    strengthTxt = "Weak";
                    strengthColor = Brushes.Red;
                    break;
                default:
                    strengthTxt = "Very Weak";
                    strengthColor = Brushes.DarkRed;
                    break;
            }

            // update visual controls
            pbStrength.Value = criteriaMet;
            txtStrength.Text = strengthTxt;
            txtStrength.Foreground = new SolidColorBrush(((SolidColorBrush)strengthColor).Color);
        }

        private void btnSavePassword_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPasswordName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please fill in both fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // add to list
            var entry = new PasswordEntry
            {
                Name = txtPasswordName.Text,
                Password = txtPassword.Text
            };

            passwordEntries.Add(entry);

            // update list
            lstPasswords.Items.Add(entry);

            // clear input fields
            txtPasswordName.Clear();
            txtPassword.Clear();

            MessageBox.Show("Password saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void lstPasswords_SelectionChanged(object sender, RoutedEvent e)
        {
            if(lstPasswords.SelectedItem is PasswordEntry selectedEntry)
            {
                MessageBox.Show($"Password: {selectedEntry.Password}", "Password Detail", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDeletePassword_Click(object sender, RoutedEvent e)
        {
            if(lstPasswords.SelectedItem is PasswordEntry selectedEntry)
            {
                passwordEntries.Remove(selectedEntry);
                lstPasswords.Items.Remove(selectedEntry);

                MessageBox.Show("Password deleted successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("No password selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void savePasswordsToFile()
        {
            try
            {
                // serialize password list
                var json = JsonSerializer.Serialize(passwordEntries);
                File.WriteAllText("passwords.json", json);
                MessageBox.Show("Passwords saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving passwords: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void loadPasswordsFromFile()
        {
            try
            {
                if (File.Exists("passwords.json"))
                {
                    // read file content
                    var json = File.ReadAllText("passwords.json");
                    passwordEntries = JsonSerializer.Deserialize<List<PasswordEntry>>(json) ?? new List<PasswordEntry>();

                    // update interface
                    lstPasswords.Items.Clear();
                    foreach (var entry in passwordEntries) 
                    {
                        lstPasswords.Items.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading passwords: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
