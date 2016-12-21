<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FreshVeggies.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Fresh Veggies</title>

        <script type="text/javascript" src="Assets/Script/context-main-script.js"></script>
        <script type="text/javascript" src="Assets/Script/context-disable.js"></script>

        <link rel="stylesheet" type="text/css" href="Assets/Style/header.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/content-for-index.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/context-menu.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/login-register-pop.css">

</head>
<body>  
    
    <form id="form1" runat="server">
    
<div  class="site_container">
            
            <div id="local_header" runat="server"></div>

            <div class="content">
            <h1 class="heading">Welcome to Fresh Veggies</h1><br>

            <div class="desc_holder">
                <div class="company_desc">
                    <b>Fresh Veggies</b> the online Fruits and Vegetables Purchasing Portal.<br>
                    <b>Fresh Veggies</b> provides Fruits and Vegetables delivered within 24 hours<br>
                    Fresh and Sealed!, We have more than 74 Warehouses all over India. <br>
                    Making us the First Online Fruits and Vegetable selling Company in <b>India</b>!<br>
                    <b>Fresh Veggies</b> is a great way to save time and money. It's quick and<br>
                    convenient. Experience the true meaning of flavour and freshness at <b>Fresh Veggies</b>
                    <br>
                    <h1 class="heading"><b>Why Us?</b></h1>
                    <b>
                        <li>Committed to deliver fresh product at most competitive rate from local market.</li>
                        <li>Hassle free delivery at your door step</li>
                        <li>Team of experienced market hunters, procuring goods as per your daily requirements</li>
                        <li>We are evolving and ready to accept your feedbacks to serve you better</li>
                        <li>Delivery Branches nearer to your location, covering every city in India!</li>
                    </b>
                </div>
                <div class="desc_img">
                    <img alt="Fresh Veggies Logo" src="Assets/images/anand_veg_market.png">
                    <br>
                    <h1 class="heading"><span style="color: #4CAF50;">Fresh Veggies</span> <br> Delivered to your doorstep</h1>
                </div>
            </div>

        <br />
        </div>
<div id="login_holder" class="login_holder_hide">

    <div id="login_div" class="login_hide">
        <div id="hide_button_1" onclick="Hide()">X</div><br />
        <ul class="form_ul">
            <div class="input_text_class">
                <li style="border-bottom: 1px solid rgb(110,110,110)"><img alt="Fresh Veggies Logo" src="Assets/images/login_veggies.png" height="80px"></li>
                <li>
                <span class="login_text_labels">Username</span><br />
                <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
                </li>
                <li>
                <span class="login_text_labels">Password</span><br />
                <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
                </li>
            </div>
            <li>
            <asp:Button ID="btn_login" runat="server" Text="Login" onclick="btn_login_Click" />
            </li>
        </ul>
    </div>

    <div id="register_div" class="register_hide">
        <div id="hide_button_2" onclick="Hide()">X</div><br />
        <ul class="form_ul">
          <div class="input_text_class">
          <li style="border-bottom: 1px solid rgb(110,110,110)"><img alt="Fresh Veggies Logo" src="Assets/images/register_veggies.png" height="80px"></li>
                    <li>
                <span class="login_text_labels">Username</span><br />
                <asp:TextBox ID="txt_reg_user" runat="server"></asp:TextBox>
                </li>
                    <li>
                <span class="login_text_labels">Password</span><br />
                <asp:TextBox ID="txt_reg_pass" runat="server" TextMode="Password"></asp:TextBox>
                </li>
                    <li>
                <span class="login_text_labels">Re-enter Password</span><br />
                <asp:TextBox ID="txt_reg_pass_repeat" runat="server" TextMode="Password"></asp:TextBox>
                </li>
                    <li>
                <span class="login_text_labels">Email</span><br />
                <asp:TextBox ID="txt_reg_email" runat="server"></asp:TextBox>
                </li>
                    <li>
                <span class="login_text_labels">Address</span><br />
                <asp:TextBox ID="txt_reg_address" runat="server"></asp:TextBox>
                </li>
                    <li>
                <span class="login_text_labels">Pin Code</span><br />
                <asp:TextBox ID="txt_reg_pin" runat="server"></asp:TextBox>
                </li>
                    <li>
                <span class="login_text_labels">Phone Number</span><br />
                <asp:TextBox ID="txt_reg_phone" runat="server"></asp:TextBox>
                </li>
             </div>
            <li><asp:Button ID="btn_register" runat="server" Text="Register" 
                    onclick="btn_register_Click" /> &nbsp;&nbsp;<input id="btn-reset" type="reset" value="reset" /></li>
        </ul>
    </div>
</div>

        <div id="local_footer" runat="server"></div>
        <div id="script_div" runat="server"></div>
        <div id="login_change" runat="server"></div>
</div>
    </form>
</body>
<script type="text/javascript">
    function LoginFunction() {
        document.getElementById("login_div").className = "login_popup";
        document.getElementById("login_holder").className = "login_holder_show";
    }
    function RegisterFunction() {
        document.getElementById("register_div").className = "register_popup";
        document.getElementById("login_holder").className = "login_holder_show";
    }
    function Hide() {
        document.getElementById("login_div").className = "login_hide";
        document.getElementById("register_div").className = "register_hide";
        document.getElementById("login_holder").className = "login_holder_hide";
    }
</script>
</html>
