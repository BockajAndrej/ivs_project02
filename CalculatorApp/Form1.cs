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

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            int width = this.Width;
            int height = this.Height;

            // Create the rectangle using the form's dimensions
            Rectangle gradient_rectangle = new Rectangle(0, 0, width, height);

            Brush brush = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(36, 8, 61), Color.FromArgb(92, 26, 116), 45f);
            graphics.FillRectangle(brush, gradient_rectangle);
        }




        //UI
        private bool isDarkMode = false;


        //Buttons
        private string firstNumber_str = "";
        private string secondNumber_str = "";
        private string currentOperator_str = "";
        private bool newNumberMode = true; // Flag to signal if we're starting a new number

        private bool isEnteringExponent = false;
        private string exponent = ""; // Store the exponent digits

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
            string number = button.Text;
            if (isEnteringExponent)
            {
                textBox1.Text += number;
                exponent += number;
            }
            else if (newNumberMode)
            {
                textBox1.Text = number;
                firstNumber_str = number;
                newNumberMode = false;
            }
            else //continuing the same number
            {
                if (number == ",")
                {
                    // Prevent multiple commas in the same number
                    if (!firstNumber_str.Contains(",") && currentOperator_str == "")
                    {
                        firstNumber_str += number;
                        textBox1.Text += number;
                    }
                    else if (!secondNumber_str.Contains(","))
                    {
                        secondNumber_str += number;
                        textBox1.Text += number;
                    }

                }
                else  // number
                {
                    if (currentOperator_str == "")
                        firstNumber_str += number;
                    else
                        secondNumber_str += number;
                    textBox1.Text += number;
                }
            }
        }
        private void operatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string newOperator = button.Text;

            if (currentOperator_str == "")
            {
                textBox1.Text += newOperator;
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
                textBox1.Text += button.Text;
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
            if (currentOperator_str == "") //added
            {
                decimal.TryParse(firstNumber_str, out result);
            }
            switch (currentOperator_str)
            {
                case "+":
                    result = mathLib.Add(num1, num2);
                    break;
                case "-":
                    result = mathLib.Substraction(num1, num2);
                    break;
                case "X":
                    result = mathLib.Multiplication(num1, num2);
                    break;
                case "÷":
                    result = mathLib.Division(num1, num2);
                    break;
                case "%":
                    result = mathLib.Modulo(num1, num2);
                    break;

            }
            string formattedResult = mathLib.FormatDecimal(result, 3);
            textBox1.Text = formattedResult;
            firstNumber_str = formattedResult;
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
            if (secondNumber_str == "")
            {
                result = mathLib.Exponentiation(num1, exponentNum);
                firstNumber_str = result.ToString();
                textBox1.Text = firstNumber_str;
            }
            else
            {
                result = mathLib.Exponentiation(num2, exponentNum);
                secondNumber_str = result.ToString();

            }

            exponent = "";
            isEnteringExponent = false;
        }

        private void Factorial_Click(object sender, EventArgs e)
        {
            decimal num1, num2;
            string BeforeSecNumber;

            if (currentOperator_str == "")
            {
                decimal.TryParse(firstNumber_str, out num1);
                num1 = mathLib.Faktorial(num1);
                textBox1.Text = num1.ToString();

                firstNumber_str = num1.ToString();
            }
            else
            {
                decimal.TryParse(firstNumber_str, out num1);
                decimal.TryParse(secondNumber_str, out num2);

                BeforeSecNumber = firstNumber_str + currentOperator_str;
                num2 = mathLib.Faktorial(num2);
                textBox1.Text = BeforeSecNumber + num2.ToString();

                firstNumber_str = num1.ToString();
                secondNumber_str = num2.ToString();
            }
        }

        private void toPowerOf2_Click(object sender, EventArgs e)
        {
            decimal num1, num2;
            string BeforeSecNumber;

            if (currentOperator_str == "")
            {
                decimal.TryParse(firstNumber_str, out num1);
                num1 = mathLib.Exponentiation(num1, 2);

                firstNumber_str = mathLib.FormatDecimal(num1, 3).ToString();
                textBox1.Text = firstNumber_str;

            }
            else
            {
                decimal.TryParse(firstNumber_str, out num1);
                decimal.TryParse(secondNumber_str, out num2);

                BeforeSecNumber = firstNumber_str + currentOperator_str;
                num2 = mathLib.Exponentiation(num2, 2);
                textBox1.Text = BeforeSecNumber + mathLib.FormatDecimal(num2, 3).ToString();

                firstNumber_str = num1.ToString();
                secondNumber_str = mathLib.FormatDecimal(num2, 3).ToString();
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

            if (currentOperator_str == "")
            {
                decimal.TryParse(firstNumber_str, out num1);
                num1 = mathLib.SquareRoot(num1);
                string formattedResult = mathLib.FormatDecimal(num1, 3);
                textBox1.Text = formattedResult;

                firstNumber_str = num1.ToString();
            }
            else
            {
                decimal.TryParse(firstNumber_str, out num1);
                decimal.TryParse(secondNumber_str, out num2);

                BeforeSecNumber = firstNumber_str + currentOperator_str;
                num2 = mathLib.SquareRoot(num2);
                string formattedResult = mathLib.FormatDecimal(num2, 3);
                textBox1.Text = BeforeSecNumber + formattedResult;

                firstNumber_str = num1.ToString();
                secondNumber_str = num2.ToString();
            }
        }


        private void Clear_Click(object sender, EventArgs e) // button "C"
        {
            Clear_all();
        }

        private void Comma_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void customControl1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
