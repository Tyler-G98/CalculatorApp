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

namespace Calculator
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

        private static string EquationText = "";
        private static string DefaultText = "00000000";
        private static bool IsDefault = true;

        private void click_Equation(object sender, RoutedEventArgs e)
        {
            if (IsDefault)
            {
                IsDefault = false;
                txtScreen.Opacity = 1;
                EquationText = (sender as Button).Content.ToString();
                txtScreen.Text = EquationText;
            }
            else
            {
                EquationText = (sender as Button).Content.ToString();
                txtScreen.Text += EquationText;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtScreen.Opacity = 0.5;
            IsDefault = true;
            txtScreen.Text = DefaultText;
        }
    }
}
