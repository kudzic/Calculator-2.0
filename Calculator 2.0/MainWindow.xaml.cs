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

namespace Calculator_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result, lastnumber;
        SelectorOperator selectorOperator;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            lbresult.Content = "0";
        }


         

        private void btnnegate_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(lbresult.Content.ToString(),out lastnumber))
            {
                lbresult.Content = lastnumber * -1;
            }
        }

        private void btnpercentage_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(lbresult.Content.ToString(),out lastnumber))
            {
                lbresult.Content = lastnumber / 100;
            }
        }

        private void btndot_Click(object sender, RoutedEventArgs e)
        {
            if (!lbresult.Content.ToString().Contains("."))
            {
                lbresult.Content = $"{lbresult.Content}.";
            }
            
        }

        private void Operator_Click(object sender,RoutedEventArgs e)
        {
            if(double.TryParse(lbresult.Content.ToString(),out lastnumber))
            {
                lbresult.Content = "0";
            }

            if (sender == btnadd)
            {
                selectorOperator = SelectorOperator.Addition;

            }
            if (sender == btnsubstract)
            {
                selectorOperator = SelectorOperator.Substraction;
            }
            if (sender == btnmultiply)
            {
                selectorOperator = SelectorOperator.Multiply;
            }
            if (sender == btndivide)
            {
                selectorOperator = SelectorOperator.Divide;
            }
        }


        private void btnequals_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if(double.TryParse(lbresult.Content.ToString(),out newNumber)){

                switch (selectorOperator)
                {
                    case SelectorOperator.Addition:
                      result= SimpleMath.Add(lastnumber , newNumber);
                        break;
                    case SelectorOperator.Substraction:
                        result=SimpleMath.Substract(lastnumber , newNumber);
                        break;
                    case SelectorOperator.Multiply:
                       result= SimpleMath.Multiply(lastnumber, newNumber);
                        break;
                    case SelectorOperator.Divide:
                        result = SimpleMath.Division(lastnumber, newNumber);
                        break;

                }
                lbresult.Content = result;

            }
            
        }

        private void Button_Click(object sender,RoutedEventArgs e)
        {
            int selectedNumber = int.Parse((sender as Button).Content.ToString());

            if (lbresult.Content.ToString() == "0")
            {
                lbresult.Content = selectedNumber.ToString();
            }
            else
            {
                lbresult.Content = $"{lbresult.Content.ToString()}{selectedNumber.ToString()}";
            }
        }

    }

    public enum SelectorOperator{
        Divide,
        Multiply,
        Substraction,
        Addition

    }

    public class SimpleMath
    {
        public static double Add(double a,double b)
        {
            return a + b;
        }
        public static double Substract(double a,double b)
        {
            return a - b;
        }
        public static double Multiply(double a,double b)
        {
            return a*b;
        }
        public static double Division(double a,double b)
        {
            return a / b;
        }

    }
}
