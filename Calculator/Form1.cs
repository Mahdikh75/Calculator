using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    // Developer : Mahdi Khayamdar 
    // Email : Mahdi.Khayamdar00@gmail.com
    public partial class FormAppCalculator : Form
    {
        double value1, value2 = 0;TypeCalculator tc;bool Tcn = false;

        public enum TypeCalculator
        {
            jam,menha,zarb,taghsim,nu,pow
        }

        public FormAppCalculator() { InitializeComponent(); }

        private void FormAppCalculator_Load(object sender, EventArgs e) { }

        public void BtnMainNumber_Click(object sender,EventArgs e)
        {
            // object sender to agrs last ==> value , values 0 to 9
            if (value1 != 0 && Tcn == true)
            {
                MsText.Text = "";Tcn = false;
            }
            string TxtSensder = sender.ToString();
            MsText.Text += TxtSensder.Substring(TxtSensder.Length - 1);
        }
        private void BtnCE_Click(object sender, EventArgs e)
        {
            string SrcText = MsText.Text;
            if (SrcText.Length == 0 || SrcText.Length == 1)
            {
                MsText.Clear();
            }
            else
            {
                MsText.Text = SrcText.Substring(0, SrcText.Length - 1);
            }

        }
        private void BtnMainCalc_Click(object sender, EventArgs e)
        {
            string Oprator = sender.ToString().Substring(sender.ToString().Length - 1, 1);
            if (MsText.Text == "" && Oprator == "-")
            {
                MsText.Text = "-";
            }
            else
            {
                switch (Oprator)
                {
                    case "/":
                        tc = TypeCalculator.taghsim;
                        value1 = Convert.ToDouble(MsText.Text);
                        Tcn = true;
                        break;
                    case "*":
                        tc = TypeCalculator.zarb;
                        value1 = Convert.ToDouble(MsText.Text);
                        Tcn = true;
                        break;
                    case "-":
                        tc = TypeCalculator.menha;
                        value1 = Convert.ToDouble(MsText.Text);
                        Tcn = true;
                        break;
                    case "+":
                        tc = TypeCalculator.jam;
                        value1 = Convert.ToDouble(MsText.Text);
                        Tcn = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void BtnNatCalculator_Click(object sender, EventArgs e)
        {
            if (MsText.Text != "")
            {
                value2 = Convert.ToDouble(MsText.Text);
                switch (tc)
                {
                    case TypeCalculator.jam:
                        MsText.Text = (value1 + value2).ToString();
                        ClaerValues();
                        break;
                    case TypeCalculator.menha:
                        MsText.Text = (value1 - value2).ToString();
                        ClaerValues();
                        break;
                    case TypeCalculator.zarb:
                        MsText.Text = (value1 * value2).ToString();
                        ClaerValues();
                        break;
                    case TypeCalculator.taghsim:
                        if (value2 == 0)
                        {
                            MessageBox.Show("عدد بر صفر تقسیم نمیشود");
                            ClaerValues();
                        }
                        else
                        {
                            MsText.Text = (value1 / value2).ToString();
                            ClaerValues();
                        }
                        break;
                    case TypeCalculator.nu:
                        break;
                    case TypeCalculator.pow:
                        MsText.Text = (Math.Pow(value1, value2)).ToString();
                        ClaerValues();
                        break;
                    default:
                        break;
                }
                tc = TypeCalculator.nu;
            }
            else
            {
                ClaerValues(); tc = TypeCalculator.nu;
            }
        }
        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(MsText.Text);
            MsText.Text = Math.Sqrt(x).ToString();
        }
        private void BtnPow_Click(object sender, EventArgs e)
        {
            value1 = double.Parse(MsText.Text);
            tc = TypeCalculator.pow; Tcn = true;
        }
        public void ClaerValues() { value1 = 0; value2 = 0; }
      
        private void BtnClaer_Click(object sender, EventArgs e) { MsText.Text = ""; }

        private void BtnMo_Click(object sender, EventArgs e) { MsText.Text += "."; }
    }
}
