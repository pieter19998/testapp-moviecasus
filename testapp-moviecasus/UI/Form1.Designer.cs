
namespace UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.JsonButton = new System.Windows.Forms.Button();
            this.TextButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // JsonButton
            // 
            this.JsonButton.Location = new System.Drawing.Point(6, 22);
            this.JsonButton.Name = "JsonButton";
            this.JsonButton.Size = new System.Drawing.Size(59, 23);
            this.JsonButton.TabIndex = 0;
            this.JsonButton.Text = "JSON";
            this.JsonButton.UseVisualStyleBackColor = true;
            this.JsonButton.Click += new System.EventHandler(this.JsonButton_Click);
            // 
            // TextButton
            // 
            this.TextButton.Location = new System.Drawing.Point(81, 22);
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new System.Drawing.Size(75, 23);
            this.TextButton.TabIndex = 1;
            this.TextButton.Text = "Text";
            this.TextButton.UseVisualStyleBackColor = false;
            this.TextButton.Click += new System.EventHandler(this.TextButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.JsonButton);
            this.groupBox1.Controls.Add(this.TextButton);
            this.groupBox1.Location = new System.Drawing.Point(40, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 84);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Export";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button JsonButton;
        private System.Windows.Forms.Button TextButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

