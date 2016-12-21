<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="FreshVeggies.Payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Fresh Veggies</title>

        <link rel="stylesheet" type="text/css" href="Assets/Style/header.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/content-for-index.css">
        <link rel="stylesheet" type="text/css" href="Assets/Style/payment.css">
</head>
<body>    
    <form id="form1" runat="server">
<div  class="site_container">
    <div class="content">
        <h1 class="heading"><img alt="fresh veggies" height="40px" src="Assets/Images/anand_veg_market.png" /><br />Fresh Veggies: Order Payment</h1><br>
        <div class="pay_form_holder">
            <div id="pay_amount" runat="server"></div>
            <div id="pay_form_div" class="pay_form" runat="server">
                 <ul class="txtbox_list">
                 <li><span class="login_text_labels">Card Number</span>
                 <asp:TextBox ID="txt_card" class="txt_box" runat="server" MaxLength="20" 
                         TextMode="Number"></asp:TextBox></li>

                 <li><span class="login_text_labels">Name on Card</span>
                 <asp:TextBox ID="txt_name" class="txt_box" placeholder="Name as printed on Card" runat="server"></asp:TextBox>

                 <li><span class="login_text_labels">Expiry Date</span>

                 <asp:TextBox ID="txt_expiry_month" class="txt_box" placeholder="Month" 
                         runat="server" MaxLength="2" TextMode="Number"></asp:TextBox>
                 <asp:TextBox ID="txt_expiry_year" class="txt_box" placeholder="Year" runat="server" 
                         MaxLength="4" TextMode="Number"></asp:TextBox></li>

                 <li><span class="login_text_labels">PIN Number</span>
                 <asp:TextBox ID="txt_pin" class="txt_box" runat="server" TextMode="Password" MaxLength="3"></asp:TextBox></li>
                 <li><asp:Button ID="btn_pay" runat="server" Text="Make Payment" 
                         onclick="btn_pay_Click" /></li>
                 </ul>
            </div>
        </div>
    </div>
</div>
    </form>
</body>
</html>
