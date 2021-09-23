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
    public partial class Variant : Form
    {
        int variantNum;
        int variantTot;
        int traitNum;
        int traitTot;
        String db;
        int total;
        String tb;
        public Variant(String dbName, String tableName, int num, int variantNumber, int variantTotal, int traitNumber, int traitTotal)
        {
            InitializeComponent();
            variantNum = variantNumber;
            variantTot = variantTotal;
            traitNum = traitNumber;
            traitTot = traitTotal;
            db = dbName;
            numVariant.Text = "Variant " + variantNum;
            total = num;
            tb = tableName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String VARIANT_NAME = variantName.Text;
            double QUOTA = 0;

            //Error Handling
            if (VARIANT_NAME.Equals(""))
            {
                MessageBox.Show("Please enter a valid Variant Name", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                QUOTA = Double.Parse(quota.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please enter a positve integer for Quota(%)", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (QUOTA <= 0)
            {
                MessageBox.Show("Please enter an integer larger than 0 for Quota(%)", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlConnection con = new SqlConnection("Server=localhost;Database=" + db + ";Trusted_Connection=true");
            String TABLE_NAME = tb;
            String stmt = "INSERT INTO " + TABLE_NAME + " VALUES ('" + VARIANT_NAME + "', " + 0 + ", " + (int)  ((QUOTA * total) / 100) + ", " + QUOTA + ")";

            con.Open();
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.ExecuteNonQuery();

            con.Close();

            this.Hide();

            if (variantNum < variantTot)
            {
                Variant variant = new Variant(db, TABLE_NAME, total, variantNum + 1, variantTot, traitNum, traitTot);
                variant.ShowDialog();
            }
            else
            {
                Database database = new Database(db);
                database.updateBounds(TABLE_NAME);
                ArrayList bounds = database.getBounds(TABLE_NAME);
                int lastIndex = bounds.Count - 1;
                double lastValue = (double)bounds[lastIndex];

                if (lastValue != 100)
                {
                    String stmt1 = "DROP TABLE " + TABLE_NAME;
                    SqlCommand cmd1 = new SqlCommand(stmt1, con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Please try again. Please ensure quota values sum to 100 for each trait.", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Trait trait = new Trait(db, total, traitNum, traitTot);
                    trait.ShowDialog();
                    return;
                }
                else if (traitNum < traitTot)
                {
                    addTrait(TABLE_NAME);

                    traitNum++;
                    Trait trait = new Trait(db, total, traitNum, traitTot);
                    trait.ShowDialog();
                }
                else
                {
                    addTrait(TABLE_NAME);
                    Output output = new Output(db, total);
                    output.ShowDialog();
                }
            }
            this.Close();
        }

        private void addTrait(String trait)
        {
            SqlConnection con = new SqlConnection("Server=localhost;Database=" + db + ";Trusted_Connection=true");
            String stmt = "INSERT INTO TRAITS VALUES ('" + trait + "')";
            SqlCommand cmd = new SqlCommand(stmt, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
