using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string tempValue1 = "";
        string tempValue2 = "";
        string result = "";
        string operationType = "";



        public MainWindow()
        {
            InitializeComponent();
        }

        private void onClickNumberButton(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (result != "")
            {
                return;
            }
            if (operationType == "")
            {
                tempValue1 += button.Content.ToString();
                TextBox.Text = tempValue1;
            }
            else
            {
                tempValue2 += button.Content.ToString();
                TextBox.Text = tempValue2;
            }

        }

        private void onClear(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "";
            tempValue1 = "";
            tempValue2 = "";
            result = "";    
            operationType = "";
        }

        private string calculate()
        {
            var val1 = 0;
            if (result == "")
            {
                val1 = int.Parse(tempValue1);
            }
            else
            {
                val1 = int.Parse(result);
            }
            var val2 = int.Parse(tempValue2);

            switch (operationType)
            {
                case "+":
                    result = (val1 + val2).ToString();
                    break;
                case "-":
                    result = (val1 - val2).ToString();
                    break;
                case "*":
                    result = (val1 * val2).ToString();
                    break;
                default:
                    break;
            }

            return result;
        }

        private void onResult(object sender, RoutedEventArgs e)
        {
            if (tempValue1 == "" || tempValue2 == "" || operationType == "")
            {
                return;
            }
            result = calculate();
            TextBox.Text = result;

        }

        private void setOperation(object sender, RoutedEventArgs e)
        {
            if (operationType == "" && tempValue1 != "")
            {
                TextBox.Text = "";
                var button = sender as Button;
                operationType = button.Content.ToString();
                TextBox.Text = operationType;
            }
        }
    }
}