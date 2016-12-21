using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using FreshVeggies.Class;

namespace FreshVeggies.Webpage
{
    public partial class Cart : System.Web.UI.Page
    {
        SourceStrings s = new SourceStrings();
        SiteFetch fetch = new SiteFetch();
        LoginDatabase login = new LoginDatabase();
        CartClass nCart = new CartClass();
        ProductsDatabase prod = new ProductsDatabase();

        protected void Page_Load(object sender, EventArgs e)
        {
            local_header.InnerHtml = fetch.getSite(fetch.cartHeader);
            local_footer.InnerHtml = fetch.getSite(fetch.theFooter);
            DeleteItem();

            if (Session[s.SessionCart] == null)
            {
                Session[s.SessionCart] = "";
            }
            if (Session[s.SessionUser] != null)
            {
                LoggedIn();
            }
            //Message(Session[s.SessionCart].ToString()+"");
            UpdateCartCount();
            if (Session[s.SessionCart].ToString().Length > 2)
            {
                DataSourceCart.SelectCommand = "SELECT [item_id], [item_name], [item_price], [item_measure_unit], [item_image], [item_measurement] FROM [items_table] WHERE [item_id] IN (" + idSplit(Session[s.SessionCart].ToString()) + ") ORDER BY [item_name]";
            }
            total_price.InnerHtml = "Total: Rs.<span>" + TotalAmountOfItems() + "</span>";
        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            ButtonLogin();
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            RegisterFunc();
        }

        public void UpdateCartCount()
        {
            String one = @"<script type=""text/javascript"">document.getElementById(""cart_count_id"").innerHTML = '";
            String two = nCart.countCartItems(Session[s.SessionCart].ToString()) + "'; </script>";
            script_div.InnerHtml = one + two;
        }

        /// <summary>
        /// Splits Item ID separated by comma
        /// </summary>
        /// <param name="idString">Example: id,id,id,id</param>
        /// <returns></returns>
        public String idSplit(String idString)
        {
            Boolean once = false;
            String[] array = idString.Split(',');
            StringBuilder b = new StringBuilder();
            foreach (String txt in array)
            {
                if (once == false && txt.Length > 0)
                {
                    b.Append(""+txt);
                    once = true;
                }
                else if (txt.Length > 0)
                {
                    b.Append(","+txt);
                }
            }
            return b.ToString();
        }

        public String TotalAmountOfItems()
        {
            String finalTotal = "";
            int total = 0;

                String[] array = idSplit(Session[s.SessionCart].ToString()).Split(',');
                foreach (String id in array)
                {
                    if (id.Length > 0)
                    {
                        String mPrice = prod.FetchRecord("SELECT * FROM [items_table] WHERE [item_id] LIKE '" + id + "'", 2, true).Trim();
                        int price = int.Parse(mPrice);
                        total += price;
                    }
                }

            finalTotal = total + "";
            return finalTotal;
        }

        /// <summary>
        /// Deletes Cart Items
        /// </summary>
        public void DeleteItem()
        {
            Boolean allowRedirect = false;
            try
            {
                var post = HttpContext.Current;
                String id = post.Request["item_id"];
                String delete = post.Request["delete"];
                if (delete == "delete")
                {
                    String[] array = idSplit(Session[s.SessionCart].ToString()).Split(',');
                    StringBuilder build = new StringBuilder();
                    foreach (String str in array)
                    {
                        if (str != id)
                        {
                            build.Append("," + str);
                        }
                        else
                        {
                            allowRedirect = true;
                        }
                    }
                    Session[s.SessionCart] = build.ToString();
                    if (allowRedirect)
                    {
                        Response.Redirect("Cart.aspx");
                    }
                }
            }
            catch (Exception) { }
        }


        public void Message(String text)
        {
            Response.Write("<script>alert('"+text+"');</script>");
        }

        #region Re

        public void LoggedIn()
        {
            login_change.InnerHtml = fetch.getSite("logged");
        }
        public void RegisterFunc()
        {
            String user, pass, passR, email, addr, temp;
            user = txt_reg_user.Text.ToString();
            pass = txt_reg_pass.Text.ToString();
            passR = txt_reg_pass_repeat.Text.ToString();
            email = txt_reg_email.Text.ToString();
            addr = txt_reg_address.Text.ToString();

            int pin = 0, phno = 0;

            try
            {
                temp = txt_reg_pin.Text.ToString();
                pin = int.Parse(temp);
                temp = txt_reg_phone.Text.ToString();
                phno = int.Parse(temp);
            }
            catch (Exception) { }

            Boolean exists = login.CheckUserExists(user);
            if (pass == passR && pin > 0 && phno > 4 && pass.Length > 5 && exists == false)
            {
                Boolean status = login.Register(user, pass, email, addr, pin + "", phno + "");
                if (status)
                {
                    Message("Thank you for registering with Fresh Veggies");
                    ClearField();
                }
            }
            else
            {
                if (exists == true)
                {
                    Message("User Exists: please choose a different username");
                }
                else
                {
                    Message("Registration Failed: Please check all the fields properly");
                }
            }
        }
        public void ClearField()
        {
            txt_reg_user.Text = "";
            txt_reg_pass.Text = "";
            txt_reg_pass_repeat.Text = "";
            txt_reg_address.Text = "";
            txt_reg_email.Text = "";
            txt_reg_phone.Text = "";
            txt_reg_pin.Text = "";
        }

        public void ButtonLogin()
        {
            String user = txt_username.Text.ToString();
            String pass = txt_password.Text.ToString();
            if (user.Length > 1 && pass.Length > 1)
            {
                String logged = login.Login(user, pass);
                if (logged.Contains(pass))
                {
                    Session[s.SessionUser] = user;
                    Session[s.SessionPass] = pass;
                    Response.Redirect("Shop.aspx");
                }
            }
        }
        #endregion

        protected void check_out_btn_Click(object sender, EventArgs e)
        {
            if (Session[s.SessionUser] == null)
            {
                Message("Please Log in to place an order");
            }
            else if(TotalAmountOfItems().Length > 1)
            {
                if (Session[s.SessionCart] != null)
                {
                    login.UpdateUserData("UPDATE [user_table] SET [cart] = '" + idSplit(Session[s.SessionCart].ToString()) + "' WHERE [username] = '" + Session[s.SessionUser].ToString() + "'");
                    String userId = "" + prod.FetchRecord("SELECT * FROM [user_table] WHERE [username] = '" + Session[s.SessionUser].ToString() + "'", 0, true);
                    Session[s.SessionPayment] = TotalAmountOfItems();
                    Session[s.SessionUserId] = userId;
                    Message(userId+"");
                    Response.Redirect("Payment.aspx");
                }
            }
        }
    }
}