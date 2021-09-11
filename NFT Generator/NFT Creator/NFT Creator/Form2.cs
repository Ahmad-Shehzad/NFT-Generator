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
using System.IO;

namespace NFT_Creator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberInCollection = 0;
            int numberOfTraits = 0;
            String dbName = name.Text.Replace(" ", "");

            //Error Handling
            if (name.Text.Equals(""))
            {
                MessageBox.Show("Please enter a valid Collection Name", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                numberOfTraits = Int16.Parse(numTraits.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please enter a positve integer for Number of Traits", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                numberInCollection = Int16.Parse(numCollection.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please enter a positive integer for Number in Collection", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (numberOfTraits < 1 || numberInCollection < 1)
            {
                MessageBox.Show("Please enter a integer larger than 0", "NFT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            String folderPath = @"C:\NFT_DATABASES";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "CREATE DATABASE " + dbName + " ON PRIMARY " +
             "(NAME = " + dbName + "_Data, " +
             "FILENAME = '" + folderPath + "\\" + dbName + "Data.mdf', " +
             "SIZE = 20MB, MAXSIZE = 200MB, FILEGROWTH = 10%)" +
             "LOG ON (NAME = " + dbName + "_Log, " +
             "FILENAME = '" + folderPath + "\\" + dbName + "Log.ldf', " +
             "SIZE = 10MB, " +
             "MAXSIZE = 100MB, " +
             "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);

            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }

            }

            SqlConnection con = new SqlConnection("Server=localhost;Database=" + dbName + ";Trusted_Connection=true");
            String stmt = "CREATE TABLE TRAITS(ID INT IDENTITY, TRAIT VARCHAR(100))";
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            this.Hide();
            Trait trait = new Trait(dbName, numberInCollection, 1, numberOfTraits);
            trait.ShowDialog();
            this.Close();
        }
    }
}
