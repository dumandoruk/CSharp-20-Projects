namespace Project5_DapperNorthwind
{
    partial class FrmStatistics
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCategoryCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMaxPriceProduct = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMinStockProduct = new System.Windows.Forms.Label();
            this.btnOpenProduct = new System.Windows.Forms.Button();
            this.btnOpenCategory = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(211)))));
            this.panel1.Controls.Add(this.lblCategoryCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(42, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 146);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(176)))), ((int)(((byte)(144)))));
            this.panel2.Controls.Add(this.lblProductCount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(293, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 146);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(28)))), ((int)(((byte)(106)))));
            this.panel3.Controls.Add(this.lblMinStockProduct);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(293, 324);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 146);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(89)))), ((int)(((byte)(149)))));
            this.panel4.Controls.Add(this.lblMaxPriceProduct);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(42, 324);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(198, 146);
            this.panel4.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Category";
            // 
            // lblCategoryCount
            // 
            this.lblCategoryCount.AutoSize = true;
            this.lblCategoryCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCategoryCount.Location = new System.Drawing.Point(90, 87);
            this.lblCategoryCount.Name = "lblCategoryCount";
            this.lblCategoryCount.Size = new System.Drawing.Size(23, 25);
            this.lblCategoryCount.TabIndex = 1;
            this.lblCategoryCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Product";
            // 
            // lblProductCount
            // 
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProductCount.Location = new System.Drawing.Point(87, 87);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(23, 25);
            this.lblProductCount.TabIndex = 1;
            this.lblProductCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(14, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Max Price Product";
            // 
            // lblMaxPriceProduct
            // 
            this.lblMaxPriceProduct.AutoSize = true;
            this.lblMaxPriceProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMaxPriceProduct.Location = new System.Drawing.Point(14, 92);
            this.lblMaxPriceProduct.Name = "lblMaxPriceProduct";
            this.lblMaxPriceProduct.Size = new System.Drawing.Size(64, 25);
            this.lblMaxPriceProduct.TabIndex = 1;
            this.lblMaxPriceProduct.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Snow;
            this.label7.Location = new System.Drawing.Point(16, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Min Stock Product";
            // 
            // lblMinStockProduct
            // 
            this.lblMinStockProduct.AutoSize = true;
            this.lblMinStockProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMinStockProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMinStockProduct.Location = new System.Drawing.Point(16, 92);
            this.lblMinStockProduct.Name = "lblMinStockProduct";
            this.lblMinStockProduct.Size = new System.Drawing.Size(64, 25);
            this.lblMinStockProduct.TabIndex = 1;
            this.lblMinStockProduct.Text = "label8";
            // 
            // btnOpenProduct
            // 
            this.btnOpenProduct.Location = new System.Drawing.Point(42, 39);
            this.btnOpenProduct.Name = "btnOpenProduct";
            this.btnOpenProduct.Size = new System.Drawing.Size(198, 37);
            this.btnOpenProduct.TabIndex = 4;
            this.btnOpenProduct.Text = "Product Panel";
            this.btnOpenProduct.UseVisualStyleBackColor = true;
            this.btnOpenProduct.Click += new System.EventHandler(this.btnOpenProduct_Click);
            // 
            // btnOpenCategory
            // 
            this.btnOpenCategory.Location = new System.Drawing.Point(293, 39);
            this.btnOpenCategory.Name = "btnOpenCategory";
            this.btnOpenCategory.Size = new System.Drawing.Size(198, 37);
            this.btnOpenCategory.TabIndex = 5;
            this.btnOpenCategory.Text = "Category Panel";
            this.btnOpenCategory.UseVisualStyleBackColor = true;
            this.btnOpenCategory.Click += new System.EventHandler(this.btnOpenCategory_Click);
            // 
            // FrmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 520);
            this.Controls.Add(this.btnOpenCategory);
            this.Controls.Add(this.btnOpenProduct);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "FrmStatistics";
            this.Text = "FrmStatistics";
            this.Load += new System.EventHandler(this.FrmStatistics_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCategoryCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMinStockProduct;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblMaxPriceProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpenProduct;
        private System.Windows.Forms.Button btnOpenCategory;
    }
}