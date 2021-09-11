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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 createNew = new Form2();
            createNew.ShowDialog();
            this.Close();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoadPopup load = new LoadPopup();
            load.ShowDialog();
            this.Close();
        }
    }
}
