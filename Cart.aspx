<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FreshVeggies.Webpage.Cart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart: Fresh Veggies</title>
    
        <script type="text/javascript" src="Assets/Script/context-main-script.js"></script>
        <script type="text/javascript" src="Assets/Script/context-disable.js"></script>

        <link rel="stylesheet" type="text/css" href="Assets/Style/header.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/context-menu.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/login-register-pop.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/cart-css.css">
</head>
<body>
    <form id="form1" runat="server">
<div  class="site_container">
    <div id="local_header" runat="server">2</div>

     <div class="content">

     <div class="check-out"><div class="check-out-bg">
        <div id="total_price" runat="server"></div>
        <div><asp:Button ID="check_out_btn" runat="server" Text="PLACE ORDER" 
                onclick="check_out_btn_Click" /></div>
     </div></div>

     <hr class="hr_tag" /><br />
         <asp:DataList ID="DataList1" runat="server" DataKeyField="item_id" 
             DataSourceID="DataSourceCart" ShowFooter="False" ShowHeader="False">
             <ItemTemplate>
             <div class="product-box"><form>
            <ul><img alt="" src="Assets\Images\Products\<%# Eval("item_image") %>"></ul>
            <ul class="product-details">
	            <li><span class="product-name"><%# Eval("item_name") %></span><span class="product-amount"> - <%# Eval("item_measurement")%> <%# Eval("item_measure_unit")%></span></li>
	            <li class="product-list-price">
                <input type="text" name="item_amount" value="1" disabled>
	            <span class="product-price">Rs. <%# Eval("item_price") %></span></li>
            </ul>
            <div class="product-fields">
	            <input type="hidden" name="item_id" value="<%# Eval("item_id") %>">
                </form>
                <form>
                <input type="hidden" name="delete" value="delete"/>
                <input type="hidden" name="item_id" value="<%# Eval("item_id") %>">
	            <input class="close-btn" type="submit" value="x">
                </form>
            </div>
            </div>
             </ItemTemplate>
         </asp:DataList>
         <asp:AccessDataSource ID="DataSourceCart" runat="server" DataFile="~/App_Data/Database1.accdb"></asp:AccessDataSource>
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
            <li><asp:Button ID="btn_login" runat="server" Text="Login" 
                    onclick="btn_login_Click" /></li>
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
