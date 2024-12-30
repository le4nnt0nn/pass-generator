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
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            // base char
            string numbers = "0123456789";
            string mayusLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string minusLetters = "abcdefghijklmnopqrstuvwxyz";
            string specialChars = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/";

            // create characters group
            StringBuilder cgroup = new StringBuilder();
        }
    }
}
