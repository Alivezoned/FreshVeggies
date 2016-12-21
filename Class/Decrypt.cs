using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;
using System.Text;

namespace FreshVeggies.Class
{
    public class Decrypt
    {
        public String encrypt(String text)
        {

            StringBuilder build = new StringBuilder();
            char[] character = text.ToCharArray();
            foreach (char c in character)
            {
              char outx = (char) (c + 2);
              build.Append(outx);
            }
            return build.ToString();
        }

        public String decrypt(String text)
        {
            StringBuilder build = new StringBuilder();
            char[] character = text.ToCharArray();
            foreach (char c in character)
            {
               char outx = (char)(c - 2);
               build.Append(outx);
            }
            return build.ToString();
        }
    }
}