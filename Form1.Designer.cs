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
            this.SuspendLayout();
            // 
            // transaction_button
            // 
            this.transaction_button.Location = new System.Drawing.Point(194, 12);
            this.transaction_button.Name = "transaction_button";
            this.transaction_button.Size = new System.Drawing.Size(117, 34);
            this.transaction_button.TabIndex = 0;
            this.transaction_button.Text = "Transactions";
            this.transaction_button.UseVisualStyleBackColor = true;
            this.transaction_button.Click += new System.EventHandler(this.transaction_button_Click);
            // 
            // category_button
            // 
            this.category_button.Location = new System.Drawing.Point(31, 12);
            this.category_button.Name = "category_button";
            this.category_button.Size = new System.Drawing.Size(124, 34);
            this.category_button.TabIndex = 1;
            this.category_button.Text = "Categories";
            this.category_button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.category_button);
            this.Controls.Add(this.transaction_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button transaction_button;
        private System.Windows.Forms.Button category_button;
    }
}

