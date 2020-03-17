namespace GeneticAlgorithm1
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
            this.start = new System.Windows.Forms.Button();
            this.populationStrings = new System.Windows.Forms.Label();
            this.generationText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(12, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(120, 45);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // populationStrings
            // 
            this.populationStrings.AutoSize = true;
            this.populationStrings.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.populationStrings.Location = new System.Drawing.Point(12, 72);
            this.populationStrings.Name = "populationStrings";
            this.populationStrings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.populationStrings.Size = new System.Drawing.Size(285, 21);
            this.populationStrings.TabIndex = 1;
            this.populationStrings.Text = "Population String Results";
            this.populationStrings.Click += new System.EventHandler(this.populationStrings_Click);
            // 
            // generationText
            // 
            this.generationText.AutoSize = true;
            this.generationText.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generationText.Location = new System.Drawing.Point(250, 72);
            this.generationText.Name = "generationText";
            this.generationText.Size = new System.Drawing.Size(153, 21);
            this.generationText.TabIndex = 4;
            this.generationText.Text = "Generation: 1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 328);
            this.Controls.Add(this.generationText);
            this.Controls.Add(this.populationStrings);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "Genetic Algorithm 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label populationStrings;
        private System.Windows.Forms.Label generationText;
    }
}

