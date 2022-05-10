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
    class ContClass
    {
        //Getters and Setters
        public int ContactId { get; set; }
        public  string FirstName  { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        //Selecting from Database
        public DataTable Select()
        {
            //Database Connection
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dat = new DataTable();
            try
            {
                //SQL Query
                string sql = "SELECT * from  tbl_contact";
                //using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create SQL dataadapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dat);


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dat;
        }
        //Inserting into Database
        public bool Insert(ContClass cc)
        {
            //default value for the return
            bool succeed = false;
            //creating a connection to the database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "INSERT INTO  tbl_contact (FirstName , LastName , ContactNo , Address , Gender) values (@FirstName , @LastName , @ContactNo , @Address , @Gender) ";
                //using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Parameters
                cmd.Parameters.AddWithValue("@FirstName", cc.FirstName);
                cmd.Parameters.AddWithValue("@LastName", cc.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", cc.ContactNo);
                cmd.Parameters.AddWithValue("@Address", cc.Address);
                cmd.Parameters.AddWithValue("@Gender", cc.Gender);

                //Openning Connectio

                conn.Open();
                int check = cmd.ExecuteNonQuery();
                //query runs good then check is greater than 0 , else check is 0
                if (check > 0)
                {
                    succeed = true;
                }
                else
                {
                    succeed = false;
                }
            }

            catch (Exception ex)
            {

            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return succeed;
        }

        //Updating the data Database
        public bool Update(ContClass cc)
        {
            //default value for the return
            bool succeed = false;
            //creating a connection to the database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "UPDATE  tbl_contact SET FirstName = @FirstName , LastName=@LastName , ContactNo = @ContactNo , Address = @Address , Gender = @Gender  WHERE ContactId = @ContactId";
                //using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Parameters
                cmd.Parameters.AddWithValue("@FirstName", cc.FirstName);
                cmd.Parameters.AddWithValue("@LastName", cc.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", cc.ContactNo);
                cmd.Parameters.AddWithValue("@Address", cc.Address);
                cmd.Parameters.AddWithValue("@Gender", cc.Gender);
                cmd.Parameters.AddWithValue("@ContactId", cc.ContactId);

                //Openning Connectio

                conn.Open();
                int check = cmd.ExecuteNonQuery();
                //query runs good then check is greater than 0 , else check is 0
                if (check > 0)
                {
                    succeed = true;
                }
                else
                {
                    succeed = false;
                }
            }

            catch (Exception ex)
            {

            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return succeed;
        }

        //Deleting data from database
        public bool Delete(ContClass cc)
        {
            //default value for the return
            bool succeed = false;
            //creating a connection to the database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "DELETE FROM  tbl_contact WHERE ContactId = @ContactId";
                //using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Parameters
                
                cmd.Parameters.AddWithValue("@ContactId", cc.ContactId);

                //Openning Connectio

                conn.Open();
                int check = cmd.ExecuteNonQuery();
                //query runs good then check is greater than 0 , else check is 0
                if (check > 0)
                {
                    succeed = true;
                }
                else
                {
                    succeed = false;
                }
            }

            catch (Exception ex)
            {

            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return succeed;
        }



    }
}
