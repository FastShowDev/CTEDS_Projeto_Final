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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Calculadora.View
{
    /// <summary>
    /// Interaction logic for StandardCalculator.xaml
    /// </summary>
    public partial class StandardCalculator : Window
    {

        public static bool isNumber;
        public static bool isFloat;
        public static bool isOperation;
        public static string calculation;
        public const string DECIMAL_SEPARATOR = ",";
        public string lastButtonPressed;

        public StandardCalculator()
        {
            InitializeComponent();
        }
        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuBorder.Visibility = Visibility.Visible;
            
        }

        private void CloseMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuBorder.Visibility = Visibility.Hidden;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            string objName = ((Button)sender).Name;
            char pressedButtonValue = Convert.ToChar((sender as Button).Content);
            if (lastButtonPressed == "operator")
            {
                int lastDisplayIndex = CalculatorDisplay.Text.Length - 1;
                string display = CalculatorDisplay.Text.Substring(0, lastDisplayIndex);
                display += pressedButtonValue;
                CalculatorDisplay.Text = display.ToString();
            }
            else
            {
                lastButtonPressed = "operator";
                CalculatorDisplay.Text += pressedButtonValue;
            }
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            
            isNumber = true;
            string objName = ((Button)sender).Name;
            string pressedButtonValue = Convert.ToString((sender as Button).Content);
            if (CalculatorDisplay.Text == "0" && pressedButtonValue != DECIMAL_SEPARATOR)
            {
                CalculatorDisplay.Text = "";
            }
            if (objName == "button_float")
            {
                isFloat = true;
            }
            CalculatorDisplay.Text += pressedButtonValue;
            lastButtonPressed = "number";

        }
    }
}
