
namespace NFT_Creator
{
    partial class Output
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.exitButton = new System.Windows.Forms.Button();
            this.generate = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(99, 188);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(286, 23);
            this.progressBar.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Enabled = false;
            this.exitButton.Location = new System.Drawing.Point(204, 555);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(76, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(204, 518);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(76, 23);
            this.generate.TabIndex = 3;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // progress
            // 
            this.progress.AutoSize = true;
            this.progress.Location = new System.Drawing.Point(224, 232);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(35, 13);
            this.progress.TabIndex = 4;
            this.progress.Text = "label1";
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 591);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.progressBar);
            this.Name = "Output";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Output";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Label progress;
    }
}