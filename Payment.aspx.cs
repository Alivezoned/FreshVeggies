using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreshVeggies.Class;
using System.Text;
using System.IO;
using System.Data.OleDb;

namespace FreshVeggies
{
    public partial class Payment : System.Web.UI.Page
    {
        SourceStrings s = new SourceStrings();
        ProductsDatabase prod = new ProductsDatabase();

        String itemList, total, userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[s.SessionCart] != null)
            {
                itemList = Session[s.SessionCart].ToString();  
            }
            if (Session[s.SessionPayment] != null)
            {
                total = Session[s.SessionPayment].ToString();
            }
            if (Session[s.SessionUserId] != null)
            {
                userId = Session[s.SessionUserId].ToString();
            }
            pay_amount.InnerHtml = "Payment Amount:- Rs. " + total;
        }

        protected void btn_pay_Click(object sender, EventArgs e)
        {
            String cardNo = txt_card.Text.ToString();
            if (cardNo.Length >= 15)
            {
                String done = Pay();
                Message("Payment Successful! Please keep the transaction id for future reference");
                char c = '"';
                pay_amount.InnerHtml = "   Payment Successful! Transaction ID: <span style=" + c.ToString() + "color: rgb(150,150,150);" + c.ToString() + ">" + done + "</span>";
                pay_form_div.InnerHtml = @"<a class=""return_link"" href=""Index.aspx"">Return to Fresh Veggies</a>";
                Session[s.SessionCart] = "";
            }
            else
            {
                Message("The Credit Card Number you entered is invalid.");
            }
        }

        /// <summary>
        /// Inserts the transaction into the database and then fetches the transaction id
        /// </summary>
        public String Transaction(String query, String fetchQuery)
        {
            String transactionId = "";
            using (OleDbConnection c = new OleDbConnection(s.DataSourceGlobal))
            {
                c.Open();
                OleDbCommand cmd = new OleDbCommand(query,c);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    OleDbCommand command = new OleDbCommand(fetchQuery,c);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transactionId = "" + reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }
                c.Close();
            }
            return transactionId;
        }

        public String Pay()
        {
            String datetime = DateTime.Now.ToString();
            String finalItems = CombineWithoutComma(itemList);
            String query = "INSERT INTO transaction_table ([customer_id], [purchased_items_id], [purchased_items_amount], [purchased_items_price], [date_time]) VALUES ('"+userId+"','"+finalItems+"','1','"+total+"','"+datetime+"')";
            String fetchQuery = "SELECT * FROM transaction_table WHERE [date_time] LIKE '"+datetime+"'";
            String transId = Transaction(query,fetchQuery);
            return transId;
        }

        public String CombineWithoutComma(String text)
        {
            StringBuilder b = new StringBuilder();
            try
            {
                String[] a = text.Split(',');
                foreach (String txt in a)
                {
                    if (txt.Length > 0)
                    {
                        b.Append(txt + ".");
                    }
                }
            }
            catch (Exception) { }
            return b.ToString();
        }
        public void Message(String text)
        {
            Response.Write("<script>alert('" + text + "');</script>");
        }


    }
}