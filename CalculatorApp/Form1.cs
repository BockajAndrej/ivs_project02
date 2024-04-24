using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace CalculatorApp
{
    /// <summary>
    /// Backend class 
    /// </summary>
    public partial class Calculator : Form
    {
        private Math_lib mathLib = new Math_lib();
        public Calculator()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint); // Attach the handler
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            textBox1.BorderStyle = BorderStyle.FixedSingle;

        }

        private bool isDarkMode = false;
        private Color darkModeStartColor = Color.FromArgb(20, 55, 73);
        private Color darkModeEndColor = Color.FromArgb(37, 49, 61);
        private Color lightModeStartColor = Color.White;
        private Color lightModeEndColor = Color.LightGray; // Or your desired light mode color
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new Rectangle(0, 0, this.Width, this.Height);

            // Apply the appropriate colors based on the current mode
            Brush brush = new LinearGradientBrush(gradient_rectangle,
                                                  isDarkMode ? darkModeStartColor : lightModeStartColor,
                                                  isDarkMode ? darkModeEndColor : lightModeEndColor,
                                                  45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }


        //Buttons
        private string firstNumber_str = "";
        private string secondNumber_str = "";
        private string currentOperator_str = "";
        private bool newNumberMode = true; // Flag to signal if we're starting a new number

        private bool isEnteringExponent = false;
        private string exponent = ""; // Store the exponent digits

        private void customControl1_CheckedChanged(object sender, EventArgs e)
        {
            isDarkMode = customControl1.Checked;
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.ForeColor = isDarkMode ? Color.YellowGreen : Color.Black;
                    button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Transparent;
                }
            }

            if (customControl1.Checked)
            {
                textBox1.BackColor = Color.FromArgb(20, 55, 73);
                textBox1.ForeColor = Color.LimeGreen;
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
            }

            this.Invalidate(); // Force the form to repaint

        }

        private void Clear_all()
        {
            textBox1.Text = string.Empty;
            newNumberMode = true;
            firstNumber_str = string.Empty;
            secondNumber_str = string.Empty;
            currentOperator_str = string.Empty;

        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.EndsWith("^") && isEnteringExponent) //Exponent mode deleting numbers
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                exponent = exponent.Substring(0, exponent.Length - 1);
            }
            else if (textBox1.Text.EndsWith("^") && isEnteringExponent) //deleting exponent mode
            {
                isEnteringExponent = false;
                exponent = "";
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else if (textBox1.Text.Length > 0 && "+-X÷%".Contains(textBox1.Text.Last()))
            {
                currentOperator_str = "";
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else if (secondNumber_str != "")
            {
                secondNumber_str = secondNumber_str.Substring(0, secondNumber_str.Length - 1);
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else if (firstNumber_str != "")
            {
                firstNumber_str = firstNumber_str.Substring(0, firstNumber_str.Length - 1);
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }
        private void numberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Get the button that was clicked
            appendDigit(button.Text, false);
        }

        private void appendDigit(string digit, bool FromKeyBoard)
        {
            if (isEnteringExponent)
            {
                exponent += digit;
            }
            else if (newNumberMode)
            {
                firstNumber_str = digit;
                newNumberMode = false;
            }
            else //continuing the same number
            {
                if (digit == ",")
                {
                    // Prevent multiple commas in the same number
                    if (!firstNumber_str.Contains(",") && currentOperator_str == "")
                    {
                        firstNumber_str += digit;
                    }
                    else if (!secondNumber_str.Contains(","))
                    {
                        secondNumber_str += digit;
                    }
                }
                else
                {
                    if (currentOperator_str == "")
                        firstNumber_str += digit;
                    else
                        secondNumber_str += digit;
                }

            }
            if (!FromKeyBoard)
            {
                textBox1.Text += digit;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
            (char.IsDigit(e.KeyChar) ||
             e.KeyChar == ',' ||
             e.KeyChar == '+' ||
             e.KeyChar == '-' ||
             e.KeyChar == '*' ||
             e.KeyChar == '/' ||
             e.KeyChar == '%' ||
             (e.KeyChar == '^' && textBox1.Text.Length > 0 && !"+-X÷%".Contains(textBox1.Text.Last())) ||
             e.KeyChar == '!' ||
             e.KeyChar == ',' ||
             e.KeyChar == (char)Keys.Back ||
             e.KeyChar == (char)Keys.Enter))
            {
                if (char.IsDigit(e.KeyChar))
                {
                    appendDigit(e.KeyChar.ToString(), true);
                }
                else if (e.KeyChar == '+' || e.KeyChar == '-' ||
                 e.KeyChar == '/' || e.KeyChar == '%' || e.KeyChar == '*')
                {
                    if (e.KeyChar == '*') e.KeyChar = (char)Keys.X;
                    appendOperator(e.KeyChar.ToString(), true);  // Treat operators like digits
                }
                else if (e.KeyChar == '^')
                {
                    isEnteringExponent = true;
                }
                else if (e.KeyChar == '!')
                {
                    Factorial_Click(this, EventArgs.Empty);
                }
                else if (e.KeyChar == ',' || e.KeyChar == '.')
                {
                    if (e.KeyChar == '.') e.KeyChar = (char)42;
                    appendDigit(e.KeyChar.ToString(), true);  // Allow decimal 
                }
                else if (e.KeyChar == (char)Keys.Back)  // Handle Backspace
                {
                    Delete_Click(this, EventArgs.Empty);
                }
                else if (e.KeyChar == (char)Keys.Enter)
                {
                    Result_Click(this, EventArgs.Empty);
                }
            }
            else
            {
                e.Handled = true; // Prevent any other characters 
            }
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            appendOperator(button.Text, false);

        }
        private void appendOperator(string newOperator, bool FromKeyBoard)
        {

            if (currentOperator_str == "")
            {
                if (!FromKeyBoard) textBox1.Text += newOperator;
                currentOperator_str = newOperator;
            }
            else
            {
                // Find the last occurrence of the current operator
                int lastOperatorIndex = textBox1.Text.LastIndexOf(currentOperator_str);

                // Make sure it exists and is not before num
                if (lastOperatorIndex > 0)
                {
                    // Replace with the new operator
                    textBox1.Text = textBox1.Text.Remove(lastOperatorIndex, currentOperator_str.Length)
                        .Insert(lastOperatorIndex, newOperator);
                }

                currentOperator_str = newOperator;
            }

            if (isEnteringExponent)
            {
                performExponentiation();
                if (!FromKeyBoard) textBox1.Text += newOperator;
            }
        }

        private void Result_Click(object sender, EventArgs e)
        {
            if (isEnteringExponent)
            {
                performExponentiation();
            }

            decimal num1 = 0.0M, num2 = 0.0M, result = 0.0M;
            decimal.TryParse(firstNumber_str, out num1);
            decimal.TryParse(secondNumber_str, out num2);
            //Added variable where is stored pointer to exception
            Exception ex = null;

            if (currentOperator_str == "") //added
            {
                decimal.TryParse(firstNumber_str, out result);
            }
            switch (currentOperator_str)
            {
                case "+":
                    try
                    {
                        result = mathLib.Add(num1, num2);
                    }
                    catch (Exception lok_ex)
                    {
                        ex = lok_ex;
                    }
                    break;
                case "-":
                    try
                    {
                        result = mathLib.Substraction(num1, num2);
                    }
                    catch (Exception lok_ex)
                    {
                        ex = lok_ex;
                    }
                    break;
                case "X":
                    try
                    {
                        result = mathLib.Multiplication(num1, num2);
                    }
                    catch (Exception lok_ex)
                    {
                        ex = lok_ex;
                    }
                    break;
                case "÷":
                    try
                    {
                        result = mathLib.Division(num1, num2);
                    }
                    catch (Exception lok_ex)
                    {
                        ex = lok_ex;
                    }
                    break;
                case "%":
                    try
                    {
                        result = mathLib.Modulo(num1, num2);
                    }
                    catch (Exception lok_ex)
                    {
                        ex = lok_ex;
                    }
                    break;

            }

            //Error print due to exception
            if (ex != null)
            {
                //lok_ex.Message
                Clear_all();
                if (ex.GetType().Name == "OverflowException")
                {
                    textBox1.Text = "Error: Overflow";
                }
                else if (ex.GetType().Name == "DivideByZeroException")
                {
                    textBox1.Text = "Error: Divide by zero";
                }
                else if (ex.GetType().Name == "NegativeFactorialException")
                {
                    textBox1.Text = "Error: Negative num";
                }
                else if (ex.GetType().Name == "NonNaturalExponentException")
                {
                    textBox1.Text = "Error: Decimal num";
                }
                else if (ex.GetType().Name == "NegativeRootException")
                {
                    textBox1.Text = "Error: Negative num";
                }
                else
                {
                    textBox1.Text = String.Format("Error: {0}", ex.Message);
                }
            }
            else
            {
                string formattedResult = mathLib.FormatDecimal(result, 3);
                textBox1.Text = formattedResult;
                firstNumber_str = formattedResult;
            }

            currentOperator_str = string.Empty;
            secondNumber_str = string.Empty;
            newNumberMode = false;
        }

        private void performExponentiation()
        {
            decimal num1, num2, exponentNum;
            decimal.TryParse(firstNumber_str, out num1);
            decimal.TryParse(exponent, out exponentNum);
            decimal.TryParse(secondNumber_str, out num2);
            decimal result = 0;
            Exception ex = null;

            if (secondNumber_str == "")
            {
                try
                {
                    result = mathLib.Exponentiation(num1, exponentNum);
                }
                catch (Exception lok_ex)
                {
                    ex = lok_ex;
                }
                firstNumber_str = result.ToString();
                textBox1.Text = firstNumber_str;
            }
            else
            {
                try
                {
                    result = mathLib.Exponentiation(num2, exponentNum);
                }
                catch (Exception lok_ex)
                {
                    ex = lok_ex;
                }
                secondNumber_str = result.ToString();

            }

            exponent = "";
            isEnteringExponent = false;

            if (ex != null)
            {
                Clear_all();
                textBox1.Text = String.Format("Error: {0}", ex.Message);
            }
        }

        private void Factorial_Click(object sender, EventArgs e)
        {
            decimal num1, num2;
            string BeforeSecNumber;
            Exception ex = null;

            if (currentOperator_str == "")
            {
                decimal.TryParse(firstNumber_str, out num1);
                try
                {
                    num1 = mathLib.Faktorial(num1);
                }
                catch (Exception lok_ex)
                {
                    ex = lok_ex;
                }
                textBox1.Text = num1.ToString();
                firstNumber_str = num1.ToString();
            }
            else
            {
                decimal.TryParse(firstNumber_str, out num1);
                decimal.TryParse(secondNumber_str, out num2);

                BeforeSecNumber = firstNumber_str + currentOperator_str;
                try
                {
                    num2 = mathLib.Faktorial(num2);
                }
                catch (Exception lok_ex)
                {
                    ex = lok_ex;
                }
                textBox1.Text = BeforeSecNumber + num2.ToString();

                firstNumber_str = num1.ToString();
                secondNumber_str = num2.ToString();
            }
            if (ex != null)
            {
                Clear_all();
                textBox1.Text = String.Format("Error: {0}", ex.Message);
            }
        }

        private void toPowerOf2_Click(object sender, EventArgs e)
        {
            decimal num1, num2;
            string BeforeSecNumber;
            Exception ex = null;

            if (currentOperator_str == "")
            {
                decimal.TryParse(firstNumber_str, out num1);
                try
                {
                    num1 = mathLib.Exponentiation(num1, 2);
                }
                catch (Exception lok_ex)
                {
                    ex = lok_ex;
                }
                firstNumber_str = mathLib.FormatDecimal(num1, 3).ToString();
                textBox1.Text = firstNumber_str;

            }
            else
            {
                decimal.TryParse(firstNumber_str, out num1);
                decimal.TryParse(secondNumber_str, out num2);

                BeforeSecNumber = firstNumber_str + currentOperator_str;
                try
                {
                    num2 = mathLib.Exponentiation(num2, 2);
                }
                catch (Exception lok_ex)
                {
                    ex = lok_ex;
                }
                textBox1.Text = BeforeSecNumber + mathLib.FormatDecimal(num2, 3).ToString();

                firstNumber_str = num1.ToString();
                secondNumber_str = mathLib.FormatDecimal(num2, 3).ToString();
            }
            if (ex != null)
            {
                Clear_all();
                textBox1.Text = String.Format("Error: {0}", ex.Message);
            }

        }

        private void toPowerOfX_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && !"+-X÷%".Contains(textBox1.Text.Last()))
            {
                textBox1.Text += "^";
                isEnteringExponent = true;
            }
        }

        private void SquareRoot_Click(object sender, EventArgs e)
        {
            decimal num1, num2;
            string BeforeSecNumber;
            Exception ex = null;

            if (currentOperator_str == "")
            {
                decimal.TryParse(firstNumber_str, out num1);
                try
                {
                    num1 = mathLib.SquareRoot(num1);
                }
                catch (Exception lok_ex)
                {
                    ex = lok_ex;
                }
                string formattedResult = mathLib.FormatDecimal(num1, 3);
                textBox1.Text = formattedResult;

                firstNumber_str = num1.ToString();
            }
            else
            {
                decimal.TryParse(firstNumber_str, out num1);
                decimal.TryParse(secondNumber_str, out num2);

                BeforeSecNumber = firstNumber_str + currentOperator_str;
                try
                {
                    num2 = mathLib.SquareRoot(num2);
                }
                catch (Exception lok_ex)
                {
                    ex = lok_ex;
                }
                string formattedResult = mathLib.FormatDecimal(num2, 3);
                textBox1.Text = BeforeSecNumber + formattedResult;

                firstNumber_str = num1.ToString();
                secondNumber_str = num2.ToString();
            }

            if (ex != null)
            {
                Clear_all();
                textBox1.Text = String.Format("Error: {0}", ex.Message);
            }
        }


        private void Clear_Click(object sender, EventArgs e) // button "C"
        {
            Clear_all();
        }
    }
}
