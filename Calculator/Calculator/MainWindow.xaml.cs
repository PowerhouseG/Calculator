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
        private Boolean dot_present = false;
       
      
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
         
            Button button = (Button)sender;
            if (button == null)
            {
                return;
            }
            if (screen.Text == "0"&&!button.Content.Equals("."))
                screen.Clear();
            if ((string)button.Content == ".")
            {
                if (!screen.Text.EndsWith(".") && !dot_present)
                    if (screen.Text.EndsWith("+") || screen.Text.EndsWith("-") || screen.Text.EndsWith("*") ||
                        screen.Text.EndsWith("/"))
                    {
                        screen.Text += "0" + button.Content;
                    }
                    else
                    {
                        screen.Text += button.Content;
                    }
                    dot_present = true;

            }
            else
            {
                screen.Text += button.Content;

            }

        }
        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == null)
            {
                return;
            }
            if (screen.Text == "0" && button.Content.Equals("-"))
            {
                screen.Clear();
            }
            if (screen.Text.EndsWith("+") || screen.Text.EndsWith("-") || screen.Text.EndsWith("*") ||
                        screen.Text.EndsWith("/"))
            {
                screen.Text = screen.Text.Remove(screen.Text.Length - 1);
            }
            screen.Text +=  button.Content;
            dot_present = false;
        }
 


        private void Clear_Element_Click(object sender, EventArgs e)
        {
            if (screen.Text.Length > 1)
            {
                if (screen.Text.EndsWith("."))
                {
                    dot_present = false;
                }
                screen.Text = screen.Text.Remove(screen.Text.Length - 1);
            }
            else
            {
                screen.Text = "0";
                dot_present = false;

            }
        }

        private void Clear_Click(object sender, EventArgs e)
            {
                screen.Text = "0";
            dot_present = false;
            }

        private void Equals_Click(object sender, EventArgs e)
        {
            try
            {
                var result = new DataTable().Compute(screen.Text, null);
                screen.Text = Convert.ToString(result).Replace(",", ".");
                if (screen.Text.Contains("."))
                {
                    dot_present = true;
                }
            }
            catch (OverflowException)
            {
                screen.Text = "Number Too Big!";
            }
            catch (Exception)
            {
                screen.Text = "Invalid Command!";
            }
           
        }
            

        }
}
