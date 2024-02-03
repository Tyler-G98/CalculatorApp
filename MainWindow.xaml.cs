using System;
using System.Collections.Generic;
using System.Data;
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
        private static string Operator = "";
        private static string DefaultText = "00000000";
        private static bool IsDefault = true;
        private static bool IsOperatorUsed = false;

        private void click_Integer_Input(object sender, RoutedEventArgs e)
        {
            if (IsDefault)
            {
                IsDefault = false;
                txtScreen.Opacity = 1;
                txtScreen.Text = "";
                IntegerInput(sender as Button);
            }
            else
            {
                IntegerInput(sender as Button);
            }
        }

        private void IntegerInput(Button button)
        {
            if (txtScreen.Text.Length < 8 && button.Content.ToString() != "00")
            {
                EquationText = button.Content.ToString();
                txtScreen.Text += EquationText;
            }
            else if (txtScreen.Text.Length < 7 && button.Content.ToString() == "00")
            {
                EquationText = button.Content.ToString();
                txtScreen.Text += EquationText;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtScreen.Opacity = 0.5;
            IsDefault = true;
            txtScreen.Text = DefaultText;
            IsOperatorUsed = false;
        }

        private void click_Operator(object sender, RoutedEventArgs e)
        {
            if (IsOperatorUsed && (sender as Button).Name != "btnEquals")
            {
                CalculateResult();
                Operator = (sender as Button).Content.ToString();
                txtScreen.Text = txtScreen.Text + Operator;
            }
            else if ((sender as Button).Name == "btnEquals")
            {
                CalculateResult();
                Operator = (sender as Button).Content.ToString();
                txtScreen.Text = txtScreen.Text;
            }
            else
            {
                IsOperatorUsed = true;
                Operator = (sender as Button).Content.ToString();
                txtScreen.Text += Operator;
            }
        }

        private void CalculateResult()
        {
            DataTable dataTable = new DataTable();
            double answer = Convert.ToDouble(dataTable.Compute(txtScreen.Text, ""));
            txtScreen.Text = answer.ToString();
        }

        private void btnSquare_Click(object sender, RoutedEventArgs e)
        {
            CalculateResult();
            double answer = Math.Pow(Convert.ToDouble(txtScreen.Text), 2);
            Operator = (sender as Button).Content.ToString();
            txtScreen.Text = answer.ToString();
        }
    }
}
