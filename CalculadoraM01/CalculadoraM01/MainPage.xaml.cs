using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculadoraM01
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int status = 1;
        string mathOperator;
        double v1, v2;
        public MainPage()
            {
                InitializeComponent();
                limpar(new object(), new EventArgs());
            }

        private void SelectedNumber(object sender, EventArgs e)
        {
            Button BTN = (Button)sender;
            string SLC = BTN.Text;

            if(this.ResultSet02.Text == "0" || status < 0)
            {
                this.ResultSet02.Text = "";
                if (status < 0)
                    status *= -1;
            }

            this.ResultSet02.Text += SLC;
            double number;
            
            if(double.TryParse(this.ResultSet02.Text, out number))
            {
                this.ResultSet02.Text = number.ToString("N0");
                if (status == 1)
                {
                    v1 = number;
                }
                else
                {
                    v2 = number;
                }
            }
        }

        private void SelectOperator(object sender, EventArgs e)
        {
            status = -2;
            Button BTN = (Button)sender;
            string SLC = BTN.Text;
            mathOperator = SLC;
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if(status == 2)
            {
                double result = 0;
                if(mathOperator == "+")
                {
                    result = v1 + v2;
                }
                if (mathOperator == "-")
                {
                    result = v1 - v2;
                }
                if (mathOperator == "x")
                {
                    result = v1 * v2;
                }
                if (mathOperator == "/")
                {
                    result = v1 / v2;
                }
                this.ResultSet02.Text = result.ToString("N0");
                v1 = result;
                status = -1;
            }
        }

        private void limpar(object sender, EventArgs e)
        {
            v1 = 0;
            v2 = 0;
            status = 1;
            this.ResultSet02.Text = "0";
        }

        
    }
}
