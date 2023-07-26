namespace LiveCart
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
            this.solidGauge1 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge2 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge3 = new LiveCharts.WinForms.SolidGauge();
            this.solidGauge4 = new LiveCharts.WinForms.SolidGauge();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // solidGauge1
            // 
            this.solidGauge1.Location = new System.Drawing.Point(95, 95);
            this.solidGauge1.Name = "solidGauge1";
            this.solidGauge1.Size = new System.Drawing.Size(200, 100);
            this.solidGauge1.TabIndex = 0;
            this.solidGauge1.Text = "solidGauge1";
            // 
            // solidGauge2
            // 
            this.solidGauge2.Location = new System.Drawing.Point(400, 319);
            this.solidGauge2.Name = "solidGauge2";
            this.solidGauge2.Size = new System.Drawing.Size(200, 100);
            this.solidGauge2.TabIndex = 1;
            this.solidGauge2.Text = "solidGauge2";
            // 
            // solidGauge3
            // 
            this.solidGauge3.Location = new System.Drawing.Point(95, 319);
            this.solidGauge3.Name = "solidGauge3";
            this.solidGauge3.Size = new System.Drawing.Size(200, 100);
            this.solidGauge3.TabIndex = 2;
            this.solidGauge3.Text = "solidGauge3";
            // 
            // solidGauge4
            // 
            this.solidGauge4.Location = new System.Drawing.Point(400, 95);
            this.solidGauge4.Name = "solidGauge4";
            this.solidGauge4.Size = new System.Drawing.Size(200, 100);
            this.solidGauge4.TabIndex = 3;
            this.solidGauge4.Text = "solidGauge4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(159)))));
            this.label1.Location = new System.Drawing.Point(251, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "C# Tube";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(766, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.solidGauge4);
            this.Controls.Add(this.solidGauge3);
            this.Controls.Add(this.solidGauge2);
            this.Controls.Add(this.solidGauge1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.SolidGauge solidGauge1;
        private LiveCharts.WinForms.SolidGauge solidGauge2;
        private LiveCharts.WinForms.SolidGauge solidGauge3;
        private LiveCharts.WinForms.SolidGauge solidGauge4;
        private System.Windows.Forms.Label label1;
    }
}

