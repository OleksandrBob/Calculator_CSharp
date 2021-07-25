using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_1._0
{

    enum Operations : byte
    {
        Nothing,
        Plus,
        Minus,
        Multiply,
        Divide
    }


    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private double PreviousValue = default;
        //private double CurrentValue = default;
        private Operations CurrentOperation = Operations.Nothing;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            this.MaximumSize = new Size(375, 475);
            this.MinimumSize = this.MaximumSize;


            this.BackColor = Color.FromArgb(204, 193, 174);

            this.buttonClearAll.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonDelete.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonDivide.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonDot.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonEight.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonEquals.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonFive.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonFour.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonMinus.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonMultiply.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonNine.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonOne.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonPlus.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonSeven.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonSix.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonThree.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonTwo.BackColor = Color.FromArgb(205, 39, 49);
            this.buttonZero.BackColor = Color.FromArgb(205, 39, 49);

            this.buttonClearAll.ForeColor = Color.White;
            this.buttonDelete.ForeColor = Color.White;
            this.buttonDivide.ForeColor = Color.White;
            this.buttonDot.ForeColor = Color.White;
            this.buttonEight.ForeColor = Color.White;
            this.buttonEquals.ForeColor = Color.White;
            this.buttonFive.ForeColor = Color.White;
            this.buttonFour.ForeColor = Color.White;
            this.buttonMinus.ForeColor = Color.White;
            this.buttonMultiply.ForeColor = Color.White;
            this.buttonNine.ForeColor = Color.White;
            this.buttonOne.ForeColor = Color.White;
            this.buttonPlus.ForeColor = Color.White;
            this.buttonSeven.ForeColor = Color.White;
            this.buttonSix.ForeColor = Color.White;
            this.buttonThree.ForeColor = Color.White;
            this.buttonTwo.ForeColor = Color.White;
            this.buttonZero.ForeColor = Color.White;

            this.ShowSpace.BackColor = Color.FromArgb(91, 60, 137);
            this.ShowSpace.ForeColor = Color.White;
        }

        private void Clear_ShowSpace() 
        {
            if (   this.ShowSpace.Text == "+" 
                || this.ShowSpace.Text == "-" 
                || this.ShowSpace.Text == "/" 
                || this.ShowSpace.Text == "*" 
                || this.ShowSpace.Text == "ERROR")
            {
                this.ShowSpace.Text = "";
            }
        }


        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!this.ShowSpace.Text.Contains(",") && this.ShowSpace.Text.Length > 0)
            {
                this.ShowSpace.Text += ",";
            }
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "0";
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "1";
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "2";
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "3";
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "4";
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "5";
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "6";
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "7";
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "8";
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            Clear_ShowSpace();

            this.ShowSpace.Text += "9";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (CurrentOperation != Operations.Nothing)
            {
                switch (CurrentOperation)
                {
                    case Operations.Plus:
                        PreviousValue += double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Minus:
                        PreviousValue -= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Multiply:
                        PreviousValue *= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Divide:
                        if (double.Parse(this.ShowSpace.Text) == 0)
                        {
                            this.buttonClearAll_Click(sender, e);
                            this.ShowSpace.Text = "ERROR";                            
                            return;
                        }

                        PreviousValue /= double.Parse(this.ShowSpace.Text);
                        break;
                }


                this.ShowSpace.Text = Convert.ToString(PreviousValue);
                CurrentOperation = Operations.Nothing;
                PreviousValue = 0;              
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.ShowSpace.TextLength >= 1)
            {
                this.ShowSpace.Text = this.ShowSpace.Text.Substring(0, this.ShowSpace.TextLength - 1);
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            this.ShowSpace.Text = "";
            CurrentOperation = Operations.Nothing;
            PreviousValue = 0;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.ShowSpace.Text))
            {
                MessageBox.Show("PLS enter your Number");
                return;
            }

            if (CurrentOperation == Operations.Nothing)
            {
                PreviousValue = double.Parse(this.ShowSpace.Text);
                CurrentOperation = Operations.Plus;
                this.ShowSpace.Text = "+";
            }
            else
            {
                switch (CurrentOperation)
                {
                    case Operations.Plus:
                        PreviousValue += double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Minus:
                        PreviousValue -= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Multiply:
                        PreviousValue *= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Divide:
                        if (double.Parse(this.ShowSpace.Text) == 0)
                        {
                            this.ShowSpace.Text = "ERROR";
                            this.buttonClearAll_Click(sender, e);
                        }

                        PreviousValue /= double.Parse(this.ShowSpace.Text);
                        break;
                }

                this.ShowSpace.Text = "+";
                CurrentOperation = Operations.Plus;
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.ShowSpace.Text))
            {
                MessageBox.Show("PLS enter your Number");
                return;
            }

            if (CurrentOperation == Operations.Nothing)
            {
                PreviousValue = double.Parse(this.ShowSpace.Text);
                CurrentOperation = Operations.Minus;
                this.ShowSpace.Text = "-";
            }
            else
            {
                switch (CurrentOperation)
                {
                    case Operations.Plus:
                        PreviousValue += double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Minus:
                        PreviousValue -= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Multiply:
                        PreviousValue *= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Divide:
                        if (double.Parse(this.ShowSpace.Text) == 0)
                        {
                            this.ShowSpace.Text = "ERROR";
                            this.buttonClearAll_Click(sender, e);
                        }

                        PreviousValue /= double.Parse(this.ShowSpace.Text);
                        break;
                }

                this.ShowSpace.Text = "-";
                CurrentOperation = Operations.Minus;
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.ShowSpace.Text))
            {
                MessageBox.Show("PLS enter your Number");
                return;
            }

            if (CurrentOperation == Operations.Nothing)
            {
                PreviousValue = double.Parse(this.ShowSpace.Text);
                CurrentOperation = Operations.Multiply;
                this.ShowSpace.Text = "*";
            }
            else
            {
                switch (CurrentOperation)
                {
                    case Operations.Plus:
                        PreviousValue += double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Minus:
                        PreviousValue -= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Multiply:
                        PreviousValue *= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Divide:
                        if (double.Parse(this.ShowSpace.Text) == 0)
                        {
                            this.ShowSpace.Text = "ERROR";
                            this.buttonClearAll_Click(sender, e);
                        }

                        PreviousValue /= double.Parse(this.ShowSpace.Text);
                        break;
                }

                this.ShowSpace.Text = "*";
                CurrentOperation = Operations.Multiply;
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.ShowSpace.Text))
            {
                MessageBox.Show("PLS enter your Number");
                return;
            }

            if (CurrentOperation == Operations.Nothing)
            {
                PreviousValue = double.Parse(this.ShowSpace.Text);
                CurrentOperation = Operations.Divide;
                this.ShowSpace.Text = "/";
            }
            else
            {
                switch (CurrentOperation)
                {
                    case Operations.Plus:
                        PreviousValue += double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Minus:
                        PreviousValue -= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Multiply:
                        PreviousValue *= double.Parse(this.ShowSpace.Text);
                        break;

                    case Operations.Divide:
                        if (double.Parse(this.ShowSpace.Text) == 0)
                        {
                            this.ShowSpace.Text = "ERROR";
                            this.buttonClearAll_Click(sender, e);
                        }

                        PreviousValue /= double.Parse(this.ShowSpace.Text);
                        break;
                }

                this.ShowSpace.Text = "/";
                CurrentOperation = Operations.Divide;
            }
        }
    }
}
