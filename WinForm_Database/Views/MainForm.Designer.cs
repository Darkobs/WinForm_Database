namespace WinForm_Database
{
    partial class MainForm
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
            this.btnReadExcel = new System.Windows.Forms.Button();
            this.btnSaveToSQLite = new System.Windows.Forms.Button();
            this.btnSaveToParquet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadExcel
            // 
            this.btnReadExcel.Location = new System.Drawing.Point(12, 28);
            this.btnReadExcel.Name = "btnReadExcel";
            this.btnReadExcel.Size = new System.Drawing.Size(75, 23);
            this.btnReadExcel.TabIndex = 0;
            this.btnReadExcel.Text = "Read Data";
            this.btnReadExcel.UseVisualStyleBackColor = true;
            this.btnReadExcel.Click += new System.EventHandler(this.btnReadExcel_Click);
            // 
            // btnSaveToSQLite
            // 
            this.btnSaveToSQLite.Location = new System.Drawing.Point(12, 71);
            this.btnSaveToSQLite.Name = "btnSaveToSQLite";
            this.btnSaveToSQLite.Size = new System.Drawing.Size(130, 23);
            this.btnSaveToSQLite.TabIndex = 1;
            this.btnSaveToSQLite.Text = "Save Data into SQLite";
            this.btnSaveToSQLite.UseVisualStyleBackColor = true;
            this.btnSaveToSQLite.Click += new System.EventHandler(this.btnSaveToSQLite_Click);
            // 
            // btnSaveToParquet
            // 
            this.btnSaveToParquet.Location = new System.Drawing.Point(13, 113);
            this.btnSaveToParquet.Name = "btnSaveToParquet";
            this.btnSaveToParquet.Size = new System.Drawing.Size(129, 23);
            this.btnSaveToParquet.TabIndex = 2;
            this.btnSaveToParquet.Text = "Save Data into Parquet";
            this.btnSaveToParquet.UseVisualStyleBackColor = true;
            this.btnSaveToParquet.Click += new System.EventHandler(this.btnSaveToParquet_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 353);
            this.Controls.Add(this.btnSaveToParquet);
            this.Controls.Add(this.btnSaveToSQLite);
            this.Controls.Add(this.btnReadExcel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReadExcel;
        private System.Windows.Forms.Button btnSaveToSQLite;
        private System.Windows.Forms.Button btnSaveToParquet;
    }
}

