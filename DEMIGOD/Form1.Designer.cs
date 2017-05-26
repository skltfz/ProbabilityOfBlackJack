namespace DEMIGOD
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
            this.output_RB = new System.Windows.Forms.RichTextBox();
            this.input_RB = new System.Windows.Forms.RichTextBox();
            this.this_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // output_RB
            // 
            this.output_RB.Location = new System.Drawing.Point(489, 12);
            this.output_RB.Name = "output_RB";
            this.output_RB.Size = new System.Drawing.Size(340, 435);
            this.output_RB.TabIndex = 0;
            this.output_RB.Text = "";
            // 
            // input_RB
            // 
            this.input_RB.Location = new System.Drawing.Point(12, 12);
            this.input_RB.Name = "input_RB";
            this.input_RB.Size = new System.Drawing.Size(340, 435);
            this.input_RB.TabIndex = 1;
            this.input_RB.Text = "";
            this.input_RB.TextChanged += new System.EventHandler(this.input_RB_TextChanged);
            // 
            // this_Btn
            // 
            this.this_Btn.Location = new System.Drawing.Point(358, 424);
            this.this_Btn.Name = "this_Btn";
            this.this_Btn.Size = new System.Drawing.Size(75, 23);
            this.this_Btn.TabIndex = 2;
            this.this_Btn.Text = "This";
            this.this_Btn.UseVisualStyleBackColor = true;
            this.this_Btn.Click += new System.EventHandler(this.this_Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 459);
            this.Controls.Add(this.this_Btn);
            this.Controls.Add(this.input_RB);
            this.Controls.Add(this.output_RB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox output_RB;
        private System.Windows.Forms.RichTextBox input_RB;
        private System.Windows.Forms.Button this_Btn;
    }
}

