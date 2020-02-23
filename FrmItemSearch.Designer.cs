namespace ExamSystem
{
    partial class FrmItemSearch
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
            this.lblAnswer2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTypeName2 = new System.Windows.Forms.Label();
            this.lblAnswer1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTypeName1 = new System.Windows.Forms.Label();
            this.txtDisp2 = new System.Windows.Forms.TextBox();
            this.txtDisp1 = new System.Windows.Forms.TextBox();
            this.txtKeyValue = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAnswer2
            // 
            this.lblAnswer2.AutoSize = true;
            this.lblAnswer2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAnswer2.Location = new System.Drawing.Point(524, 128);
            this.lblAnswer2.Name = "lblAnswer2";
            this.lblAnswer2.Size = new System.Drawing.Size(56, 16);
            this.lblAnswer2.TabIndex = 20;
            this.lblAnswer2.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(475, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "答案：";
            // 
            // lblTypeName2
            // 
            this.lblTypeName2.AutoSize = true;
            this.lblTypeName2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTypeName2.Location = new System.Drawing.Point(401, 128);
            this.lblTypeName2.Name = "lblTypeName2";
            this.lblTypeName2.Size = new System.Drawing.Size(56, 16);
            this.lblTypeName2.TabIndex = 18;
            this.lblTypeName2.Text = "label1";
            // 
            // lblAnswer1
            // 
            this.lblAnswer1.AutoSize = true;
            this.lblAnswer1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAnswer1.Location = new System.Drawing.Point(162, 128);
            this.lblAnswer1.Name = "lblAnswer1";
            this.lblAnswer1.Size = new System.Drawing.Size(56, 16);
            this.lblAnswer1.TabIndex = 17;
            this.lblAnswer1.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(113, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "答案：";
            // 
            // lblTypeName1
            // 
            this.lblTypeName1.AutoSize = true;
            this.lblTypeName1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTypeName1.Location = new System.Drawing.Point(39, 128);
            this.lblTypeName1.Name = "lblTypeName1";
            this.lblTypeName1.Size = new System.Drawing.Size(56, 16);
            this.lblTypeName1.TabIndex = 15;
            this.lblTypeName1.Text = "label1";
            // 
            // txtDisp2
            // 
            this.txtDisp2.Location = new System.Drawing.Point(399, 148);
            this.txtDisp2.Multiline = true;
            this.txtDisp2.Name = "txtDisp2";
            this.txtDisp2.Size = new System.Drawing.Size(337, 278);
            this.txtDisp2.TabIndex = 14;
            // 
            // txtDisp1
            // 
            this.txtDisp1.Location = new System.Drawing.Point(44, 148);
            this.txtDisp1.Multiline = true;
            this.txtDisp1.Name = "txtDisp1";
            this.txtDisp1.Size = new System.Drawing.Size(317, 278);
            this.txtDisp1.TabIndex = 13;
            // 
            // txtKeyValue
            // 
            this.txtKeyValue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeyValue.Location = new System.Drawing.Point(147, 22);
            this.txtKeyValue.Multiline = true;
            this.txtKeyValue.Name = "txtKeyValue";
            this.txtKeyValue.Size = new System.Drawing.Size(589, 81);
            this.txtKeyValue.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(41, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 29);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 464);
            this.Controls.Add(this.lblAnswer2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTypeName2);
            this.Controls.Add(this.lblAnswer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTypeName1);
            this.Controls.Add(this.txtDisp2);
            this.Controls.Add(this.txtDisp1);
            this.Controls.Add(this.txtKeyValue);
            this.Controls.Add(this.btnSearch);
            this.Name = "FrmItemSearch";
            this.Text = "搜题";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnswer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTypeName2;
        private System.Windows.Forms.Label lblAnswer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTypeName1;
        private System.Windows.Forms.TextBox txtDisp2;
        private System.Windows.Forms.TextBox txtDisp1;
        private System.Windows.Forms.TextBox txtKeyValue;
        private System.Windows.Forms.Button btnSearch;
    }
}