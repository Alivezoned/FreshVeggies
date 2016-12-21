using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using FreshVeggies.Class;

namespace FreshVeggies.Administrator
{
    public partial class ProductAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        ProductsDatabase ProductDB = new ProductsDatabase();

        public int GetCurrentImageId()
        {
            String idStr = ProductDB.GetLastId();
            int finalId = int.Parse(idStr);
            return finalId;
        }
        public String UploadImage()
        {
            String finalFileName = "";
            try
            {
                HttpPostedFile file = Request.Files["productImg"];
                if (file != null && file.ContentLength > 0)
                {
                    String fname = Path.GetFileName(file.FileName);
                    file.SaveAs(Server.MapPath(Path.Combine("/Assets/Images/Products/", GetCurrentImageId()+""+fname)));
                    finalFileName = GetCurrentImageId() + "" + fname;
                }
            }
            catch (Exception) { }
            return finalFileName;
        }
        public String AddProduct()
        {
            try
            {
                String returnString = "Not Added";

                String pName, pUnit, pImage, pMeasurement;
                pName = txt_prod_name.Text.ToString();
                pUnit = txt_prod_measure_unit.Text.ToString();
                pMeasurement = txt_prod_measurement.Text.ToString();
                pImage = UploadImage();

                int pPrice;
                String tempPrice = txt_prod_price.Text.ToString();
                pPrice = int.Parse(tempPrice);

                Boolean NameExists = ProductDB.CheckIfExist("SELECT * FROM items_table WHERE item_name = '"+pName+"'");
                if (NameExists)
                {
                    returnString = "Product with similar name already exists";
                }
                else
                {
                    if (pName.Length > 0 && pUnit.Length > 0 && tempPrice.Length > 0 && pImage.Length > 0)
                    {
                        Boolean status = ProductDB.AddItem(pName, pPrice, pUnit, pImage, pMeasurement);
                        if (status)
                        {
                            returnString = pName + " Added";
                        }
                    }
                }
                return returnString;
            }
            catch (Exception) { return "Product Not Added"; }
        }

        protected void btnSubmitClick(object sender, EventArgs e)
        {
            Response.Write("<script>alert('"+AddProduct()+"')</script>");
            txt_prod_name.Text = "";
            txt_prod_price.Text = "";
            txt_prod_measurement.Text = "";
        }
    }
}