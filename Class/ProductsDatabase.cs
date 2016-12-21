using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace FreshVeggies.Class
{
    public class ProductsDatabase
    {
        String DataSource = @"";
        
        public ProductsDatabase()
        {
            SourceStrings mSource = new SourceStrings();
            DataSource = mSource.DataSourceGlobal;
        }

        /// <summary>
        /// Add new product item into the table
        /// </summary>
        /// <param name="itemName">Item Name</param>
        /// <param name="itemPrice">Item Price</param>
        /// <param name="itemMeasureUnit">Item Unit (Gram, Kilogram, litre)</param>
        /// <param name="itemImage">The Image string</param>
        /// <returns>true if insertion is successful</returns>
        public Boolean AddItem(String itemName, int itemPrice, String itemMeasureUnit, String itemImage, String itemMeasurement)
        {
            Boolean status = false;
            using (OleDbConnection c = new OleDbConnection(DataSource))
            {
                c.Open();
                using (OleDbCommand cmd = new OleDbCommand("INSERT INTO items_table(item_name,item_price,item_measure_unit,item_image,item_measurement) "
                    +"VALUES (@value1,@value2,@value3,@value4,@value5)", c))
                {
                    cmd.Parameters.AddWithValue("@value1", itemName);
                    cmd.Parameters.AddWithValue("@value2", itemPrice);
                    cmd.Parameters.AddWithValue("@value3", itemMeasureUnit);
                    cmd.Parameters.AddWithValue("@value4", itemImage);
                    cmd.Parameters.AddWithValue("@value5", itemMeasurement);
                    cmd.CommandType = System.Data.CommandType.Text;
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        status = true;
                    }
                }
                c.Close();
            }
            return status;
        }

        public Boolean UpdateItem(String query)
        {
            Boolean status = false;
            using (OleDbConnection c = new OleDbConnection(DataSource))
            {
                c.Open();
                OleDbCommand cmd = new OleDbCommand(query, c);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    status = true;
                }
                c.Close();
            }
            return status;
        }

        public Boolean CheckIfExist(String query)
        {
            Boolean status = false;
            using (OleDbConnection c = new OleDbConnection(DataSource))
            {
                c.Open();
                OleDbCommand cmd = new OleDbCommand(query, c);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        status = true;
                    }
                }
                c.Close();
            }

            return status;
        }

        public String GetLastId()
        {
            String data = "1";
            String query = "SELECT * FROM items_table ORDER BY item_id ASC";
            using (OleDbConnection c = new OleDbConnection(DataSource))
            {
                c.Open();
                OleDbCommand cmd = new OleDbCommand(query, c);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int a = reader.GetInt32(0);
                        int sum = a + 1;
                        data = sum + "";
                    }
                }
                c.Close();
            }
            return data;
        }

        public String FetchRecord(String query, int columnNo, Boolean isNumber)
        {
            String data = "";
            using (OleDbConnection c = new OleDbConnection(DataSource))
            {
                c.Open();
                OleDbCommand cmd = new OleDbCommand(query, c);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (isNumber)
                        {
                            data = "" + reader.GetInt32(columnNo);
                        }
                        else
                        {
                            data = "" + reader.GetString(columnNo);
                        }
                    }
                    reader.Close();
                }
                c.Close();
            } return data;
        }
    }
}