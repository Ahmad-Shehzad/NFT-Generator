using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace NFT_Creator
{
    class Database
    {
        private SqlConnection con;
        private String DATABASE_NAME;
        private String NFT_TABLE = "NFT";
        private ArrayList traits;
        private static Random random;

        public Database(String dbName)
        {
            DATABASE_NAME = dbName;
            con = new SqlConnection("Server=localhost;Database=" + DATABASE_NAME + ";Trusted_Connection=true");
            traits = getAllTraits();
            random = new Random();
        }

        public void createTable()
        {
            String stmt = "CREATE TABLE " + NFT_TABLE + "(ID INT IDENTITY, ";

            for (int i = 0; i < (traits.Count - 1); i++)
            {
                stmt = stmt + traits[i] + " VARCHAR(100), ";
            }
            stmt = stmt + traits[(traits.Count - 1)] + " VARCHAR(100))";

            SqlCommand cmd = new SqlCommand(stmt, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public ArrayList getAllTraits()
        {
            ArrayList traits = new ArrayList();
            String stmt = "SELECT TRAIT FROM TRAITS";
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                traits.Add(reader[0]);
            }

            con.Close();

            return traits;
        }

        public int getCount()
        {
            int count = 0;
            String stmt = "SELECT COUNT(ID) FROM " + NFT_TABLE;
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count = (int)reader[0];
            }
            con.Close();

            return count;
        }

        private String genRandomVariant(String TABLE_NAME)
        {
            String variant = null;
            ArrayList bounds = getBounds(TABLE_NAME);
            double rand = (random.NextDouble() * 99) + 1;
            int index = 0;

            for (int i = 0; i < bounds.Count; i++)
            {
                if (rand <= (double)bounds[i])
                {
                    index = i + 1;
                    break;
                }
            }

            String stmt = "SELECT VARIATION FROM " + TABLE_NAME + " WHERE ID = " + index;
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                variant = (String)reader[0];
            }
            con.Close();

            return variant;
        }

        private int getTally(String TABLE_NAME, String VARIANT_NAME)
        {
            int tally = 0;
            String stmt = "SELECT TALLY FROM " + TABLE_NAME + " WHERE VARIATION = '" + VARIANT_NAME + "'";
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tally = (int)reader[0];
            }

            con.Close();

            return tally;
        }

        public ArrayList getBounds(String TABLE_NAME)
        {
            ArrayList bounds = new ArrayList();
            String stmt = "SELECT BOUND FROM " + TABLE_NAME;
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                bounds.Add((double)reader[0]);
            }
            con.Close();

            return bounds;
        }

        private void setBound(String TABLE_NAME, int id, double bound)
        {
            String stmt = "UPDATE " + TABLE_NAME + " SET BOUND = " + bound + " WHERE ID = " + id;
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateBounds(String TABLE_NAME)
        {
            ArrayList bounds = getBounds(TABLE_NAME);
            double total = 0;
            if (bounds.Count > 1)
            {
                total = (double)bounds[0];
                for (int i = 1; i < bounds.Count; i++)
                {
                    total += (double)bounds[i];
                    setBound(TABLE_NAME, i + 1, total);
                }
            }
        }

        private void updateTally(String TABLE_NAME, String VARIANT_NAME)
        {
            int tally = getTally(TABLE_NAME, VARIANT_NAME) + 1;
            String stmt = "UPDATE " + TABLE_NAME + " SET TALLY = " + tally + " WHERE VARIATION = '" + VARIANT_NAME + "'";
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private bool nftExists(ArrayList nft)
        {
            int last = traits.Count - 1;
            int numberOfEntries = 0;

            String stmt = "SELECT COUNT(ID) FROM " + NFT_TABLE + " WHERE ";
            for (int i = 0; i < last; i++)
            {
                stmt = stmt + traits[i] + " = '" + nft[i] + "' AND ";
            }
            stmt = stmt + traits[last] + " = '" + nft[last] + "'";

            SqlCommand cmd = new SqlCommand(stmt, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                numberOfEntries = (int)reader[0];
            }
            con.Close();

            if (numberOfEntries == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void genNFT()
        {
            ArrayList nft = new ArrayList();

            for (int i = 0; i < traits.Count; i++)
            {
                nft.Add(genRandomVariant((string)traits[i]));
            }

            if (nftExists(nft))
            {
                genNFT();
            }
            else
            {
                for (int i = 0; i < traits.Count; i++)
                {
                    updateTally((string)traits[i], (string)nft[i]);
                }

                String stmt = "INSERT INTO " + NFT_TABLE + " VALUES ('";
                int last = nft.Count - 1;

                for (int i = 0; i < last; i++)
                {
                    stmt = stmt + nft[i] + "', '";
                }
                stmt = stmt + nft[last] + "')";

                SqlCommand cmd = new SqlCommand(stmt, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private int getColumnNumber()
        {
            int count = 0;
            String stmt = "SELECT COUNT(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + NFT_TABLE + "'";
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                count = (int)reader[0];
            }
            con.Close();

            return count;
        }
        public ArrayList getNFT(int id)
        {
            ArrayList nft = new ArrayList();
            int numColumns = getColumnNumber();

            String stmt = "SELECT * FROM " + NFT_TABLE + " WHERE ID = " + id;
            SqlCommand cmd = new SqlCommand(stmt, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < numColumns; i++)
                {
                    nft.Add(reader[i]);
                }
            }
            con.Close();

            return nft;
        }

    }
}
