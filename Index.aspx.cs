using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using System;
using System.Collections.Generic;
using FreshVeggies.Class;
using System.Text;

namespace FreshVeggies
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SiteFetch fetch = new SiteFetch();
        LoginDatabase login = new LoginDatabase();
        SourceStrings s = new SourceStrings();
        CartClass nCart = new CartClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            local_header.InnerHtml = fetch.getSite(fetch.theHeader);
            local_footer.InnerHtml = fetch.getSite(fetch.theFooter);

            if (Session[s.SessionCart] == null)
            {
                Session[s.SessionCart] = "";
            }
            if (Session[s.SessionUser] != null)
            {
                LoggedIn();
            }
            UpdateCartCount();
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            RegisterFunc();
        }

        protected void btn_login_Click(object sender, EventArgs e)
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
                    Response.Redirect("Index.aspx");
                }
            }
        }

        public void UpdateCartCount()
        {
            String one = @"<script type=""text/javascript"">document.getElementById(""cart_count_id"").innerHTML = '";
            String two = nCart.countCartItems(Session[s.SessionCart].ToString()) + "'; </script>";
            script_div.InnerHtml = one + two;
        }

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
        public void Message(String text)
        {
            Response.Write("<script>alert('" + text + "');</script>");
        }
    }
}