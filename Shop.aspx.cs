using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using FreshVeggies.Class;
using System.Text;

namespace FreshVeggies.Webpage
{
    public partial class Shop : System.Web.UI.Page
    {
        SourceStrings s = new SourceStrings();
        ProductsDatabase products = new ProductsDatabase();
        SiteFetch fetch = new SiteFetch();
        CartClass nCart = new CartClass();
        LoginDatabase login = new LoginDatabase();

        protected void Page_Load(object sender, EventArgs e)
        {
            local_header.InnerHtml = fetch.getSite(fetch.shopHeader);
            local_footer.InnerHtml = fetch.getSite(fetch.theFooter);

            // Add item to Cart (store in Session)
            if (Session[s.SessionCart] == null)
            {
                Session[s.SessionCart] = "";
            }
            if (Session[s.SessionUser] != null)
            {
                LoggedIn();
            }
            var post = HttpContext.Current;
            String postedItem = post.Request["product_id"];
            if (nCart.CheckInCart(postedItem, Session[s.SessionCart].ToString()))
            {
                Message("This item is already in your Cart");
            }
            else
            {
                Session[s.SessionCart] = Session[s.SessionCart].ToString() + "" + postedItem + ",";
            }

            UpdateCartCount();
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            RegisterFunc();
        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            ButtonLogin();
        }

        public void UpdateCartCount()
        {
            String one = @"<script type=""text/javascript"">document.getElementById(""cart_count_id"").innerHTML = '";
            String two = nCart.countCartItems(Session[s.SessionCart].ToString()) + "'; </script>";
            script_div.InnerHtml = one + two;
        }

        public void Message(String text)
        {
            Response.Write("<script>alert('" + text + "');</script>");
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
    }
}