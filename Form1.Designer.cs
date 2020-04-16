namespace ExpenseTrackApp
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
            this.transaction_button = new System.Windows.Forms.Button();
            this.category_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // transaction_button
            // 
            this.transaction_button.Location = new System.Drawing.Point(25, 57);
            this.transaction_button.Name = "transaction_button";
            this.transaction_button.Size = new System.Drawing.Size(151, 34);
            this.transaction_button.TabIndex = 0;
            this.transaction_button.Text = "View Transactions";
            this.transaction_button.UseVisualStyleBackColor = true;
            this.transaction_button.Click += new System.EventHandler(this.transaction_button_Click);
            // 
            // category_button
            // 
            this.category_button.Location = new System.Drawing.Point(25, 131);
            this.category_button.Name = "category_button";
            this.category_button.Size = new System.Drawing.Size(151, 34);
            this.category_button.TabIndex = 1;
            this.category_button.Text = "View Categories";
            this.category_button.UseVisualStyleBackColor = true;
            this.category_button.Click += new System.EventHandler(this.category_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "View Summary";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "View Predictions";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ExpenseTrackApp.Properties.Resources.main;
            this.pictureBox1.Location = new System.Drawing.Point(222, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(520, 373);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.category_button);
            this.Controls.Add(this.transaction_button);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button transaction_button;
        private System.Windows.Forms.Button category_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

