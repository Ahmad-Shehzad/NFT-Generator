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
    public partial class Output : Form
    {

        String DATABASE_NAME;
        int TOTAL;
        public Output(String db, int total)
        {
            InitializeComponent();

            progressBar.Minimum = 0;
            progressBar.Maximum = total;
            progressBar.Step = 1;

            DATABASE_NAME = db;
            TOTAL = total;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            Database data = new Database(DATABASE_NAME);
            data.createTable();
            int index = 0;

            for (int i = 0; i < TOTAL; i++)
            {
                progress.Text = (i + 1) + "/" + TOTAL;
                data.genNFT();
                progressBar.PerformStep();
                index = i;
                progress.Update();
            }
           
            generate.Enabled = false;
            exitButton.Enabled = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
} 
