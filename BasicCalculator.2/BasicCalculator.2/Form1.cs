using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorPrivateAssembly;
using System.Windows.Forms;

namespace BasicCalculator._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add('+');
            comboBox1.Items.Add('-');
            comboBox1.Items.Add('*');
            comboBox1.Items.Add('/');
            comboBox1.SelectedIndex = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float num1, num2;
            if (!float.TryParse(textBox1.Text, out num1) || !float.TryParse(textBox2.Text, out num2))
            {
                label2.Text = "Invalid input. Please enter numbers.";
                return;
            }

            // Determine the selected operation
            string operation = comboBox1.SelectedItem.ToString();
            try
            {
                float result = 0;
                switch (operation)
                {
                    case "+":
                        result = BasicComputation.Add(num1, num2);
                        break;
                    case "-":
                        result = BasicComputation.Subtract(num1, num2);
                        break;
                    case "*":
                        result = BasicComputation.Multiply(num1, num2);
                        break;
                    case "/":
                        result = BasicComputation.Divide(num1, num2);
                        break;
                    default:
                        label2.Text = "Please select an operation.";
                        return;
                }
                label2.Text = $"{result}";
            }
            catch (DivideByZeroException ex)
            {
                label2.Text = ex.Message;

            }
        }
    
    }
}
