namespace CalculatorApp
{
    partial class Calculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.Substitution = new System.Windows.Forms.Button();
            this.Multiplication = new System.Windows.Forms.Button();
            this.Division = new System.Windows.Forms.Button();
            this.Modulo = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Button();
            this.Factorial = new System.Windows.Forms.Button();
            this.toPowerOf2 = new System.Windows.Forms.Button();
            this.SquareRoot = new System.Windows.Forms.Button();
            this.toPowerOfX = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.customControl1 = new CalculatorApp.CustomControls.CustomControl();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(227, 352);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(85, 278);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 50);
            this.button4.TabIndex = 5;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(156, 278);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(227, 278);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 50);
            this.button6.TabIndex = 3;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(85, 204);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 50);
            this.button7.TabIndex = 8;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(156, 204);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 50);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(227, 204);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 50);
            this.button9.TabIndex = 6;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 67);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 41);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(156, 352);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 10;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // Plus
            // 
            this.Plus.Cursor = System.Windows.Forms.Cursors.Default;
            this.Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Plus.Location = new System.Drawing.Point(298, 352);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(50, 50);
            this.Plus.TabIndex = 11;
            this.Plus.Text = "+";
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.operatorButton_Click);
            // 
            // Substitution
            // 
            this.Substitution.Cursor = System.Windows.Forms.Cursors.Default;
            this.Substitution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Substitution.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Substitution.Location = new System.Drawing.Point(298, 278);
            this.Substitution.Name = "Substitution";
            this.Substitution.Size = new System.Drawing.Size(50, 50);
            this.Substitution.TabIndex = 12;
            this.Substitution.Text = "-";
            this.Substitution.UseVisualStyleBackColor = true;
            this.Substitution.Click += new System.EventHandler(this.operatorButton_Click);
            // 
            // Multiplication
            // 
            this.Multiplication.Cursor = System.Windows.Forms.Cursors.Default;
            this.Multiplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Multiplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Multiplication.Location = new System.Drawing.Point(298, 204);
            this.Multiplication.Name = "Multiplication";
            this.Multiplication.Size = new System.Drawing.Size(50, 50);
            this.Multiplication.TabIndex = 13;
            this.Multiplication.Text = "X";
            this.Multiplication.UseVisualStyleBackColor = true;
            this.Multiplication.Click += new System.EventHandler(this.operatorButton_Click);
            // 
            // Division
            // 
            this.Division.Cursor = System.Windows.Forms.Cursors.Default;
            this.Division.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Division.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Division.Location = new System.Drawing.Point(298, 136);
            this.Division.Name = "Division";
            this.Division.Size = new System.Drawing.Size(50, 50);
            this.Division.TabIndex = 15;
            this.Division.Text = "÷";
            this.Division.UseVisualStyleBackColor = true;
            this.Division.Click += new System.EventHandler(this.operatorButton_Click);
            // 
            // Modulo
            // 
            this.Modulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.Modulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Modulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modulo.Location = new System.Drawing.Point(227, 136);
            this.Modulo.Name = "Modulo";
            this.Modulo.Size = new System.Drawing.Size(50, 50);
            this.Modulo.TabIndex = 16;
            this.Modulo.Text = "%";
            this.Modulo.UseVisualStyleBackColor = true;
            this.Modulo.Click += new System.EventHandler(this.operatorButton_Click);
            // 
            // Clear
            // 
            this.Clear.Cursor = System.Windows.Forms.Cursors.Default;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.Location = new System.Drawing.Point(156, 138);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(50, 50);
            this.Clear.TabIndex = 17;
            this.Clear.Text = "C";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Result
            // 
            this.Result.Cursor = System.Windows.Forms.Cursors.Default;
            this.Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Result.Location = new System.Drawing.Point(298, 425);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(50, 50);
            this.Result.TabIndex = 18;
            this.Result.Text = "=";
            this.Result.UseVisualStyleBackColor = true;
            this.Result.Click += new System.EventHandler(this.Result_Click);
            // 
            // Factorial
            // 
            this.Factorial.Cursor = System.Windows.Forms.Cursors.Default;
            this.Factorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Factorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Factorial.Location = new System.Drawing.Point(368, 278);
            this.Factorial.Name = "Factorial";
            this.Factorial.Size = new System.Drawing.Size(50, 50);
            this.Factorial.TabIndex = 19;
            this.Factorial.Text = "n!";
            this.Factorial.UseVisualStyleBackColor = true;
            this.Factorial.Click += new System.EventHandler(this.Factorial_Click);
            // 
            // toPowerOf2
            // 
            this.toPowerOf2.Cursor = System.Windows.Forms.Cursors.Default;
            this.toPowerOf2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toPowerOf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toPowerOf2.Location = new System.Drawing.Point(368, 204);
            this.toPowerOf2.Name = "toPowerOf2";
            this.toPowerOf2.Size = new System.Drawing.Size(50, 50);
            this.toPowerOf2.TabIndex = 20;
            this.toPowerOf2.Text = "n²";
            this.toPowerOf2.UseVisualStyleBackColor = true;
            this.toPowerOf2.Click += new System.EventHandler(this.toPowerOf2_Click);
            // 
            // SquareRoot
            // 
            this.SquareRoot.Cursor = System.Windows.Forms.Cursors.Default;
            this.SquareRoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SquareRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SquareRoot.Location = new System.Drawing.Point(368, 138);
            this.SquareRoot.Name = "SquareRoot";
            this.SquareRoot.Size = new System.Drawing.Size(50, 50);
            this.SquareRoot.TabIndex = 21;
            this.SquareRoot.Text = "√ ";
            this.SquareRoot.UseVisualStyleBackColor = true;
            this.SquareRoot.Click += new System.EventHandler(this.SquareRoot_Click);
            // 
            // toPowerOfX
            // 
            this.toPowerOfX.Cursor = System.Windows.Forms.Cursors.Default;
            this.toPowerOfX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toPowerOfX.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toPowerOfX.Location = new System.Drawing.Point(368, 352);
            this.toPowerOfX.Name = "toPowerOfX";
            this.toPowerOfX.Size = new System.Drawing.Size(50, 50);
            this.toPowerOfX.TabIndex = 22;
            this.toPowerOfX.Text = "nˣ";
            this.toPowerOfX.UseVisualStyleBackColor = true;
            this.toPowerOfX.Click += new System.EventHandler(this.toPowerOfX_Click);
            // 
            // button14
            // 
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(156, 425);
            this.button14.Margin = new System.Windows.Forms.Padding(2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(50, 50);
            this.button14.TabIndex = 23;
            this.button14.Text = "0";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(85, 352);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 24;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // customControl1
            // 
            this.customControl1.AutoSize = true;
            this.customControl1.Location = new System.Drawing.Point(90, 152);
            this.customControl1.MinimumSize = new System.Drawing.Size(45, 22);
            this.customControl1.Name = "customControl1";
            this.customControl1.OffBackColor = System.Drawing.Color.Gray;
            this.customControl1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.customControl1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.customControl1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.customControl1.Size = new System.Drawing.Size(45, 22);
            this.customControl1.TabIndex = 25;
            this.customControl1.UseVisualStyleBackColor = true;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(450, 536);
            this.Controls.Add(this.customControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.toPowerOfX);
            this.Controls.Add(this.SquareRoot);
            this.Controls.Add(this.toPowerOf2);
            this.Controls.Add(this.Factorial);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Modulo);
            this.Controls.Add(this.Division);
            this.Controls.Add(this.Multiplication);
            this.Controls.Add(this.Substitution);
            this.Controls.Add(this.Plus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Plus;
        private System.Windows.Forms.Button Substitution;
        private System.Windows.Forms.Button Multiplication;
        private System.Windows.Forms.Button Division;
        private System.Windows.Forms.Button Modulo;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Result;
        private System.Windows.Forms.Button Factorial;
        private System.Windows.Forms.Button toPowerOf2;
        private System.Windows.Forms.Button SquareRoot;
        private System.Windows.Forms.Button toPowerOfX;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button1;
        private CustomControls.CustomControl customControl1;
    }
}

