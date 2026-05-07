namespace Project8_RapidApiCurrency
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
            this.lblDollar = new System.Windows.Forms.Label();
            this.rbUSD = new System.Windows.Forms.RadioButton();
            this.rbEUR = new System.Windows.Forms.RadioButton();
            this.rbGBP = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnitAmount = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnCalculateClick = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEuro = new System.Windows.Forms.Label();
            this.lblGBP = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDollar
            // 
            this.lblDollar.AutoSize = true;
            this.lblDollar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDollar.Location = new System.Drawing.Point(26, 53);
            this.lblDollar.Name = "lblDollar";
            this.lblDollar.Size = new System.Drawing.Size(62, 25);
            this.lblDollar.TabIndex = 1;
            this.lblDollar.Text = "Dollar";
            // 
            // rbUSD
            // 
            this.rbUSD.AutoSize = true;
            this.rbUSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbUSD.Location = new System.Drawing.Point(105, 174);
            this.rbUSD.Name = "rbUSD";
            this.rbUSD.Size = new System.Drawing.Size(75, 29);
            this.rbUSD.TabIndex = 2;
            this.rbUSD.TabStop = true;
            this.rbUSD.Text = "USD";
            this.rbUSD.UseVisualStyleBackColor = true;
            // 
            // rbEUR
            // 
            this.rbEUR.AutoSize = true;
            this.rbEUR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbEUR.Location = new System.Drawing.Point(316, 174);
            this.rbEUR.Name = "rbEUR";
            this.rbEUR.Size = new System.Drawing.Size(73, 29);
            this.rbEUR.TabIndex = 3;
            this.rbEUR.TabStop = true;
            this.rbEUR.Text = "EUR";
            this.rbEUR.UseVisualStyleBackColor = true;
            // 
            // rbGBP
            // 
            this.rbGBP.AutoSize = true;
            this.rbGBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbGBP.Location = new System.Drawing.Point(515, 174);
            this.rbGBP.Name = "rbGBP";
            this.rbGBP.Size = new System.Drawing.Size(74, 29);
            this.rbGBP.TabIndex = 4;
            this.rbGBP.TabStop = true;
            this.rbGBP.Text = "GBP";
            this.rbGBP.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(135, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Birim Tutar : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(135, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ödenecek Tutar :";
            // 
            // txtUnitAmount
            // 
            this.txtUnitAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnitAmount.Location = new System.Drawing.Point(351, 234);
            this.txtUnitAmount.Name = "txtUnitAmount";
            this.txtUnitAmount.Size = new System.Drawing.Size(177, 30);
            this.txtUnitAmount.TabIndex = 7;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTotalAmount.Location = new System.Drawing.Point(351, 291);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(177, 30);
            this.txtTotalAmount.TabIndex = 8;
            // 
            // btnCalculateClick
            // 
            this.btnCalculateClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCalculateClick.Location = new System.Drawing.Point(351, 346);
            this.btnCalculateClick.Name = "btnCalculateClick";
            this.btnCalculateClick.Size = new System.Drawing.Size(177, 33);
            this.btnCalculateClick.TabIndex = 9;
            this.btnCalculateClick.Text = "İşlemi Yap";
            this.btnCalculateClick.UseVisualStyleBackColor = true;
            this.btnCalculateClick.Click += new System.EventHandler(this.btnCalculateClick_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGBP);
            this.groupBox1.Controls.Add(this.lblEuro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblDollar);
            this.groupBox1.Location = new System.Drawing.Point(92, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 125);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Döviz Sistemi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(154, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 2;
            // 
            // lblEuro
            // 
            this.lblEuro.AutoSize = true;
            this.lblEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEuro.Location = new System.Drawing.Point(219, 53);
            this.lblEuro.Name = "lblEuro";
            this.lblEuro.Size = new System.Drawing.Size(53, 25);
            this.lblEuro.TabIndex = 3;
            this.lblEuro.Text = "Euro";
            // 
            // lblGBP
            // 
            this.lblGBP.AutoSize = true;
            this.lblGBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGBP.Location = new System.Drawing.Point(394, 53);
            this.lblGBP.Name = "lblGBP";
            this.lblGBP.Size = new System.Drawing.Size(53, 25);
            this.lblGBP.TabIndex = 4;
            this.lblGBP.Text = "GBP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCalculateClick);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtUnitAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbGBP);
            this.Controls.Add(this.rbEUR);
            this.Controls.Add(this.rbUSD);
            this.Name = "Form1";
            this.Text = "W";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDollar;
        private System.Windows.Forms.RadioButton rbUSD;
        private System.Windows.Forms.RadioButton rbEUR;
        private System.Windows.Forms.RadioButton rbGBP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnCalculateClick;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEuro;
        private System.Windows.Forms.Label lblGBP;
    }
}

