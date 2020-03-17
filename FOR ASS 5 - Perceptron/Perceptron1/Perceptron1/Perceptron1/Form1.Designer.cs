namespace Perceptron1
{
    partial class Form1
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
            this.trainButton = new System.Windows.Forms.Button();
            this.weightsBiasesText = new System.Windows.Forms.RichTextBox();
            this.testInput = new System.Windows.Forms.TextBox();
            this.testButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trainButton
            // 
            this.trainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainButton.Location = new System.Drawing.Point(13, 13);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(405, 57);
            this.trainButton.TabIndex = 0;
            this.trainButton.Text = "TRAIN";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // weightsBiasesText
            // 
            this.weightsBiasesText.Location = new System.Drawing.Point(444, 13);
            this.weightsBiasesText.Name = "weightsBiasesText";
            this.weightsBiasesText.Size = new System.Drawing.Size(557, 382);
            this.weightsBiasesText.TabIndex = 1;
            this.weightsBiasesText.Text = "";
            // 
            // testInput
            // 
            this.testInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testInput.Location = new System.Drawing.Point(13, 216);
            this.testInput.Name = "testInput";
            this.testInput.Size = new System.Drawing.Size(405, 44);
            this.testInput.TabIndex = 2;
            // 
            // testButton
            // 
            this.testButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testButton.Location = new System.Drawing.Point(13, 280);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(405, 59);
            this.testButton.TabIndex = 3;
            this.testButton.Text = "TEST";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // outputText
            // 
            this.outputText.AutoSize = true;
            this.outputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.Location = new System.Drawing.Point(13, 358);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(123, 37);
            this.outputText.TabIndex = 4;
            this.outputText.Text = "Output:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input Format: Age,Salary,Grade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Example: 21,50000,50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "This should output 010";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 408);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.testInput);
            this.Controls.Add(this.weightsBiasesText);
            this.Controls.Add(this.trainButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perceptron";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.RichTextBox weightsBiasesText;
        private System.Windows.Forms.TextBox testInput;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label outputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

