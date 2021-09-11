using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFT_Creator
{
    public partial class LoadPopup : Form
    {
        public LoadPopup()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (databaseName.Text.Equals(""))
            {
                MessageBox.Show("Please enter a valid Database Name", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Hide();
            View view = new View(databaseName.Text);
            view.ShowDialog();
            this.Close();
        }
    }
}
