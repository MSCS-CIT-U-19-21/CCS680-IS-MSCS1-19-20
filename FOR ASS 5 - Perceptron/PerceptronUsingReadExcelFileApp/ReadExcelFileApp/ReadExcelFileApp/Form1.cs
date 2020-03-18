using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReadExcelFileApp
{
    public partial class Form1 : Form
    {
        int[,] inputs = new int[3, 3];
        int[,] inputs_2 = new int[3, 1000];
        
        double LR = 0.1;
        int epochs = 500;
        double[,] weights;
        double[] biases;
        int[,] outputs;
        int num_data, input_length, output_length;
        int padding_to_binary = 32;
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();//open dialog to choose file
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)//if there is a file choosen by the user
            {
                filePath = file.FileName;//get the path of the file
                fileExt = Path.GetExtension(filePath);//get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt);//read excel file
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dtExcel;

                   
                        for (int i = 0; i <= 2; i++)
                        {
                            string[] arrray = dtExcel.Rows.OfType<DataRow>().Select(k => k[i].ToString()).ToArray();

                            for (int j = 0; j < arrray.Length; j++)
                            {
                                inputs_2[i, j] = Int32.Parse(arrray[j]);
                            }
                        }

                        //label1.Text = inputs_2[0, 0].ToString();
                        //label2.Text = inputs_2[0, 1].ToString();
                        //label3.Text = inputs_2[0, 2].ToString();

                        // Int32.Parse(arrray[j]);
                        // MATRICES TRANSPOSE
                        for (int i = 0; i <= 2; i++)
                        {
                            string[] arrray = dtExcel.Rows.OfType<DataRow>().Select(k => k[i].ToString()).ToArray();

                            for (int j = 0; j < arrray.Length; j++)
                            {
                                //   inputs_t[i, j] = inputs[j, i];
                                //   inputs_tt[j] = inputs_2[j, i];

                                inputs[i, j] = inputs_2[j, i];

                              //  inputs[i, j] = Int32.Parse(inputs_2[j, i]);
                            }
                         //   inputs_t[i] = String.Join(",", inputs_tt);
                        }

                        //label1.Text = inputs[2, 0].ToString();
                        //label2.Text = inputs[2, 1].ToString();
                        //label3.Text = inputs[2, 2].ToString();
          

                        //      label1.Text = inputs_t[0];
                        //label1.Text = inputs_t[1, 0].ToString();
                        //label2.Text = inputs_t[1, 1].ToString();
                        //label3.Text = inputs_t[1, 2].ToString();

                        //label1.Text = inputs[0, 0].ToString();
                        //label2.Text = inputs[1, 0].ToString();
                        //label3.Text = inputs[2, 0].ToString();
                        //label4.Text = inputs[0, 1].ToString();
                        //label5.Text = inputs[1, 1].ToString();
                        //label6.Text = inputs[2, 1].ToString();

            //            inputs = new int[,] {
            //    /*{0, 0},
            //    {0, 1},
            //    {1, 0},
            //    {1, 1},*/
            //    {10, 12000, 90 },
            //    {15, 10000, 85 },
            //    {14, 15000, 98 },

            //};
                        //put the random training data to the inputs and outputs

                        //convert int inputs to binary
                        //perceptrons performs better when inputs are 0 or 1
                        int new_length_per_input = padding_to_binary * inputs.GetLength(1);
                        int[,] new_inputs = new int[inputs.GetLength(0), new_length_per_input];
                        for (int x = 0; x < inputs.GetLength(0); x++)
                        {
                            //create a temporary array with size padding x number_of_items
                            int[] temp_converted = new int[new_length_per_input];
                            for (int y = 0; y < inputs.GetLength(1); y++)
                            {
                                intToBinaryArray(inputs[x, y], padding_to_binary).CopyTo(temp_converted, padding_to_binary * y);
                            }
                            //insert the new binary array to the new_inputs variable
                            for (int y = 0; y < new_length_per_input; y++)
                            {
                                new_inputs[x, y] = temp_converted[y];
                            }
                        }
                        inputs = new_inputs;

                        outputs = new int[,] {
                /*{0,1},
                {0,1},
                {0,1},
                {1,0},*/
                {0,0,1},
                {0,1,0},
                {1,0,0},
            
            };

                        //determine the length of input and output
                        num_data = inputs.GetLength(0);
                        input_length = inputs.GetLength(1);
                        output_length = outputs.GetLength(1);

                        //initialize random weights
                        weights = new double[output_length, input_length];
                        for (int x = 0; x < output_length; x++)
                        {
                            for (int y = 0; y < input_length; y++)
                            {
                                weights[x, y] = rand.NextDouble();
                            }
                        }

                        //initialize random biases
                        biases = new double[output_length];
                        for (int x = 0; x < output_length; x++)
                        {
                            biases[x] = rand.NextDouble();
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);//custom messageBox to show error
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();//to close the window(Form1)
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)//compare the extension of the file
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con);//here we read data from sheet1
                    oleAdpt.Fill(dtexcel);//fill excel data into dataTable
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            return dtexcel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int error, selected_item_index;
            //iterate through the epochs
            for (int a = 0; a <= epochs; a++)
            {
                string log = "", log_desired, log_calculated;
                //count the error every epoch
                error = 0;
                //iterate through the training data
                for (int b = 0; b < num_data; b++)
                {
                    //selected_item_index = rand.Next(num_data);
                    selected_item_index = b;
                    log_desired = "";
                    log_calculated = "";
                    //iterate through the outputs
                    for (int c = 0; c < output_length; c++)
                    {
                        double temp_y = 0;
                        //iterate through an input
                        for (int d = 0; d < input_length; d++)
                        {
                            temp_y += inputs[selected_item_index, d] * weights[c, d];
                        }
                        temp_y += biases[c];
                        //check if temp_y is positive or negative
                        int y_calc = (temp_y > 0) ? 1 : 0;
                        //delta is the difference between the calculated and the desired output
                        int delta = outputs[selected_item_index, c] - y_calc;
                        log_desired += outputs[selected_item_index, c] + " ";
                        log_calculated += y_calc + " ";
                        //if there is a difference between calculated and expected output
                        //then we retrain the weights and biases
                        if (delta != 0)
                        {
                            for (int d = 0; d < input_length; d++)
                            {
                                weights[c, d] += LR * delta * inputs[selected_item_index, d];
                            }
                            biases[c] += LR * delta;
                            error++; //increment the error count if the desired is different from the calculated
                        }
                    }
                    log += ("Input: " + inputs[selected_item_index, 0] + " " + inputs[selected_item_index, 1] + "\nDesired: " + log_desired + "\nCalculated: " + log_calculated + "\n\n");
                }
                printWeightsAndBiases(a, error, log);
                Application.DoEvents(); //to refresh the window
                /*if (error==0) //stop training if there are no errors
                {
                    a = epochs + 1;
                }*/
            }

        }

        private void testButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //get the input and then split it to an array by comma
            string test_input = testInput.Text;
            string[] test_input_arr = test_input.Split(',');
            int[] temp_converted = new int[input_length];
            //put the numbers into the integer array
            for (int x = 0; x < input_length / padding_to_binary; x++)
            {
                intToBinaryArray(int.Parse(test_input_arr[x]), padding_to_binary).CopyTo(temp_converted, padding_to_binary * x);
            }
            //calculate the output of this input
            string output = "";
            for (int a = 0; a < output_length; a++)
            {
                double temp_y = 0;
                for (int b = 0; b < input_length; b++)
                {
                    temp_y += temp_converted[b] * weights[a, b];
                }
                temp_y += biases[a];
                int temp_calc = (temp_y > 0) ? 1 : 0;
                output += temp_calc + " ";
            }
            outputText.Text = "Output: " + output;
            /*}
            catch (Exception err)
            {
                MessageBox.Show("Please check your input...");
            }*/
        }

        public void printWeightsAndBiases(int current_epochs, int errors, string log)
        {
            String output = "";
            output += "Epochs: " + current_epochs;
            output += "\nErrors: " + errors + "\n\n";
            for (int x = 0; x < output_length; x++)
            {
                for (int y = 0; y < input_length; y++)
                {
                    output += "W[" + x + "," + y + "]: " + weights[x, y] + "\n";
                }
                output += "B[" + x + "]: " + biases[x] + "\n";
                output += "\n";
            }
            weightsBiasesText.Text = output + "\n\n\n" + log;
        }

        //converts an int to binary array
        //for example 5 will become 00000000000000000000000000000101 (32 digits) where 32 is the padding_to_binary
        public int[] intToBinaryArray(int item, int padding)
        {
            string s = Convert.ToString(item, 2); //Convert to binary in a string

            int[] bits = s.PadLeft(padding, '0') // Add 0's from left
                         .Select(c => int.Parse(c.ToString())) // convert each char to int
                         .ToArray(); // Convert IEnumerable from select to Array
            //MessageBox.Show("Item: " + item + "\nLength: " + bits.Length);
            return bits;
        }

    }
}
