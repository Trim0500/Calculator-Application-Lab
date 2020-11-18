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
using System.Text.RegularExpressions;
using Calc_Lab.Classes;

namespace Calc_Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double lastNumber { get; set; }
        public double result { get; set; }
        public SelectedOperator? SO { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Num_btn_Click(object sender, RoutedEventArgs e)
        {
            Button actualButton = (Button)sender;
            string numSent = actualButton.Content.ToString();

            if (numberDisplay.Text == "0")
                numberDisplay.Text = numSent;
            else
                numberDisplay.Text += actualButton.Content.ToString();
        }

        private void AC_btn_Clear(object sender, RoutedEventArgs e)
        {
            lastNumber = 0;
            result = 0;
            SO = null;
            numberDisplay.Text = "0";
        }

        private void Equ_btn_Calc(object sender, RoutedEventArgs e)
        {
            double currentNumber = double.Parse(numberDisplay.Text);
            result = MathService.calcOperation(lastNumber, currentNumber, SO);

            if(result == double.PositiveInfinity || result == double.NegativeInfinity)
            {
                MessageBox.Show("Undefined");
                return;
            }

            numberDisplay.Text = result.ToString();
            lastNumber = 0;
        }

        private void Neg_btn_Make_Neg(object sender, RoutedEventArgs e)
        {
            string input = numberDisplay.Text;
            List<Char> textArray = numberDisplay.Text.ToList();
            string pattern = @"-[0-9]+";
            string pattern2 = @"-[0-9]+\.[0-9]+";

            if (Regex.IsMatch(input, pattern) || Regex.IsMatch(input, pattern2))
            {
                List<Char> positiveValue;
                positiveValue = textArray.Where(x => !x.Equals('-')).ToList();
                string newValue = new string(positiveValue.ToArray());
                numberDisplay.Text = newValue;
                return;
            }

            string negativeValue;
            negativeValue = "-" + numberDisplay.Text;
            numberDisplay.Text = negativeValue;
        }

        private void Dec_btn_Apply_Dec(object sender, RoutedEventArgs e)
        {
            string input = numberDisplay.Text;
            string pattern = @"[0-9]+\.";
            string pattern2 = @"[0-9]+\.[0-9]+";

            if (Regex.IsMatch(input, pattern) || Regex.IsMatch(input, pattern2))
            {
                return;
            }

            string decimalValue;
            decimalValue = numberDisplay.Text + ".";
            numberDisplay.Text = decimalValue;
        }

        private void Mod_btn_Calc_Mod(object sender, RoutedEventArgs e)
        {
            double percentValue;

            if (lastNumber == 0)
            {
                percentValue = double.Parse(numberDisplay.Text) / 100;
                numberDisplay.Text = percentValue.ToString();
                return;
            }
            else
            {
                percentValue = lastNumber * (double.Parse(numberDisplay.Text) / 100);
                numberDisplay.Text = percentValue.ToString();
            }
            
        }

        private void Oper_btn_Click(object sender, RoutedEventArgs e)
        {
            Button actualButton = (Button)sender;

            switch (actualButton.Name)
            {
                case "Add_btn":
                    SO = SelectedOperator.Add;
                    lastNumber = double.Parse(numberDisplay.Text);
                    numberDisplay.Text = "0";
                    break;
                case "Sub_btn":
                    SO = SelectedOperator.Subtract;
                    lastNumber = double.Parse(numberDisplay.Text);
                    numberDisplay.Text = "0";
                    break;
                case "Mul_btn":
                    SO = SelectedOperator.Multiply;
                    lastNumber = double.Parse(numberDisplay.Text);
                    numberDisplay.Text = "0";
                    break;
                case "Div_btn":
                    SO = SelectedOperator.Divide;
                    lastNumber = double.Parse(numberDisplay.Text);
                    numberDisplay.Text = "0";
                    break;
                default:
                    MessageBox.Show("Not an operator");
                    break;
            }
        }

        public enum SelectedOperator
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }
    }
}
