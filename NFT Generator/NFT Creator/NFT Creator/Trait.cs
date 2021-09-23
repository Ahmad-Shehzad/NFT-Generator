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

namespace NFT_Creator
{
    public partial class Trait : Form
    {

        int traitNum;
        int traitTot;
        String db;
        int total;
        public Trait(String dbName, int num, int traitNumber, int traitTotal)
        {
            InitializeComponent();
            title.Text = "Trait " + traitNumber;
            traitNum = traitNumber;
            traitTot = traitTotal;
            db = dbName;
            total = num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberOfVariants = 0;
            String TABLE_NAME = name.Text.Replace(" ", "");

            //Error Handling
            if (name.Text.Equals(""))
            {
                MessageBox.Show("Please enter a valid Collection Name", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                numberOfVariants = Int16.Parse(numVariants.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please enter a positve integer for Number of Variants", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (numberOfVariants < 1)
            {
                MessageBox.Show("Please enter an integer larger than 0 for Number of Variants", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlConnection con = new SqlConnection("Server=localhost;Database=" + db + ";Trusted_Connection=true");

            String stmt1 = "CREATE TABLE " + TABLE_NAME + "(ID INT IDENTITY, VARIATION VARCHAR(100), TALLY INT, TARGET INT, BOUND FLOAT)";
            SqlCommand cmd1 = new SqlCommand(stmt1, con);

            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            this.Hide();
            Variant variant = new Variant(db, TABLE_NAME, total, 1, Int16.Parse(numVariants.Text), traitNum, traitTot);
            variant.ShowDialog();
            this.Close();
        }
    }
}
