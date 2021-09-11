using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace NFT_Creator
{
    public partial class View : Form
    {
        String DATABASE_NAME;
        Database db;
        ArrayList traits;
        int index = 1;
        public View(String databaseName)
        {
            InitializeComponent();
            DATABASE_NAME = databaseName;

            try
            {
                db = new Database(DATABASE_NAME);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database could not be found. Please check your database name and location.", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            traits = db.getAllTraits();
            displayEntry(index);
        }

        private void displayEntry(int id)
        {
            list.Items.Clear();
            list.Items.Add("ID: " + db.getNFT(id)[0]);
            for (int i = 0; i < traits.Count; i++)
            {
                list.Items.Add(traits[i] + ": " + db.getNFT(id)[i + 1]);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (index < db.getCount())
            {
                index++;
                displayEntry(index);
            }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            if (index > 1)
            {
                index--;
                displayEntry(index);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
