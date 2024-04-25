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
        /// <summary>
        /// Constructor for the Calculator class. Initializes UI components and attaches 
        /// the Form1_Paint event handler.
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint); // Attach the handler
        }

        /// <summary>
        /// Handles the Load event for Form1. Sets initial focus, configures UI elements, 
        /// and initializes internal data structures for managing panels and converter options.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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

        #region Variables

        // Mode Variables
        private bool isDarkMode = false;
        private Color darkModeStartColor = Color.FromArgb(20, 55, 73);
        private Color darkModeEndColor = Color.FromArgb(37, 49, 61);
        private Color lightModeStartColor = Color.White;
        private Color lightModeEndColor = Color.LightGray;

        // Converter Variables
        private bool isCollapsed;
        Button button_toDropDown = new Button();
        Panel panel_toDropDown = new Panel();
        string InputUnit_str, OutputUnit_str;
        string ConvertNumber_str = string.Empty;
        string curr_ConversionType = string.Empty;
        Optional_functions opt_functions = new Optional_functions();

        // Calculator Variables
        private string firstNumber_str = "";
        private string secondNumber_str = "";
        private string currentOperator_str = "";
        private bool newNumberMode = true; // Flag to signal if we're starting a new number
        private bool isEnteringExponent = false;
        private string exponent = ""; // Store the exponent digits

        List<Panel> listPanel = new List<Panel>();
        private Math_lib mathLib = new Math_lib();
        int indexOfCalculator = 0;
        int indexOfSettings = 1;
        int indexOfDegrees = 2;

        #endregion // Variables


        /// <summary>
        /// Applies a gradient background to the form based on the current mode (light or dark).
        /// </summary>
        /// <param name="sender">The object that raised the Paint event.</param>
        /// <param name="e">The PaintEventArgs object containing event data.</param>
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

        /// <summary>
        /// Handles the CheckedChanged event of the customControl1 (presumably a dark mode toggle control).
        /// Updates the visual theme of the form and its controls accordingly.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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
            Main_Setting_panel.BackColor = isDarkMode ? Color.FromArgb(35, 45, 54) : Color.Silver;
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

        /// <summary>
        /// Applies a dark or light mode color theme to a collection of Button controls 
        /// within a specified parent container.
        /// </summary>
        /// <param name="parentControl">The container control whose child buttons will be updated.</param>
        /// <param name="isDarkMode">True if dark mode is enabled, false for light mode.</param>
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

        /// <summary>
        /// Handles the click event for the calculator button, showing the calculator panel and hiding others.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void btn_Calculator_Click(object sender, EventArgs e)
        {
            ShowAndEnablePanel(indexOfCalculator); //clean po kazdej zmene
        }

        /// <summary>
        /// Handles the click event for the settings button, showing the settings panel and hiding others.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            ShowAndEnablePanel(indexOfSettings);
        }

        /// <summary>
        /// Hides all panels in the `listPanel` collection and then displays and enables the panel at the specified index.
        /// </summary>
        /// <param name="indexToShow">The index of the panel within `listPanel` to be shown.</param>
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

        /// <summary>
        /// Hides all panels in the inputOutputPanels collection and then selectively displays and enables two panels specified by their keys.
        /// </summary>
        /// <param name="key1">The key of the first panel to show and enable.</param>
        /// <param name="key2">The key of the second panel to show and enable.</param>
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

        /// <summary>
        /// Clears the content of textBox1 and resets calculator-related internal variables.
        /// </summary>
        private void Clear_all()
        {
            textBox1.Text = string.Empty;
            newNumberMode = true;
            firstNumber_str = string.Empty;
            secondNumber_str = string.Empty;
            currentOperator_str = string.Empty;

        }

        /// <summary>
        /// Handles the click event for the 'Delete' button. Implements logic for deleting characters 
        /// based on calculator state (exponent mode, operators, numbers).
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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

        /// <summary>
        /// Handles the click event for all number buttons. Calls the appendDigit function to add the 
        /// clicked number's digit to the calculator display.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void numberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Get the button that was clicked
            appendDigit(button.Text, false);
        }

        /// <summary>
        /// Appends a digit to the calculator's internal representation, handling cases for exponent entry, 
        /// starting a new number, and continuing an existing number. Also manages comma placement.
        /// </summary>
        /// <param name="digit">The digit to be appended (as a string).</param>
        /// <param name="fromKeyboard">Indicates whether the digit input originates from the keyboard (true) or another source (false).</param>
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

        /// <summary>
        /// Appends a digit to the number being converted, handling comma (decimal separator) placement 
        /// and updating the display.
        /// </summary>
        /// <param name="digit">The digit to be appended (as a string).</param>
        /// <param name="fromKeyboard">Indicates whether the input originates from the keyboard (true) 
        /// or another source (false).</param>
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

        /// <summary>
        /// Handles the click event of a converter number button. Extracts the button's text (digit) 
        /// and calls `appendDigitConverter` to process the input.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void numberButtonConverter_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Get the button that was clicked
            appendDigitConverter(button.Text, false);
        }

        /// <summary>
        /// Updates the input textbox of the converter, optionally parsing the value for calculations. 
        /// </summary>
        /// <param name="value">The updated value for the input textbox.</param>
        /// <param name="fromKeyboard">Indicates whether the input originates from the keyboard (true) 
        /// or another source (false).</param>
        private void UpdateInputTextBoxConverter(string value,bool fromKeyboard)
        {
            if(!fromKeyboard) textBox_Converter_Input.Text = value;
            decimal.TryParse(value, out decimal result);
            CalculateResultConvert(result, Input_LabelConvert.Text, Output_LabelConvert.Text);
        }


        /// <summary>
        /// Updates the output textbox of the converter with the specified value.
        /// </summary>
        /// <param name="value">The value to be displayed in the output textbox.</param>
        private void UpdateOutoutTextBoxConverter(string value)
        {
            textBox_Converter_Output.Text = value;
        }

        /// <summary>
        /// Handles the click event for the converter's 'Delete' button. Removes the last character from 
        /// the input and updates the display.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void DeleteConverter_Click(object sender, EventArgs e)
        {
            if (ConvertNumber_str.Length != 0)
            {
                ConvertNumber_str = ConvertNumber_str.Substring(0, ConvertNumber_str.Length - 1);
                UpdateInputTextBoxConverter(ConvertNumber_str,false);
            }
        }
        /// <summary>
        /// Handles the click event for the converter's 'Clear' button. Resets the internal number
        /// representation and clears the input and output textboxes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void ClearConverter_Text(object sender, EventArgs e)
        {
            ClearConverter_TextAll();
        }

        /// <summary>
        /// Clears all internal data related to the converter and empties its textboxes.
        /// </summary>
        private void ClearConverter_TextAll()
        {
            ConvertNumber_str = string.Empty;
            textBox_Converter_Input.Text = string.Empty;
            textBox_Converter_Output.Text = string.Empty;
        }

        /// <summary>
        /// Calculates the conversion result based on the current conversion type, input value, and 
        /// unit conversion options. Updates the output textbox with the formatted result.  
        /// </summary>
        /// <param name="value">The decimal value to be converted.</param>
        /// <param name="from">The original unit of the value.</param>
        /// <param name="to">The target unit for conversion.</param>
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

        /// <summary>
        /// Handles the KeyPress event for the converter's input textbox. Allows only numbers,
        /// a comma (decimal separator), and the Backspace key for editing.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The KeyPressEventArgs object containing information about the pressed key.</param>
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

        /// <summary>
        /// Handles the KeyPress event for the main calculator textbox (textBox1). Allows numbers, basic 
        /// operators, decimals, factorial, exponentiation, Backspace, and Enter for calculations.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The KeyPressEventArgs object containing information about the pressed key.</param>
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

        /// <summary>
        /// Handles the click event for operator buttons. Handles the special case of a negative sign at the 
        /// beginning of a number. Otherwise, delegates operator handling to the `appendOperator` function.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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

        /// <summary>
        /// Appends an operator to the calculator's internal representation and updates the display.
        /// Handles cases of replacing existing operators and performing exponentiation if necessary.
        /// </summary>
        /// <param name="newOperator">The new operator to be appended.</param>
        /// <param name="fromKeyboard">Indicates whether the input originates from the keyboard (true) 
        /// or another source (false).</param>
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

        /// <summary>
        /// Handles the click event for the 'Result' button. Performs calculations, handles potential 
        /// exceptions, formats the result, and updates the calculator display.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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

        /// <summary>
        /// Performs exponentiation calculations based on whether an exponent and an optional second 
        /// number are present. Handles potential exceptions and updates calculator state.
        /// </summary>
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

        /// <summary>
        /// Handles the click event of the 'Factorial' button. Calculates the factorial of the 
        /// current number (first or second) and updates the calculator display. Manages potential 
        /// exceptions.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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

        /// <summary>
        /// Handles the click event of the 'Square' button (raises the current number to the power of 2). 
        /// Updates the calculator display and handles potential exceptions.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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

        /// <summary>
        /// Handles the click event for the '^' (exponentiation) button. Prepares the calculator state 
        /// for entering an exponent if the input field is not empty and doesn't end with an operator.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void toPowerOfX_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && !"+-X÷%".Contains(textBox1.Text.Last()))
            {
                textBox1.Text += "^";
                isEnteringExponent = true;
            }
        }

        /// <summary>
        /// Handles the click event of the 'Square Root' button. Calculates the square root of either 
        /// the first or second number, updates the display, and manages potential exceptions.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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

        /// <summary>
        /// Handles the click event for the 'Clear' button (labeled "C"). 
        /// Calls the Clear_all function to reset the calculator.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void Clear_Click(object sender, EventArgs e) // button "C"
        {
            Clear_all();
        }

        /// <summary>
        /// Handles the timer tick event, responsible for smoothly expanding or collapsing a panel (animation).
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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

        /// <summary>
        /// Handles the click event for the Unit Converter button. Manages the expansion of the panel 
        /// and configuration of the degrees unit conversion.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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

        /// <summary>
        /// Performs setup actions specifically for degree unit conversions. Ensures input/output 
        /// panels are visible, sets the conversion type, labels, and clears textboxes.
        /// </summary>
        private void PerformDegreeSetup()
        {
            ShowAndEnableInOutPanels("IDegree", "ODegree");
            curr_ConversionType = "Degree";
            Input_LabelConvert.Text = "deg";
            Output_LabelConvert.Text = "deg";
            ClearConverter_TextAll();

        }

        #region Input/Output text for Convert Textboxes
        /// <summary>
        /// Updates the converter after a unit selection is made. Ensures that if the input textbox 
        /// is not empty, the input value is recalculated based on the new units.
        /// </summary>
        private void UpdateAfterEachSelection()
        {
            if (textBox_Converter_Input.Text != string.Empty)
            {
                UpdateInputTextBoxConverter(textBox_Converter_Input.Text,false);
            }
        }

        // reset values to default when chaning units
        /// <summary>
        /// Handles the click event for an input unit dropdown button. Updates the input unit label
        /// and recalculates the input value based on the newly selected unit.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void dropdownInputButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Get the button that was clicked
            InputUnit_str = button.Text;
            Input_LabelConvert.Text = InputUnit_str;
            UpdateAfterEachSelection();
        }

        /// <summary>
        /// Handles the click event for an output unit dropdown button. Updates the output unit label 
        /// and recalculates the output value based on the newly selected unit.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void dropdownOutPutButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Get the button that was clicked
            OutputUnit_str = button.Text;
            Output_LabelConvert.Text = OutputUnit_str;
            UpdateAfterEachSelection();
        }

        #endregion

        #region Degrees-Related Functions
        /// <summary>
        /// Handles the click event for a 'Degrees' button (unit conversion). 
        /// Prepares the converter UI for degree-specific conversions.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void btn_Degrees_Click(object sender, EventArgs e)
        {
            ShowAndEnableInOutPanels("IDegree", "ODegree");
            curr_ConversionType = "Degree";
            Input_LabelConvert.Text = "deg";
            Output_LabelConvert.Text = "deg";
            ClearConverter_TextAll();
        }

        /// <summary>
        /// Handles the click event for a degree input unit selection button. Triggers panel 
        /// expansion (dropdown), updates the input label, and recalculates for the new unit.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void btn_Degree_Input_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = IDegree_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }

        /// <summary>
        /// Handles the click event for a degree output unit selection button. Triggers panel 
        /// expansion (dropdown), updates the output label, and recalculates.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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
        /// <summary>
        /// Handles the click event for a 'Weight' button (weight unit conversion).
        /// Prepares the converter UI for weight-specific conversions.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void btn_Weight_Click(object sender, EventArgs e)
        {
            ShowAndEnableInOutPanels("IWeight", "OWeight");
            curr_ConversionType = "Weight";
            Input_LabelConvert.Text = "mg";
            Output_LabelConvert.Text = "mg";
            ClearConverter_TextAll();
        }
        /// <summary>
        /// Handles the click event for a weight input unit selection button. Triggers panel 
        /// expansion (dropdown), updates the input label, and recalculates for the new unit.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void IWeightBtn_mm_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = IWeight_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        /// <summary>
        /// Handles the click event for a weight output unit selection button. Triggers panel 
        /// expansion (dropdown), updates the output label, and recalculates.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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
        /// <summary>
        /// Handles the click event for the 'Temperature' button (temperature conversion).
        /// Prepares the UI for temperature-specific conversions.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void btn_Temperature_Click(object sender, EventArgs e)
        {
            ShowAndEnableInOutPanels("ITemperature", "OTemperature");
            curr_ConversionType = "Temperature";
            Input_LabelConvert.Text = "C";
            Output_LabelConvert.Text = "C";
            ClearConverter_TextAll();

        }
        /// <summary>
        /// Handles the click event for a temperature input unit selection button. Triggers panel 
        /// expansion (dropdown), updates the input label, and recalculates for the new unit.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void ITemperatureBtn_C_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = ITemperature_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        /// <summary>
        /// Handles the click event for a temperature output unit selection button. Triggers panel 
        /// expansion (dropdown), updates the output label, and recalculates.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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
        /// <summary>
        /// Handles the click event for the 'Length' button (length unit conversion).
        /// Prepares the UI for length-specific conversions.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void btn_Length_Click(object sender, EventArgs e)
        {

            ShowAndEnableInOutPanels("ILength", "OLength");
            curr_ConversionType = "Length";
            Input_LabelConvert.Text = "mm";
            Output_LabelConvert.Text = "mm";
            ClearConverter_TextAll();
        }
        /// <summary>
        /// Handles the click event for a length input unit selection button. Triggers panel 
        /// expansion (dropdown), updates the input label, and recalculates for the new unit.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void ILengthBtn_mm_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = ILength_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        /// <summary>
        /// Handles the click event for a length output unit selection button. Triggers panel 
        /// expansion (dropdown), updates the output label, and recalculates.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
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
        /// <summary>
        /// Handles the click event for the 'Time' button (time conversion).
        /// Prepares the UI for time-specific conversions.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void btn_Time_Click(object sender, EventArgs e)
        {
            ShowAndEnableInOutPanels("ITime", "OTime");
            curr_ConversionType = "Time";
            Input_LabelConvert.Text = "sec";
            Output_LabelConvert.Text = "sec";
            ClearConverter_TextAll();
        }
        /// <summary>
        /// Handles the click event for an input time unit selection button (specifically for seconds).
        /// Triggers panel expansion (dropdown), updates the input label, and recalculates 
        /// the input value for the new unit.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void ITimeBtn_sec_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = ITime_panel;
            Input_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        /// <summary>
        /// Handles the click event for an output time unit selection button (specifically for seconds).
        /// Triggers panel expansion (dropdown), updates the output label, and recalculates 
        /// the output value for the new unit.
        /// </summary>
        /// <param name="sender">The button object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void OTimeBtn_sec_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_toDropDown = (Button)sender;
            panel_toDropDown = OTime_panel;
            Output_LabelConvert.Text = ((Button)sender).Text;
            UpdateAfterEachSelection();
        }
        /// <summary>
        /// Handles the click event of the help button. Displays a message box containing 
        /// instructions on how to use the calculator.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The EventArgs object containing event data.</param>
        private void help_button_Click(object sender, EventArgs e)
        {
            string messageText = "**Calculator Instructions**\n\n" +
                         "There are three main sections:\n\n" +
                         "1. **Calculator:** Perform basic calculations using buttons or the keyboard. Supported operations include: +, -, *, /, %, square root, square, power (^) , factorial, clearing numbers, and deleting input.\n\n" +
                         "2. **Converter:** Convert between units of length, weight, temperature, time, and degrees. Calculations happen in real-time. Use the dropdown menus to select specific units for each conversion type.\n\n" +
                         "3. **Settings:** (For future implementation)\n\n" +
                         "**Other Features**\n\n" +
                         "* **Help Button:** (This button!) Displays these instructions.\n" +
                         "* **Dark/Light Mode:** Switch between display themes.\n\n";

            string title = "Calculator Help";

            MessageBox.Show(messageText, title);
        }

        #endregion

        /// <summary>
        /// Handles the Paint event for the Main_Calculator_panel. This function is 
        /// responsible for custom drawing or rendering visual elements within the panel.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The PaintEventArgs object containing event data and graphics context.</param>
        private void Main_Calculator_panel_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
