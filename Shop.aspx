<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="FreshVeggies.Webpage.Shop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shop: Fresh Veggies</title>
    
        <script type="text/javascript" src="Assets/Script/context-main-script.js"></script>
        <script type="text/javascript" src="Assets/Script/context-disable.js"></script>

        <link rel="stylesheet" type="text/css" href="Assets/Style/header.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/context-menu.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/login-register-pop.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/shop-product.css">
</head>
<body>
    
<div  class="site_container">
    <div id="local_header" runat="server"></div>

     <div class="content">
         <div class="products_div" runat="server">

             <asp:DataList ID="DataList1" runat="server" DataSourceID="AccessDataSource1" 
                 RepeatColumns="6" RepeatDirection="Horizontal">
        <ItemTemplate>
    <div class="product_box">
        <div class="product_image">
          <img src="Assets\Images\Products\<%# Eval("item_image") %>"></div>

        <div class="product_info">
	         <li class="item_name"><%# Eval("item_name") %></li>
	         <li class="item_amount"><%# Eval("item_measurement") %> <%# Eval("item_measure_unit") %></li>
		<div class="add_to_cart_div">
		     <li class="item_price"><span style="color:rgb(175, 175, 175); font-size:11px;">MRP:</span> Rs.<%# Eval("item_price") %></li>
             <form>
             <input id="product_id" name="product_id" type="hidden" value="<%# Eval("item_id") %>" />
		     <input class="add_to_cart_btn" type="submit" value="ADD TO CART">
             </form>
		</div>
        </div>
    </div>
        </ItemTemplate>
    </asp:DataList>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/Database1.accdb" 
        
                 
                 
                 SelectCommand="SELECT [item_name], [item_price], [item_measure_unit], [item_image], [item_id], [item_measurement] FROM [items_table] ORDER BY [item_name]">
    </asp:AccessDataSource>
         </div>
     </div>


<div id="login_holder" class="login_holder_hide">
<form id="form1" runat="server">
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
                <asp:Button ID="btn_login" runat="server" Text="Login" 
                    onclick="btn_login_Click" />
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
