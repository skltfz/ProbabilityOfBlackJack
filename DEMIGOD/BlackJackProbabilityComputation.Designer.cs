namespace DEMIGOD
{
    partial class BlackJackProbabilityComputation
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
            this.truth_RB = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.voice_B = new System.Windows.Forms.TextBox();
            this.fact_B = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // truth_RB
            // 
            this.truth_RB.Location = new System.Drawing.Point(301, 12);
            this.truth_RB.Name = "truth_RB";
            this.truth_RB.Size = new System.Drawing.Size(564, 506);
            this.truth_RB.TabIndex = 0;
            this.truth_RB.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "God Voice";
            // 
            // voice_B
            // 
            this.voice_B.Location = new System.Drawing.Point(12, 67);
            this.voice_B.Name = "voice_B";
            this.voice_B.Size = new System.Drawing.Size(100, 22);
            this.voice_B.TabIndex = 3;
            // 
            // fact_B
            // 
            this.fact_B.Location = new System.Drawing.Point(12, 297);
            this.fact_B.Name = "fact_B";
            this.fact_B.Size = new System.Drawing.Size(283, 22);
            this.fact_B.TabIndex = 4;
            // 
            // BlackJackProbabilityComputation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 530);
            this.Controls.Add(this.fact_B);
            this.Controls.Add(this.voice_B);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.truth_RB);
            this.Name = "BlackJackProbabilityComputation";
            this.Text = "BlackJackProbabilityComputation";
            this.Load += new System.EventHandler(this.BlackJackProbabilityComputation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox truth_RB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox voice_B;
        private System.Windows.Forms.TextBox fact_B;
    }
}