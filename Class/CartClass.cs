using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace FreshVeggies.Class
{
    public class CartClass
    {
        /// <summary>
        /// Count Number of items in cart
        /// </summary>
        /// <param name="itemText">cart item id's separated by comma picked from session</param>
        /// <returns></returns>
        public int countCartItems(String itemText)
        {
            int totalItems = 0;
            String[] a = itemText.Split(',');
            foreach (String text in a)
            {
                if (text.Length > 0)
                {
                    totalItems += 1;
                }
            }
            if (totalItems < 0) {
                return 0;
            }
            else {
                return totalItems;
            }
        }

        /// <summary>
        /// Check if Item Exists in Cart
        /// </summary>
        /// <param name="itemId">Item ID</param>
        /// <param name="itemsString">Item List separated by comma: id,id,id etc..</param>
        /// <returns></returns>
        public Boolean CheckInCart(String itemId, String itemsString)
        {
            Boolean status = false;
            String[] array = itemsString.Split(',');
            foreach (String item in array)
            {
                if (item == itemId)
                {
                    status = true;
                }
            }
            return status;
        }

        /// <summary>
        /// List Example: id,amount ; id,amount ; id,amount (Without Spaces)
        /// Stored as {{id,amount},{id,amount},{id,amount}}
        /// Reference: array[row,column]
        /// </summary>
        /// <param name="ListString">List Example: id,amount ; id,amount ; id,amount (Without Spaces)</param>
        /// <returns></returns>
        public String[,] CartList(String ListString)
        {
            String[] array = ListString.Split(';');
            int arrLength = array.Length;
            String[,] finalCart = new String[arrLength, 2];

            String[] tempArray;

            for (int i = 0; i < arrLength; i++)
            {
                tempArray = array[i].Split(',');
                finalCart[i, 0] = tempArray[0];
                finalCart[i, 1] = tempArray[1];
            }

            return finalCart;
        }
    }
}