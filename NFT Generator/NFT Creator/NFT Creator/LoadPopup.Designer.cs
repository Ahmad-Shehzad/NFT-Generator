namespace NFT_Creator
{
    partial class LoadPopup
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
            this.databaseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // databaseName
            // 
            this.databaseName.Location = new System.Drawing.Point(126, 40);
            this.databaseName.Name = "databaseName";
            this.databaseName.Size = new System.Drawing.Size(190, 20);
            this.databaseName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Database Name:";
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(134, 139);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(76, 23);
            this.load.TabIndex = 2;
            this.load.Text = "OK";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // LoadPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 174);
            this.Controls.Add(this.load);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.databaseName);
            this.Name = "LoadPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadPopup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox databaseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button load;
    }
}