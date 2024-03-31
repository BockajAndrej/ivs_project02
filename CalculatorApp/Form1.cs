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

namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        private Math_lib mathLib = new Math_lib();
        public Calculator()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string firstNumber = "";
        private string secondNumber = "";
        private string currentOperator = "";
        private bool newNumberMode = true; // Flag to signal if we're starting a new number

        private void Clear_all()
        {
            textBox1.Text = string.Empty;
            newNumberMode = true;
            firstNumber = string.Empty;
            secondNumber = string.Empty;
            currentOperator = string.Empty;

        }
        private void numberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Get the button that was clicked
            string number = button.Text;
            if (newNumberMode)
            {
                textBox1.Text = number;
                firstNumber = number;
                newNumberMode = false;
            }
            else //continuing the same number
            {
                textBox1.Text += number;
                // Append digits instead of overwriting
                if (currentOperator == "")
                    firstNumber += number;
                else
                    secondNumber += number;
            }
        }
        private void operatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
            currentOperator = button.Text;
        }
        private void Result_Click(object sender, EventArgs e)
        {
            decimal num1, num2, result;
            decimal.TryParse(firstNumber, out num1);
            decimal.TryParse(secondNumber, out num2);

            switch (currentOperator)
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


                default:
                    result = 0;

                    break;


            }

            textBox1.Text = result.ToString();
            firstNumber = result.ToString();
            currentOperator = string.Empty;
            secondNumber = string.Empty;
            newNumberMode = false;
        }

        private void Factorial_Click(object sender, EventArgs e)
        {
          
        }

        private void toPowerOf2_Click(object sender, EventArgs e)
        {
            decimal num1, num2;
            string BeforeSecNumber;

            if (currentOperator == "")
            {
                decimal.TryParse(firstNumber, out num1);
                num1 = mathLib.Exponentiation(num1, 2);
                textBox1.Text = num1.ToString();

                firstNumber = num1.ToString();
            }
            else
            {
                decimal.TryParse(firstNumber, out num1);
                decimal.TryParse(secondNumber, out num2);

                BeforeSecNumber = firstNumber + currentOperator;
                num2 = mathLib.Exponentiation(num2, 2);
                textBox1.Text =  BeforeSecNumber+num2.ToString();

                firstNumber = num1.ToString();
                secondNumber = num2.ToString();
            }
            
        }

        private void toPowerOfX_Click(object sender, EventArgs e)
        {

        }

        private void SquareRoot_Click(object sender, EventArgs e)
        {

        }

        
        private void Clear_Click(object sender, EventArgs e) // button "C"
        {
            Clear_all();
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

        private void button9_Click(object sender, EventArgs e)
        {

        }

       
    }
}
