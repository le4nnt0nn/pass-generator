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

namespace PassGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
        }

        private string generatePass(int lon, string charactersGroup)
        {
            StringBuilder passw = new StringBuilder();
            Random r = new Random();

            for (int i = 0; i < lon; i++)
            {
                int idx = r.Next(charactersGroup.Length);
                passw.Append(charactersGroup[idx]);
            }
            return passw.ToString();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtPass.Text))
            {
                Clipboard
            }
        }
    }
}
