using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron0
{
    public partial class Form1 : Form
    {
        double w0, w1;
        double bias;
        double LR = 0.1;
        int epochs = 100;
        int[,] inputs;
        int[] outputs;
        Random rand = new Random();

        private void trainButton_Click(object sender, EventArgs e)
        {
            //iterate through the epochs
            for (int a = 0; a < epochs; a++)
            {
                //iterate through the inputs
                for (int b = 0; b < inputs.GetLength(0); b++) //inputs.GetLength(0) has a length of 4 because we have 4 training data
                {
                    double y_temp = inputs[b, 0] * w0 + inputs[b, 1] * w1 + bias;
                    int y_calc = (y_temp > 0) ? 1 : 0; //if y_temp is positive, then y_calc is 1, else 0
                    int delta = outputs[b] - y_calc; //compare the desired output vs calculated output
                    if (delta != 0) //if desired output is not equal to calculated output, then we modify the weights
                    {
                        w0 += LR * delta * inputs[b, 0];
                        w1 += LR * delta * inputs[b, 1];
                        bias += LR * delta;
                    }
                }
            }
            MessageBox.Show("Training done after " + epochs + " epochs...");
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                //convert the input string to int
                int x1 = int.Parse(x1Input.Text);
                int x2 = int.Parse(x2Input.Text);
                //calculate the y_temp based from the trained weights
                double y_temp = x1 * w0 + x2 * w1 + bias;
                int y_calc = (y_temp > 0) ? 1 : 0;
                MessageBox.Show("Results is: " + y_calc);
            }
            catch (Exception err)
            {
                MessageBox.Show("Inputs can only be 1 or 0...", "Check your inputs!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Form1()
        {
            InitializeComponent();

            //initialize the training inputs
            inputs = new int[,]
            {
                { 0, 0 },
                { 0, 1 },
                { 1, 0 },
                { 1, 1 },
            };
            //initialize the training outputs
            outputs = new int[]
            {
                0,
                0,
                0,
                1,
            };

            //initialize weights and bias to random number
            w0 = rand.NextDouble();
            w1 = rand.NextDouble();
            bias = rand.NextDouble();
        }

    }
}
