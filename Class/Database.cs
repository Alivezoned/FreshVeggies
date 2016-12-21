using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace FreshVeggies.Class
{
    // Update Table tablename set `id`=[value-1],`first_name`=[value-2],`last_name`=[value-3],`title`=[value-4]
    // public static String DataSource = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database1.accdb";
    public class Database
    {
        public String DataSource = @"";
        public String TableName = @"";

        // Constructs TableName and the DataSource
        public Database(String tableName, String dataSource)
        {
            TableName = tableName;
            DataSource = dataSource;
        }

        #region Insert

        /// <summary>
        /// Executes Insert Query
        /// </summary>
        /// <param name="columns">columns[] Array Holds the Column Names</param>
        /// <param name="datas">datas[] Array Holds the Column Data</param>
        public void executeQuery(String[] columns, String[] datas)
        {
            int length = datas.Length;
            using (OleDbConnection c = new OleDbConnection(DataSource))
            { 
                c.Open();
                using (OleDbCommand cmd = new OleDbCommand("insert into " + TableName + " (" + ValueArrayCombine(columns, true) + ") values (" + ValueArrayCombine(datas, false) + ")", c))
                {
                    for (int i = 0; i < length; i++)
                    {
                        cmd.Parameters.AddWithValue("@val" + i, datas[i]);
                    }
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                } c.Close();
            }
        }

        #endregion

        #region Select

        public Boolean checkDataExists(String columnName, String columnData)
        {
            String query = @"SELECT * FROM "+TableName+" WHERE "+columnName+" = '"+columnData+"'";
            return checkData(query);
        }

        /// <summary>
        /// Gets the DATA for the particular COLUMN_NUMBER and returns it
        /// </summary>
        /// <param name="queryCode">the Select query to be executed</param>
        /// <param name="columnNumber">the column Number to be fetched</param>
        /// <param name="isNumber">is that column an Integer.</param>
        /// <returns></returns>
        public String selectQuery(String queryCode, int columnNumber, Boolean isNumber)
        {
            OleDbConnection c; OleDbCommand cmd; OleDbDataReader reader;
            c = new OleDbConnection(DataSource); c.Open();
            cmd = new OleDbCommand(queryCode, c);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                String recordStr = reader.GetString(columnNumber);
                reader.Close(); c.Close();
                return recordStr;
            }
            else
            {
                reader.Close(); c.Close();
                return "";
            }
        }

        #endregion

        /// <summary>
        /// Checks if there is any DATA available for the, 'queryCode'
        /// </summary>
        /// <param name="queryCode">Database query syntax</param>
        /// <returns></returns>
        public Boolean checkData(String queryCode)
        {
            OleDbConnection c; OleDbCommand cmd; OleDbDataReader reader;
            c = new OleDbConnection(DataSource); c.Open();

            cmd = new OleDbCommand(queryCode, c);
            reader = cmd.ExecuteReader();

            if (reader.Read()) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Combines the array list. Each item separated by comma(,)
        /// </summary>
        /// <param name="Array">The Array</param>
        /// <param name="isItColumnName">Specify True if the Array consists of Column Names</param>
        /// <returns></returns>
        public String ValueArrayCombine(String[] Array, Boolean isItColumnName)
        {
            StringBuilder Builder = new StringBuilder();
            for (int i = 0; i < Array.Length; i++)
            {
                if (isItColumnName == false)
                {
                    if (i != 0)
                    {
                        Builder.Append(", @val" + i);
                    }
                    else
                    {
                        Builder.Append("@val" + i);
                    }
                }
                else
                {
                    if (i != 0)
                    {
                        Builder.Append(", " + Array[i]);
                    }
                    else
                    {
                        Builder.Append("" + Array[i]);
                    }
                }
            }
            return Builder.ToString();
        }

        public void Print(String message) { Console.WriteLine(message); }
    }

}