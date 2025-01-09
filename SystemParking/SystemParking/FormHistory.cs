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
    public partial class FormHistory : Form
    {
        bool sw = true;
        int Index;
        public FormHistory()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=HELLO-WORLD\MSSQLSERVER02;Initial Catalog = SystemParking ;Integrated Security = true");
        // Function Get All Data
        public void GetAllData()
        {
            string query = "select *from HistoryParking3 ";
            string query2 = "select *from FormAdminDelete order by id desc";
            string qry;
            if (sw == true) // True mean use HistoryParking3
            {
                qry = query;
            }
            else
            {
                qry = query2;
            }
            try
            {
                dataGridView1.Refresh();
                con.Open();
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlAdapter.SelectCommand = cmd;
                    DataTable data = new DataTable();
                    data.Clear();
                    sqlAdapter.Fill(data);
                    dataGridView1.DataSource = data;

                    DataGridViewImageColumn pic = new DataGridViewImageColumn();
                    int columnPic = sw == true ? 9 : 0;
                        pic = (DataGridViewImageColumn)dataGridView1.Columns[columnPic];
                        pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        pic.Width = 50;
                }
                con.Close();
        }
            catch(Exception ex)
            {
                MessageBox.Show($"Error :{ex.Message}");
            }

}
        // Function Delete Data
        private void DeleteSearcheData(string action = null)
        {
            string query = "delete from HistoryParking3 where ID = @id";
            string query2 = "delete from FormAdminDelete where id = @id";
            string query3 = "select *from HistoryParking3 where ID = @id";
            string query4 = "select *from FormAdminDelete where id = @id";
            
            string qry = "";
            if(action == "delete")
            {
                qry = sw == true ? query : query2;
            }else if(action == "select")
            {
                qry = sw == true ? query3 : query4;
            }
            //try
            //{
                con.Open();
                DataGridViewRow data = Index >= 0 && Index < dataGridView1.Rows.Count ? dataGridView1.Rows[Index] : null ;
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    string items = "";
                    if (action == "delete" && data != null)
                    {
                        items = sw == true ? data.Cells[0].Value.ToString() : data.Cells[1].Value.ToString();
                    }
                    else if (action == "select" && txtSearch.Text != "ID")
                    {
                        items = txtSearch.Text;
                    }
                    cmd.Parameters.AddWithValue("@id",items);
                    if(txtSearch.Text != "ID" && items != null && txtSearch.Text != "")
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        //DataTable dataSet = new DataTable();
                        DataSet dataSet = new DataSet();
                        dataSet.Clear();
                        adapter.Fill(dataSet);
                        dataGridView1.DataSource = dataSet.Tables[0];
                    }
                    cmd.ExecuteNonQuery();
                }
                con.Close();
        //}
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error : {ex.Message}");
        //    }
}
        private void FormHistory_Load(object sender, EventArgs e)
        {
            GetAllData();
        }


        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            groupBox1.Text = "Delete";
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            groupBox1.Text = "History";
        }

        private void btnRestore_MouseHover(object sender, EventArgs e)
        {
            groupBox1.Text = "Restore😍";
        }

        private void btnRestore_MouseLeave(object sender, EventArgs e)
        {
            groupBox1.Text = "History";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sw == true)
            {
                btnSwitch.Image = Image.FromHbitmap(Properties.Resources.back_arrow_35px.GetHbitmap());
                sw = false;
            }
            else
            {
                btnSwitch.Image = Image.FromHbitmap(Properties.Resources.forward_button_35px.GetHbitmap());
                sw = true;
            }
            GetAllData();
        }

        private void btnSwitch_MouseHover(object sender, EventArgs e)
        {
            if (sw == true)
            {
                groupBox1.Text = "History of admin";
            }
            else
            {
                groupBox1.Text = "History of customer";
            }
        }

        private void btnSwitch_MouseLeave(object sender, EventArgs e)
        {
            groupBox1.Text = "History";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSearcheData("delete");
            GetAllData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Index = e.RowIndex;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if(txtSearch.Text == "ID")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }   
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                txtSearch.Text = "ID";
                txtSearch.ForeColor = Color.DarkGray;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into customer3(Section , Name, Phone, Type, HomeAddress, Price, PlateNo, Date,PicPlateNo,IDSection , Action)" +
                "select Section , Name, Phone, Type, HomeAddress, Price, PlateNo, Date,PicPlateNo,IDSection , Action ='Parked' from HistoryParking3 where ID = @id";
                string query2 = "insert into FormAdmin(picture,userName,gender,phoneNumber,dateOfBirth,currentAddress,email,password,description)" +
                    "select picture,userName,gender,phoneNumber,dateOfBirth,currentAddress,email,password,description from FormAdminDelete where id = @id";
                string qry = sw == true ? query : query2;

                DataGridViewRow data = dataGridView1.Rows[Index];
                con.Open();
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                var items = sw == true ? data.Cells[0].Value : data.Cells[1].Value;
                    cmd.Parameters.AddWithValue("@id", items);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DeleteSearcheData("delete");
            GetAllData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" || txtSearch.Text == "ID")
            {
                GetAllData();
            }
            else
            {
                DeleteSearcheData("select");
            }
        }
    }
}
