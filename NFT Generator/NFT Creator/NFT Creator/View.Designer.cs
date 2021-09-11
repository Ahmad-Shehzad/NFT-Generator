
namespace NFT_Creator
{
    partial class View
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
            this.exitButton = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(194, 555);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // previous
            // 
            this.previous.Location = new System.Drawing.Point(87, 505);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(75, 23);
            this.previous.TabIndex = 1;
            this.previous.Text = "Previous";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(307, 505);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 2;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(98, 110);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(280, 329);
            this.list.TabIndex = 3;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 590);
            this.Controls.Add(this.list);
            this.Controls.Add(this.next);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.exitButton);
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.ListBox list;
    }
}