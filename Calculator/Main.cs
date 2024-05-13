using System;
using System.Data.SqlTypes;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Calculator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        double num1, num2, result, num;
        int num0;
        string operation;
        bool operation_used = false , equal_used = false, DelClicked = false, operation_check = false, min_problem = false;

        private void btndel_Click(object sender, EventArgs e)
        {
            if (equal_used == false)
            {
                if (DelClicked == true)
                {
                    oper.Text = "";
                    textTotal.Clear();
                    operation_used = false;
                    DelClicked = false;
                    operation_check = false;
                    min_problem = false;
                    num1 = 0;
                    num2 = 0;
                    result = 0;
                }
                if (textTotal.Text.Length > 0)
                    textTotal.Text = textTotal.Text.Remove(textTotal.Text.Length - 1);
                if (textTotal.Text.Length == 0 && operation_used == true)
                    DelClicked = true;
            }
            if (equal_used == true)
            {
                oper.Text = "";
                textTotal.Clear();
                operation_used = false;
                equal_used = false;
                operation_check = false;
                min_problem = false;
                num1 = 0;
                num2 = 0;
                result = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textTotal.Text != "")
            {
                num = double.Parse(textTotal.Text);
                if (num > 31)
                    MessageBox.Show("!أقصى رقم يمكن حسابه هو 31");
                else
                {
                    if (num % 1 == 0)
                    {
                        num0 = int.Parse(textTotal.Text);
                        if (num0 > 0)
                        {
                            for (int i = num0 - 1; i > 0; i--)
                            {
                                num0 *= i;
                            }
                            oper.Text = $"{num}! = {num0}";
                            textTotal.Text = num0 + "";
                            operation_used = true;
                            equal_used = true;
                        }
                        else
                        {
                            MessageBox.Show("!لإيجاد العاملي لعدد يجب أن يكون صحيحاً وأكبر من الصفر");
                        }
                    }
                    else
                        MessageBox.Show("!لإيجاد العاملي لعدد يجب أن يكون صحيحاً");
                }
            }
        }

        private void btnper_Click(object sender, EventArgs e)
        {
            if (textTotal.Text != "")
            {
                if (btnper.Text == "%")
                {
                    operation_used = true;
                    equal_used = true;
                    num = double.Parse(textTotal.Text);
                    result = (num / 100);
                    oper.Text = $"{num}% = {result}";
                    textTotal.Text = result + "";
                }
                if (btnper.Text == "π")
                {
                    operation_used = true;
                    equal_used = true;
                    num = double.Parse(textTotal.Text);
                    result = (num * Math.PI);
                    result = Math.Round(result, 14);
                    oper.Text = $"{num}π = {result}";
                    textTotal.Text = result + "";
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == ".")
            {

                if (!textTotal.Text.Contains("."))
                {
                    if (textTotal.Text == "")
                        textTotal.Text += "0.";
                    else
                        textTotal.Text += ".";
                }
            }
            else
                textTotal.Text += button.Text;
        }

        private void oper_Click(object sender, EventArgs e)
        {
            if (textTotal.Text != "" && textTotal.Text != "-")
            {
                if (num1 != 0 && operation_check == false)
                {
                    Button button = (Button)sender;
                    num2 = double.Parse(textTotal.Text);
                    textTotal.Clear();
                    if (operation == "+")
                    {
                        result = (num1 + num2);
                        result = Math.Round(result, 4);
                    }
                    if (operation == "-")
                    {
                        result = (num1 - num2);
                        result = Math.Round(result, 4);
                    }
                    if (operation == "×")
                    {
                        result = (num1 * num2);
                        result = Math.Round(result, 4);
                    }
                    if (operation == "÷")
                    {
                        result = (num1 / num2);
                        result = Math.Round(result, 4);
                    }
                    operation = button.Text;
                    oper.Text = $"{result} {operation}";
                    textTotal.Clear();
                    min_problem = false;
                    num1 = result;
                }
                else
                {
                    Button button = (Button)sender;
                    operation = button.Text;
                    operation_used = true;
                    num1 = double.Parse(textTotal.Text);
                    oper.Text = $"{num1} {operation}";
                    textTotal.Clear();
                }
            }
            if (textTotal.Text == "")
            {
                Button button = (Button)sender;
                if (button.Text == "-" && textTotal.Text == "")
                {
                    if (operation != "-" || min_problem ==  true)
                        textTotal.Text = "-";
                    if (operation == "-")
                        min_problem = true;
                }
            }
        }

        private void Text_Total_KeyPress(object sender, KeyPressEventArgs e)
        {       
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.') && (e.KeyChar != '-'))
                e.Handled = true;
            if (e.KeyChar == '-')
            {
                if (textTotal.Text == "")
                    e.Handled = true;
            }
        }

        private void btndelall_Click(object sender, EventArgs e)
        {
            oper.Text = "";
            textTotal.Clear();
            operation_used = false;
            num1 = 0;
            num2 = 0;
            result = 0;
        }

        private void btnequ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '=')
            {
                Button button = (Button)sender;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Oemplus)
                btnequ.PerformClick();
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                btndel.PerformClick();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0')
                btn0.PerformClick();
            if (e.KeyChar == '1')
                btn1.PerformClick();
            if (e.KeyChar == '2')
                btn2.PerformClick();
            if (e.KeyChar == '3')
                btn3.PerformClick();
            if (e.KeyChar == '4')
                btn4.PerformClick();
            if (e.KeyChar == '5')
                btn5.PerformClick();
            if (e.KeyChar == '6')
                btn6.PerformClick();
            if (e.KeyChar == '7')
                btn7.PerformClick();
            if (e.KeyChar == '8')
                btn8.PerformClick();
            if (e.KeyChar == '9')
                btn9.PerformClick();
            if (e.KeyChar == '.')
                btndot.PerformClick();
            if (e.KeyChar == '+')
                btnplus.PerformClick();
            if (e.KeyChar == '-')
                btnmin.PerformClick();
            if (e.KeyChar == '*')
                btnmlt.PerformClick();
            if (e.KeyChar == '/')
                btndiv.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (button3.Text == "x²")
                    button3.Text = "xⁿ";
                else
                    button3.Text = "x²";
            }
        }

        private void oper_Click_1(object sender, EventArgs e)
        {
            string inputText = oper.Text;
            string replacedText = inputText.Replace("- -", "+");
            oper.Text = replacedText;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting Options = new Setting();
            Options.Show();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (button2.Text == "√")
                    button2.Text = "∛";
                else
                    button2.Text = "√";
            }
        }
        private void primeNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrimeChecker prime = new PrimeChecker();
            prime.Show();
        }

        private void btnper_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (btnper.Text == "%")
                    btnper.Text = "π";
                else
                    btnper.Text = "%";
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void btnroot_Click(object sender, EventArgs e)
        {
            if (textTotal.Text != "")
            {
                if (button2.Text == "√")
                {
                    num = double.Parse(textTotal.Text);
                    if (num > 0)
                    {
                        operation_used = true;
                        equal_used = true;
                        result = Math.Sqrt(num);
                        result = Math.Round(result, 6);
                        oper.Text = $"√({num})";
                        textTotal.Text = result + "";
                    }
                    else
                    {
                        MessageBox.Show("!لإيجاد الجزر التربيعي لعدد يجب أن يكون أكبر تماماً من الصفر");
                    }
                }
                if (button2.Text == "∛")
                {
                    num = double.Parse(textTotal.Text);
                    if (num > 0)
                    {
                        operation_used = true;
                        equal_used = true;
                        result = Math.Pow(num, 1.0 / 3.0);
                        result = Math.Round(result, 6);
                        oper.Text = $"∛({num})";
                        textTotal.Text = result + "";
                    }
                    else
                    {
                        MessageBox.Show("!لإيجاد الجزر التكعيبي لعدد يجب أن يكون أكبر تماماً من الصفر");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textTotal.Text != "")
            {
                if (button3.Text == "x²")
                {
                    operation_used = true;
                    equal_used = true;
                    num = double.Parse(textTotal.Text);
                    result = (num * num);
                    oper.Text = $"{num} ^ 2 = {result}";
                    textTotal.Text = result + "";
                }
                if (button3.Text == "xⁿ")
                {
                    operation_used = true;
                    equal_used = true;
                    operation = "^";
                    num1 = double.Parse(textTotal.Text);
                    oper.Text = $"{num1} ^";
                    textTotal.Clear();
                }
            }
        }

        private void btnequ_Click(object sender, EventArgs e)
        {
            if (textTotal.Text != "")
            {
                if (operation_used == true)
                {
                    equal_used = true;
                    num2 = double.Parse(textTotal.Text);
                    textTotal.Clear();
                    if (operation == "+")
                    {
                        result = (num1 + num2);
                        result = Math.Round(result, 2);
                    }
                    if (operation == "-")
                    {
                        result = (num1 - num2);
                        result = Math.Round(result, 2);
                    }
                    if (operation == "×")
                    {
                        result = (num1 * num2);
                        result = Math.Round(result, 2);
                    }
                    if (operation == "÷")
                    {
                        result = (num1 / num2);
                        result = Math.Round(result, 2);
                    }
                    if (operation == "^")
                    {
                        result = Math.Pow(num1, num2);
                    }
                    operation_check = true;
                    min_problem = false;
                    oper.Text = $"{num1} {operation} {num2} = {result}";
                    textTotal.Text = result + "";
                }
            }
        }
    }
}