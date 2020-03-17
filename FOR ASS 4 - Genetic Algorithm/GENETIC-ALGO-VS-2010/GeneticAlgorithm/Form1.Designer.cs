namespace GeneticAlgorithm
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
            this.generationText = new System.Windows.Forms.Label();
            this.next = new System.Windows.Forms.Button();
            this.populationStrings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generationText
            // 
            this.generationText.AutoSize = true;
            this.generationText.Location = new System.Drawing.Point(156, 35);
            this.generationText.Name = "generationText";
            this.generationText.Size = new System.Drawing.Size(35, 13);
            this.generationText.TabIndex = 0;
            this.generationText.Text = "label1";
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(41, 30);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 2;
            this.next.Text = "button1";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // populationStrings
            // 
            this.populationStrings.AutoSize = true;
            this.populationStrings.Location = new System.Drawing.Point(109, 118);
            this.populationStrings.Name = "populationStrings";
            this.populationStrings.Size = new System.Drawing.Size(35, 13);
            this.populationStrings.TabIndex = 3;
            this.populationStrings.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.populationStrings);
            this.Controls.Add(this.next);
            this.Controls.Add(this.generationText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label generationText;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Label populationStrings;
    }
}

