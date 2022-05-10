using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Econtact.econtactclasss;
using System.Configuration;

namespace Econtact
{
    public partial class Econtact : Form
    {
        public Econtact()
        {
            InitializeComponent();
        }
        ContClass cc = new ContClass();
        Search sc = new Search();
        private object textBoxLasttName;

        private void Econtact_Load(object sender, EventArgs e)
        {
            //load data from database

            DataTable dt = cc.Select();
            ContactList.DataSource = dt;
            
        }

        private void LOGO_Click(object sender, EventArgs e)
        {

        }

        private void LastName_Click(object sender, EventArgs e)
        {

        }

       

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //get data from database
            
            cc.FirstName = textBoxFirstName.Text;
            if (String.IsNullOrEmpty(cc.FirstName))
            {

                MessageBox.Show("Please select a contact to update!!!");
            }
            else
            {
                cc.ContactId = int.Parse(textBoxContactID.Text);
                cc.LastName = textBoxLastName.Text;
                cc.ContactNo = textBoxConatctNo.Text;
                cc.Address = textBoxAddress.Text;
                cc.Gender = comboBoxGender.Text;
                cc.FirstName = textBoxFirstName.Text;
                if (String.IsNullOrEmpty(cc.FirstName))
                {

                    MessageBox.Show("Please select a contact to delete!!!");
                }
                else
                {
                    bool nice = cc.Update(cc);
                    if (nice == true)
                    {
                        MessageBox.Show("Contact updated sucessfully");
                        //load data from database

                        DataTable dt = cc.Select();
                        ContactList.DataSource = dt;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error updating!!");
                    }

                }
            }


        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
           
            cc.FirstName = textBoxFirstName.Text;
            if (String.IsNullOrEmpty(cc.FirstName))
            { 
           
                MessageBox.Show("Please select a contact to delete!!!");
            }
            else
            {
                cc.ContactId = Convert.ToInt32(textBoxContactID.Text);
                bool well = cc.Delete(cc);
                if (well == true)
                {
                    MessageBox.Show("Contact Deleted successfully");
                    //load data from database

                    DataTable dt = cc.Select();
                    ContactList.DataSource = dt;
                    Clear();
                }
                else
                {
                    MessageBox.Show("Error while deleteing");
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //get the value from the inputs
            
            


            /*int j = 0;
            string test = cc.ContactNo;
            
            foreach (DataGridViewRow row in ContactList.Rows)
            {
                if (row.Cells[3].Value.ToString().Equals(test))//erreur
                {
                    j = j + 1;
                }
            }


            
           if (j != 0)
            {
                MessageBox.Show("This Contact already exist");
                Clear();
            }*/
            cc.FirstName = textBoxFirstName.Text;
            cc.LastName = textBoxLastName.Text;
            cc.ContactNo = textBoxConatctNo.Text;
            cc.Address = textBoxAddress.Text;
            cc.Gender = comboBoxGender.Text;
            if (String.IsNullOrEmpty(cc.FirstName) || String.IsNullOrEmpty(cc.LastName) || String.IsNullOrEmpty(cc.ContactNo) || String.IsNullOrEmpty(cc.Address) || String.IsNullOrEmpty(cc.Gender) )
            {

                MessageBox.Show("Please fill all the empty gaps to add!!!");
            }
            else
            {
                
                if (sc.Find(cc.ContactNo) == true)
                {
                    MessageBox.Show("Contact already exists");
                }
                else
                {
                    bool good = cc.Insert(cc);
                    if (good = true)
                    {
                        MessageBox.Show("New Conatct added successfully");
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error adding Contact!!");
                    }
                }
                //load data from database

                DataTable dt = cc.Select();
                ContactList.DataSource = dt;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            textBoxContactID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxConatctNo.Text = "";
            textBoxAddress.Text = "";
            comboBoxGender.Text = "";


        }

        private void ContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBoxContactID.Text = ContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxFirstName.Text = ContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxLastName.Text = ContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxConatctNo.Text = ContactList.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxAddress.Text = ContactList.Rows[rowIndex].Cells[4].Value.ToString();
            comboBoxGender.Text = ContactList.Rows[rowIndex].Cells[5].Value.ToString();

        }
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string hint = textBoxSearch.Text;
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dat = new DataTable();

            //SQL Query
            string sql = "SELECT * from  tbl_contact WHERE FirstName LIKE '%" + hint + "%' OR LastName LIKE '%" + hint + "%' OR ContactNo LIKE '%" + hint + "%' OR  Address LIKE '%" + hint + "%'";
            //using sql and conn
            SqlCommand cmd = new SqlCommand(sql, conn);
            //Create SQL dataadapter
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dat);
            ContactList.DataSource = dat;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ContactList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Gender_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void Address_Click(object sender, EventArgs e)
        {

        }

        private void textBoxConatctNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContactNumber_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void FirstName_Click(object sender, EventArgs e)
        {

        }

        private void textBoxContactID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConatctID_Click(object sender, EventArgs e)
        {

        }
    }
}
