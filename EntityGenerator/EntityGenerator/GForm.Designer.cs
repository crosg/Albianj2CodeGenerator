namespace EntityGenerator
{
    partial class GForm
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
            this.tv = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tbinterface = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbclass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSpe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbdrouter = new System.Windows.Forms.TextBox();
            this.tbsif = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbscl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Location = new System.Drawing.Point(30, 64);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(180, 452);
            this.tv.TabIndex = 0;
            this.tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(854, 597);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "生成代码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 645);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "代码生成路径：";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(225, 642);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(587, 21);
            this.tbPath.TabIndex = 4;
            this.tbPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(225, 64);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(735, 452);
            this.dgv.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "表列表：";
            // 
            // tbinterface
            // 
            this.tbinterface.Location = new System.Drawing.Point(225, 558);
            this.tbinterface.Name = "tbinterface";
            this.tbinterface.Size = new System.Drawing.Size(235, 21);
            this.tbinterface.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(476, 561);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "实体类包名：";
            // 
            // tbclass
            // 
            this.tbclass.Location = new System.Drawing.Point(577, 558);
            this.tbclass.Name = "tbclass";
            this.tbclass.Size = new System.Drawing.Size(235, 21);
            this.tbclass.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 561);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "实体接口包名：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 532);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "数据库表名分隔符：";
            // 
            // tbSpe
            // 
            this.tbSpe.Location = new System.Drawing.Point(225, 529);
            this.tbSpe.Name = "tbSpe";
            this.tbSpe.Size = new System.Drawing.Size(94, 21);
            this.tbSpe.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 618);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "数据路由包名：";
            // 
            // tbdrouter
            // 
            this.tbdrouter.Location = new System.Drawing.Point(225, 615);
            this.tbdrouter.Name = "tbdrouter";
            this.tbdrouter.Size = new System.Drawing.Size(587, 21);
            this.tbdrouter.TabIndex = 17;
            // 
            // tbsif
            // 
            this.tbsif.Location = new System.Drawing.Point(225, 585);
            this.tbsif.Name = "tbsif";
            this.tbsif.Size = new System.Drawing.Size(235, 21);
            this.tbsif.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(476, 588);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "service类包名：";
            // 
            // tbscl
            // 
            this.tbscl.Location = new System.Drawing.Point(577, 585);
            this.tbscl.Name = "tbscl";
            this.tbscl.Size = new System.Drawing.Size(235, 21);
            this.tbscl.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 588);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "service接口包名：";
            // 
            // GForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 679);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbscl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbsif);
            this.Controls.Add(this.tbdrouter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbSpe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbclass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbinterface);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tv);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1017, 717);
            this.MinimumSize = new System.Drawing.Size(1017, 717);
            this.Name = "GForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbinterface;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbclass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSpe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbdrouter;
        private System.Windows.Forms.TextBox tbsif;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbscl;
        private System.Windows.Forms.Label label8;
    }
}