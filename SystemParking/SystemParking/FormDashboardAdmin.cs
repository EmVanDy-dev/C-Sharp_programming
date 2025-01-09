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

namespace SystemParking
{
    public partial class FormDashboardAdmin : Form
    {
        bool sw = true;
        int RowIndex;
        string  strCon = @"Data Source = HELLO-WORLD\MSSQLSERVER02;Initial Catalog=SystemParking;Integrated Security = true";

        public FormDashboardAdmin()
        {
            InitializeComponent();
        }
        private void DeleteData()
        {
            try
            {
                string query = "delete from FormAdmin where id = @id";
                string quer2 = "set identity_insert FormAdminDelete on ;" +
                    "insert into FormAdminDelete" +
                    "(picture,id,userName,gender,phoneNumber,dateOfBirth,currentAddress,email,password,description)  " +
                    "SELECT picture,id,userName,gender,phoneNumber,dateOfBirth,currentAddress,email,password,description from FormAdmin where id = @id";
                string qry = "";
                if (sw == true)
                {
                    qry = quer2;
                    sw = false;
                }
                else
                {
                    qry = query;
                    sw = true;
                }
                DataGridViewRow data = dataGridViewAdmin.Rows[RowIndex];
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@id", data.Cells[1].Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
            
        }
        private void CollectData(string name)
        {
            try
            {
                string data = "";
                if (name == "search")
                {
                    data = "Select * from FormAdmin where id = @id";
                }
                else if (name == "all")
                {
                    data = "select *from FormAdmin  order by id desc";
                }
                using (SqlConnection con = new SqlConnection(strCon))
                {

                    using (SqlCommand cmd = new SqlCommand(data, con))
                    {
                        con.Open();
                        if (name == "search") cmd.Parameters.AddWithValue("@id", txtSearch.Text);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable tb = new DataTable();
                        tb.Clear();
                        da.Fill(tb);
                        dataGridViewAdmin.DataSource = tb;
                        DataGridViewImageColumn pic = new DataGridViewImageColumn();
                        pic = (DataGridViewImageColumn)dataGridViewAdmin.Columns[0];
                        pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        pic.Width = 50;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridViewAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormAdmin f = new FormAdmin();
            f.Show();
        }

        private void FormDashboardAdmin_Load(object sender, EventArgs e)
        {
            CollectData("all");

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CollectData("all");
        }

        private void dataGridViewAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search";
                txtSearch.ForeColor = Color.DarkGray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search" || txtSearch.Text == "")
            {
                CollectData("all");
            }
            else
            {
                CollectData("search");
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            DeleteData();
            CollectData("all");
        }
    }
}
