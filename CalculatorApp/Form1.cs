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
using CalculatorApp.Properties;


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
            listPanel.Add(Main_Calculator_panel); //index 0
            listPanel.Add(Main_Setting_panel); //index 1
            listPanel.Add(panel_Converter); //index 2

            ShowAndEnablePanel(indexOfCalculator);

            inputOutputPanels.Add("IDegree", IDegree_panel);
            inputOutputPanels.Add("ODegree", ODegree_panel);

            inputOutputPanels.Add("ITemperature", ITemperature_panel);
            inputOutputPanels.Add("OTemperature", OTemperature_panel);

            inputOutputPanels.Add("IWeight", IWeight_panel);
            inputOutputPanels.Add("OWeight", OWeight_panel);

            inputOutputPanels.Add("ITime", ITime_panel);
            inputOutputPanels.Add("OTime", OTime_panel);

            inputOutputPanels.Add("ILength", ILength_panel);
            inputOutputPanels.Add("OLength", OLength_panel);

        }
        Dictionary<string, Panel> inputOutputPanels = new Dictionary<string, Panel>();

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
                    button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
                }
            }


            Main_Calculator_panel.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
            Btn_UnitConverter.ForeColor = isDarkMode ? Color.YellowGreen : Color.Black;
            Btn_UnitConverter.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;

            textBox1.BackColor = isDarkMode ? Color.FromArgb(20, 55, 73) : Color.White;
            textBox1.ForeColor = isDarkMode ? Color.LimeGreen : Color.Black;

            foreach (Control control in Main_Calculator_panel.Controls) //Calculator main
            {
                if (control is Button button)
                {
                    string btnName = button.Name;
                    if (btnName.StartsWith("button"))
                    {
                        button.ForeColor = isDarkMode ? Color.YellowGreen : Color.Black;
                        button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
                    }
                    if (btnName.StartsWith("op"))
                    {
                        button.ForeColor = isDarkMode ? Color.DarkOrange : Color.Black;
                        button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
                    }
                    if (btnName.StartsWith("del"))
                    {
                        button.ForeColor = isDarkMode ? Color.DarkOrange : Color.Black;
                        button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
                    }
                    if (btnName.StartsWith("sp"))
                    {
                        button.ForeColor = isDarkMode ? Color.DarkCyan : Color.Black;
                        button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
                    }
                }
            }

            foreach (Control control in PanelDown_UnitConverter.Controls) //Calculator main
            {
                if (control is Button button)
                {
                    button.ForeColor = isDarkMode ? Color.YellowGreen : Color.Black;
                    button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
                }
            }
            //panel
            ApplyColorThemeToButtons(panel_Converter, isDarkMode);


            panel_Converter.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;

            //textboxes
            textBox_Converter_Input.BorderStyle = BorderStyle.FixedSingle;
            textBox_Converter_Input.BackColor = isDarkMode ? Color.FromArgb(20, 55, 73) : Color.White;
            textBox_Converter_Input.ForeColor = isDarkMode ? Color.LimeGreen : Color.Black;

            textBox_Converter_Output.BorderStyle = BorderStyle.FixedSingle;
            textBox_Converter_Output.BackColor = isDarkMode ? Color.FromArgb(20, 55, 73) : Color.White;
            textBox_Converter_Output.ForeColor = isDarkMode ? Color.LimeGreen : Color.Black;

            //labels
            Input_LabelConvert.ForeColor = isDarkMode ? Color.YellowGreen : Color.Black;
            Output_LabelConvert.ForeColor = isDarkMode ? Color.YellowGreen : Color.Black;



            this.Invalidate(); // Force the form to repaint

        }

        private void ApplyColorThemeToButtons(Control parentControl, bool isDarkMode)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is Button button)
                {
                    string btnName = button.Name;

                    if (btnName.StartsWith("del"))
                    {
                        button.ForeColor = isDarkMode ? Color.DarkOrange : Color.Black;
                        button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
                    }
                    else if (btnName == "CommaConverter")
                    {
                        button.ForeColor = isDarkMode ? Color.DarkCyan : Color.Black;
                        button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
                    }
                    else if (btnName.StartsWith("button"))
                    {
                        button.ForeColor = isDarkMode ? Color.YellowGreen : Color.Black;
                        button.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
                    }
                }
            }
        }


        List<Panel> listPanel = new List<Panel>();
        int indexOfCalculator = 0;
        int indexOfSettings = 1;
        int indexOfDegrees = 2;

        private void btn_Calculator_Click(object sender, EventArgs e)
        {
            ShowAndEnablePanel(indexOfCalculator); //clean po kazdej zmene
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            ShowAndEnablePanel(indexOfSettings);
        }
        private void ShowAndEnablePanel(int indexToShow)
        {
            // Hide all panels 
            foreach (Panel panel in listPanel)
            {
                panel.Visible = false;  // Set visible to false to completely hide
                panel.Enabled = false;
            }

            // Show and enable the specific panel    
            listPanel[indexToShow].BringToFront();
            listPanel[indexToShow].Enabled = true;
            listPanel[indexToShow].Visible = true; // Ensure visibility is set to true

        }

        private void ShowAndEnableInOutPanels(string key1, string key2)
        {
            // Hide all panels
            foreach (var pair in inputOutputPanels)
            {
                pair.Value.Visible = false;
                pair.Value.Enabled = false;
            }

            // Show and enable the specific panels (error handling suggested)
            inputOutputPanels[key1].Visible = true;
            inputOutputPanels[key1].Enabled = true;
            inputOutputPanels[key2].Visible = true;
            inputOutputPanels[key2].Enabled = true;

            // (Optional) Bring panels to front
            inputOutputPanels[key1].BringToFront();
            inputOutputPanels[key2].BringToFront();
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
                firstNumber_str += digit;
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



        #region Converter Buttons/Keyboard Input Logic

        string ConvertNumber_str = string.Empty;
        string curr_ConversionType = string.Empty;
        Optional_functions opt_functions = new Optional_functions();
        private void appendDigitConverter(string digit, bool FromKeyBoard)
        {
            bool passKeyboardCheck = FromKeyBoard;
            if (!FromKeyBoard)
            {
                if (digit == "," && !ConvertNumber_str.Contains(","))
                {
                    if (!FromKeyBoard)
                    {
                        ConvertNumber_str += digit;
                    }
                }
                else
                {
                    ConvertNumber_str += digit;
                }
            }
            UpdateInputTextBoxConverter(ConvertNumber_str, passKeyboardCheck);

        }

        private void numberButtonConverter_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Get the button that was clicked
            appendDigitConverter(button.Text, false);
        }

        private void UpdateInputTextBoxConverter(string value,bool fromKeyboard)
        {
            if(!fromKeyboard) textBox_Converter_Input.Text = value;
            decimal.TryParse(value, out decimal result);
            CalculateResultConvert(result, Input_LabelConvert.Text, Output_LabelConvert.Text);
        }

        private void UpdateOutoutTextBoxConverter(string value)
        {
            textBox_Converter_Output.Text = value;
        }

        private void DeleteConverter_Click(object sender, EventArgs e)
        {
            if (ConvertNumber_str.Length != 0)
            {
                ConvertNumber_str = ConvertNumber_str.Substring(0, ConvertNumber_str.Length - 1);
                UpdateInputTextBoxConverter(ConvertNumber_str,false);
            }
        }
        private void ClearConverter_Text(object sender, EventArgs e)
        {
            ClearConverter_TextAll();
        }
        private void ClearConverter_TextAll()
        {
            ConvertNumber_str = string.Empty;
            textBox_Converter_Input.Text = string.Empty;
            textBox_Converter_Output.Text = string.Empty;
        }

        private void CalculateResultConvert(decimal value, string from, string to)
        {
            decimal result = decimal.Zero;

            switch (curr_ConversionType)
            {
                case "Degree":
                    result = opt_functions.Degrees(value, from, to);
                    break;
                case "Weight":
                    result = opt_functions.Weight(value, from, to);
                    break;
                case "Temperature":
                    result = opt_functions.Temp(value, from, to);
                    break;
                case "Time":
                    result = opt_functions.Time(value, from, to);
                    break;
                case "Lenght":
                    result = opt_functions.Length(value, from, to);
                    break;
                default:
                    result = 0;
                    break;
            }
            string formatedConverResult = mathLib.FormatDecimal(result, 5);
            UpdateOutoutTextBoxConverter(formatedConverResult);

        }
        private void textBoxConverter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow numbers, comma, and Backspace
            if (e.KeyChar == (char)Keys.Back)
            {
                DeleteConverter_Click(this, EventArgs.Empty);
            }
            else if (char.IsDigit(e.KeyChar) || e.KeyChar == ',')
            {
                ConvertNumber_str += e.KeyChar.ToString();
                appendDigitConverter(string.Empty, true);

            }
            else
            {
                e.Handled = true; // Prevent any other characters
            }
        }

        #endregion

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
            if (newNumberMode && button.Text == "-")
            {
                firstNumber_str = "-";
                textBox1.Text = firstNumber_str;
            }
            else
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
            bool negativeFirst = false;
            if (firstNumber_str.StartsWith("-"))
            {
                negativeFirst = true;
                firstNumber_str = firstNumber_str.Substring(1);
            }
            decimal num1 = 0.0M, num2 = 0.0M, result = 0.0M;
            decimal.TryParse(firstNumber_str, out num1);
            decimal.TryParse(secondNumber_str, out num2);
            if (negativeFirst) num1 = num1 * -1;
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

        private bool isCollapsed;
        Button button_toDropDown = new Button();
        Panel panel_toDropDown = new Panel();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button_toDropDown.Image = Resources.Collapse;
                panel_toDropDown.Height += 10;
                if (panel_toDropDown.Size == panel_toDropDown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button_toDropDown.Image = Resources.dropdoiwn2;
                panel_toDropDown.Height -= 10;
                if (panel_toDropDown.Size == panel_toDropDown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }

            }
        }

        private void Btn_UnitConverter_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = PanelDown_UnitConverter;
            if (!listPanel[indexOfDegrees].Visible || !listPanel[indexOfDegrees].Enabled)
            {
                ShowAndEnablePanel(indexOfDegrees);
            }
            PerformDegreeSetup();
        }

        private void PerformDegreeSetup()
        {
            ShowAndEnableInOutPanels("IDegree", "ODegree");
            curr_ConversionType = "Degree";
            Input_LabelConvert.Text = "deg";
            Output_LabelConvert.Text = "deg";
            ClearConverter_TextAll();

        }

        #region Input/Output text for Convert Textboxes
        string InputUnit_str, OutputUnit_str;

        private void UpdateAfterEachSelection()
        {
            if (textBox_Converter_Input.Text != string.Empty)
            {
                UpdateInputTextBoxConverter(textBox_Converter_Input.Text,false);
            }
        }

        // reset values to default when chaning units
        private void dropdownInputButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Get the button that was clicked
            InputUnit_str = button.Text;
            Input_LabelConvert.Text = InputUnit_str;
            UpdateAfterEachSelection();
        }

        private void dropdownOutPutButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Get the button that was clicked
            OutputUnit_str = button.Text;
            Output_LabelConvert.Text = OutputUnit_str;
            UpdateAfterEachSelection();
        }

        #endregion

        #region Degrees-Related Functions
        private void btn_Degrees_Click(object sender, EventArgs e)
        {
            ShowAndEnableInOutPanels("IDegree", "ODegree");
            curr_ConversionType = "Degree";
            Input_LabelConvert.Text = "deg";
            Output_LabelConvert.Text = "deg";
            ClearConverter_TextAll();
        }
        private void btn_Degree_Input_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = IDegree_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }

        private void btn_Degree_Output_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = ODegree_panel;
            Output_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        #endregion

        #region Weight-Related Functions
        private void btn_Weight_Click(object sender, EventArgs e)
        {
            ShowAndEnableInOutPanels("IWeight", "OWeight");
            curr_ConversionType = "Weight";
            Input_LabelConvert.Text = "mg";
            Output_LabelConvert.Text = "mg";
            ClearConverter_TextAll();
        }
        private void IWeightBtn_mm_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = IWeight_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        private void OWeightBtn_mm_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = OWeight_panel;
            Output_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        #endregion

        #region Temperature-Related Functions
        private void btn_Temperature_Click(object sender, EventArgs e)
        {
            ShowAndEnableInOutPanels("ITemperature", "OTemperature");
            curr_ConversionType = "Temperature";
            Input_LabelConvert.Text = "C";
            Output_LabelConvert.Text = "C";
            ClearConverter_TextAll();

        }
        private void ITemperatureBtn_C_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = ITemperature_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }

        private void OTemperatureBtn_C_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = OTemperature_panel;
            Output_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        #endregion

        #region Length-Related Functions
        private void btn_Length_Click(object sender, EventArgs e)
        {

            ShowAndEnableInOutPanels("ILength", "OLength");
            curr_ConversionType = "Length";
            Input_LabelConvert.Text = "mm";
            Output_LabelConvert.Text = "mm";
            ClearConverter_TextAll();
        }
        private void ILengthBtn_mm_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = ILength_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }

        private void OLengthBtn_mm_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = OLength_panel;
            Output_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        #endregion

        #region Time-Related Functions
        private void btn_Time_Click(object sender, EventArgs e)
        {
            ShowAndEnableInOutPanels("ITime", "OTime");
            curr_ConversionType = "Time";
            Input_LabelConvert.Text = "sec";
            Output_LabelConvert.Text = "sec";
            ClearConverter_TextAll();
        }
        private void ITimeBtn_sec_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = ITime_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }

        private void OTimeBtn_sec_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = OTime_panel;
            Output_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }

        #endregion

        private void Main_Calculator_panel_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
