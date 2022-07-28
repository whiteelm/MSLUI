using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MSLUI
{
    public partial class Form1 : Form
    {
        [DllImport("MSL.dll", CharSet = CharSet.Ansi, EntryPoint = "_msl@60",
            CallingConvention = CallingConvention.StdCall)]
        private static extern void Msl(int n, double t, double h, double e, 
            ref double aw, ref double s, ref double dC, ref double dL, 
            ref double um, ref double em, ref double z0);
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs er)
        {
            label14.Text = null;
            label15.Text = null;
            ModalLabel.Text = null;
            emLabel.Text = null;
            var n = Convert.ToInt32(nTextBox.Text);
            var t = Convert.ToDouble(tTextBox.Text);
            var h = Convert.ToDouble(hTextBox.Text);
            var e = Convert.ToDouble(e1TextBox.Text);
            var aw = new double[n];
            var s = new double[n];
            if (n > 0)
            {
                aw[0] = Convert.ToDouble(textBox5.Text);
            }
            if (n > 1)
            {
                aw[1] = Convert.ToDouble(textBox6.Text);
                s[0] = Convert.ToDouble(textBox8.Text);
            }
            if (n > 2)
            {
                aw[2] = Convert.ToDouble(textBox7.Text);
                s[1] = Convert.ToDouble(textBox9.Text);
            }
            if (n > 3)
            {
                aw[3] = Convert.ToDouble(textBox10.Text);
                s[2] = Convert.ToDouble(textBox11.Text);
            }
            if (n > 4)
            {
                aw[4] = Convert.ToDouble(textBox15.Text);
                s[3] = Convert.ToDouble(textBox8.Text);
            }
            if (n > 5)
            {
                aw[5] = Convert.ToDouble(textBox14.Text);
                s[4] = Convert.ToDouble(textBox9.Text);
            }
            if (n > 6)
            {
                aw[6] = Convert.ToDouble(textBox13.Text);
                s[5] = Convert.ToDouble(textBox11.Text);
            }
            if (n > 7)
            {
                aw[7] = Convert.ToDouble(textBox12.Text);
                s[6] = Convert.ToDouble(textBox8.Text);
            }
            if (n > 8)
            {
                aw[8] = Convert.ToDouble(textBox17.Text);
                s[7] = Convert.ToDouble(textBox9.Text);
            }
            if (n > 9)
            {
                aw[9] = Convert.ToDouble(textBox16.Text);
                s[8] = Convert.ToDouble(textBox11.Text);
            }
            var dC = new double[n, n];
            var dL = new double[n, n];
            var um = new double[n, n];
            var z0 = new double[n, n];
            var em = new double[n];

            //try
            //{
                Msl(n, t, h, e,  ref aw[0], ref s[0], ref dC[0, 0],
                    ref dL[0, 0], ref um[0, 0], ref em[0], ref z0[0, 0]);
            //}
            //catch
            //{
            //    MessageBox.Show(@"Ошибка, проверьте ввод данных!");
            //}

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    label14.Text += Math.Round(dL[i, j], 4).ToString("0.0000") + @"  ";
                }
                label14.Text += @"
";
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    label15.Text += Math.Round(dC[i, j], 4).ToString("0.0000") + @"  ";
                }
                label15.Text += @"
";
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    ModalLabel.Text += Math.Round(um[i, j], 4).ToString("0.0000") + @"  ";
                }
                ModalLabel.Text += @"
";
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Z0Label.Text += Math.Round(z0[i, j], 4).ToString("0.0000") + @"  ";
                }
                ModalLabel.Text += @"
";
            }

            for (var i = 0; i < n; i++)
            {
                emLabel.Text += Math.Round(em[i], 4).ToString("0.0000") + @"
";
            }
        }

        /// <summary>
        /// Событие ввода с клавиатуры в текстбокс.
        /// </summary>
        private void ValidateDoubleTextBoxes_KeyPress(object sender,
            KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(),
                @"[\d\b,]");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var n = 0;
            if (nTextBox.Text == string.Empty)
                n = 0;
            if (nTextBox.Text != string.Empty)
                n = Convert.ToInt32(nTextBox.Text);

            if (n > 0)
            {
                textBox5.Enabled = true;
                textBox5.Text = @"1";
            }
            if (n > 1)
            {
                textBox6.Enabled = true;
                textBox8.Enabled = true;
                textBox6.Text = @"1";
                textBox8.Text = @"1";
            }
            if (n > 2)
            {
                textBox7.Enabled = true;
                textBox9.Enabled = true;
                textBox7.Text = @"1";
                textBox9.Text = @"1";
            }
            if (n > 3)
            {
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox10.Text = @"1";
                textBox11.Text = @"1";
            }
            if (n > 4)
            {
                textBox15.Enabled = true;
                textBox20.Enabled = true;
                textBox15.Text = @"1";
                textBox20.Text = @"1";
            }
            if (n > 5)
            {
                textBox14.Enabled = true;
                textBox19.Enabled = true;
                textBox14.Text = @"1";
                textBox19.Text = @"1";
            }
            if (n > 6)
            {
                textBox13.Enabled = true;
                textBox18.Enabled = true;
                textBox13.Text = @"1";
                textBox18.Text = @"1";
            }
            if (n > 7)
            {
                textBox12.Enabled = true;
                textBox23.Enabled = true;
                textBox12.Text = @"1";
                textBox23.Text = @"1";
            }
            if (n > 8)
            {
                textBox17.Enabled = true;
                textBox22.Enabled = true;
                textBox17.Text = @"1";
                textBox22.Text = @"1";
            }
            if (n > 9)
            {
                textBox16.Enabled = true;
                textBox21.Enabled = true;
                textBox16.Text = @"1";
                textBox21.Text = @"1";
            }
            if (n > 10)
            {
                nTextBox.Text = @"10";
            }

            if (n <= 0)
            {
                textBox5.Enabled = false;
            }
            if (n <= 1)
            {
                textBox6.Enabled = false;
                textBox8.Enabled = false;
            }
            if (n <= 2)
            {
                textBox7.Enabled = false;
                textBox9.Enabled = false;
            }
            if (n <= 3)
            {
                textBox10.Enabled = false;
                textBox11.Enabled = false;
            }
            if (n <= 4)
            {
                textBox15.Enabled = false;
                textBox20.Enabled = false;
            }
            if (n <= 5)
            {
                textBox14.Enabled = false;
                textBox19.Enabled = false;
            }
            if (n <= 6)
            {
                textBox13.Enabled = false;
                textBox18.Enabled = false;
            }
            if (n <= 7)
            {
                textBox12.Enabled = false;
                textBox23.Enabled = false;
            }
            if (n <= 8)
            {
                textBox17.Enabled = false;
                textBox22.Enabled = false;
            }
            if (n <= 9)
            {
                textBox16.Enabled = false;
                textBox21.Enabled = false;
            }

        }
    }
}
