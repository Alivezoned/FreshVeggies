using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using FreshVeggies.Class;

namespace FreshVeggies.Class
{
    public class SiteFetch
    {
        public String DataSource = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database1.accdb";
        public String TableName = "site_data";
        public String theHeader = "header";
        public String theFooter = "footer";
        public String shopHeader = "shopheader";
        public String cartHeader = "cartheader";

        /// <summary>
        /// Gets Part of the website from the database
        /// </summary>
        /// <param name="sitePart">Title Name of the Site stored in the database</param>
        /// <returns>The Website Source</returns>
        public String getSite(String sitePart)
        {
            StringBuilder build = new StringBuilder();
            Database db = new Database(TableName, DataSource);
            Decrypt crypt = new Decrypt();
            String getSiteQuery = "SELECT * FROM " + TableName + " WHERE title = '" + sitePart + "'";
            build.Append("" + db.selectQuery(getSiteQuery, 1, false));
            return crypt.decrypt(build.ToString());
        }
    }
}