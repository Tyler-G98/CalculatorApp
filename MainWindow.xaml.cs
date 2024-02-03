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
                IntegerInput(sender);
            }
            else
            {
                IntegerInput(sender);
            }
        }

        private void IntegerInput(object sender)
        {
            if(txtScreen.Text.Length < 8 && (sender as Button).Content.ToString() != "00")
            {
                EquationText = (sender as Button).Content.ToString();
                txtScreen.Text += EquationText;
            }
            else if(txtScreen.Text.Length < 7 && (sender as Button).Content.ToString() == "00")
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
            IsOperatorUsed = false;
        }

        private void click_Operator(object sender, RoutedEventArgs e)
        {
            if(IsOperatorUsed && (sender as Button).Name != "btnEquals")
            {
                DataTable dataTable = new DataTable();
                double answer = Convert.ToDouble(dataTable.Compute(txtScreen.Text, ""));
                Operator = (sender as Button).Content.ToString();
                txtScreen.Text = answer.ToString() + Operator;
            }
            else if((sender as Button).Name == "btnEquals") 
            {
                DataTable dataTable = new DataTable();
                double answer = Convert.ToDouble(dataTable.Compute(txtScreen.Text, ""));
                Operator = (sender as Button).Content.ToString();
                txtScreen.Text = answer.ToString();
            }
            else
            {
                IsOperatorUsed = true;
                Operator = (sender as Button).Content.ToString();
                txtScreen.Text += Operator;
            }
        }
    }
}
