<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="FreshVeggies.Administrator.ProductAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Products</title>
    <style>
    .input_type_text input, .input_type_text select
    {
        padding: 5px;
        width: 100%;
        border-radius: 5px;
        border: 2px solid #535353;
        box-shadow: 4px 4px 2px -3px #0A0A0A;
        transition: 0.2s all linear;
    }
    .form_ul 
    {
        margin:0 auto;
        max-width: 300px;
        list-style-type: none;
        display: block;
    }
    .form_ul li 
    {
        padding: 5px;
        margin: 5px;
    }
    input[type=submit] 
    {
        box-shadow: 3px 4px 3px -3px #222222;
        color: white;
        padding: 10px 20px;
        border: 1px solid #444444;
        background: #555555;
        border-radius: 3px;
        transition: 0.2s all linear;
    }
    input[type=submit]:hover, input[type=submit]:focus, input[type=submit]:active
    {
        border: 1px solid black;
        background: rgba(0, 0, 0, 0.75);
        box-shadow: 0px 0px 2px -2px #191919;
        transition: 0.2s all linear;
    }
    </style>
</head>
<body>
    <form id="productForm" runat="server" enctype="multipart/form-data">
    <div id="form_field_holder">
    <ul class="form_ul">
    <div class="input_type_text">
        <li style="text-align:center;"><img src="../Assets/Images/anand_veg_market.png" alt="Fresh Veggies" height="100"></li>
         <li><span class="login_text_labels">Product Name</span><br />
         <asp:TextBox ID="txt_prod_name" runat="server"></asp:TextBox></li>

         <li><span class="login_text_labels">Product Price</span><br />
         <asp:TextBox ID="txt_prod_price" runat="server" TextMode="Number"></asp:TextBox></li>

         <li><span class="login_text_labels">Measuring Unit</span><br />
         <asp:DropDownList ID="txt_prod_measure_unit"
             runat="server">
             <asp:ListItem Value="gram (g)">gram (g)</asp:ListItem>
             <asp:ListItem Value="kilogram (kg)">kilogram (kg)</asp:ListItem>
             <asp:ListItem Value="litre">litre</asp:ListItem>
             <asp:ListItem Value="mililitre (ml)">mililitre (ml)</asp:ListItem>
             <asp:ListItem Value="Pieces (pcs)">Pieces (pc)</asp:ListItem>
         </asp:DropDownList></li>
         <li><span class="login_text_labels">Measurement</span><br />
         <asp:TextBox ID="txt_prod_measurement" runat="server"></asp:TextBox></li>

         <li><span class="login_text_labels">Product Image</span><br />
         <input type="file" id="productImg" name="productImg" /></li>
     </div>

     <li><asp:Button runat="server" ID="btn_submit" OnClick="btnSubmitClick" Text="Add Product" /></li>

    </ul>

    </div>
    </form>
</body>
</html>
