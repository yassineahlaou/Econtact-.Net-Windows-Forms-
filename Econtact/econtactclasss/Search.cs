using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact.econtactclasss
{
    class Search
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public bool Find(String num)
        {
            //Database Connection
            SqlConnection conn = new SqlConnection(myconnstring);
            bool status = false;

            try
            {
                //SQL Query
                string sql = "SELECT * from  tbl_contact WHERE ContactNo = @ContactNo";
                //using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create SQL dataadapter
                
                cmd.Parameters.AddWithValue("@ContactNo",num);
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                
                DataSet ds = new DataSet();
                adapt.Fill(ds);

                conn.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }


            }
            catch (Exception ex)
            {

            }
            
            return status;
        }
    }
}
