
namespace NFT_Creator
{
    partial class Variant
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
            this.numVariant = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.variantName = new System.Windows.Forms.TextBox();
            this.quota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numVariant
            // 
            this.numVariant.AutoSize = true;
            this.numVariant.Location = new System.Drawing.Point(224, 47);
            this.numVariant.Name = "numVariant";
            this.numVariant.Size = new System.Drawing.Size(35, 13);
            this.numVariant.TabIndex = 0;
            this.numVariant.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // variantName
            // 
            this.variantName.Location = new System.Drawing.Point(171, 154);
            this.variantName.Name = "variantName";
            this.variantName.Size = new System.Drawing.Size(253, 20);
            this.variantName.TabIndex = 2;
            // 
            // quota
            // 
            this.quota.Location = new System.Drawing.Point(171, 235);
            this.quota.Name = "quota";
            this.quota.Size = new System.Drawing.Size(253, 20);
            this.quota.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name of Variant:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Quota (%):";
            // 
            // Variant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 590);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quota);
            this.Controls.Add(this.variantName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numVariant);
            this.Name = "Variant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Variant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numVariant;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox variantName;
        private System.Windows.Forms.TextBox quota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}