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
using System.IO;
using System.Diagnostics;

namespace SystemParking
{
    public partial class FormParking : Form
    {
        string stringConnection = @"Data Source=HELLO-WORLD\MSSQLSERVER02;Initial Catalog=SystemParking;Integrated Security=True";
        int IndexDatagridView=0;
        // count vehecle
        int Vehecle = 0;
        // number of Parking and Leaved
        int Leaved = 0, Parking = 0;
        public FormParking()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            decimal TotalPrice = 0;
            dataGridViewParking.Refresh();
            try
            {
                dataGridViewParking.Refresh();
                //dataGridView.ClearSelection();
                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Close();
                    con.Open();
                    string AllData = "SELECT *FROM customer3";
                 
                    
                    using (SqlCommand cmd = new SqlCommand(AllData, con))
                    {
                        SqlDataAdapter ad = new SqlDataAdapter();
                        ad.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        dt.Clear();
                        ad.Fill(dt);
                        dataGridViewParking.DataSource = dt;
                        dataGridViewParking.Columns["IDSection"].Visible = false; // use for hide column
                        DataGridViewImageColumn pic = new DataGridViewImageColumn();
                        pic = (DataGridViewImageColumn)dataGridViewParking.Columns[9];
                        pic.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        // Assuming dataGridView is your DataGridView control
                        //int columnIndex1 = dataGridView.Columns["Column1"].DisplayIndex;
                        //int columnIndex2 = dataGridView.Columns["Column2"].DisplayIndex;
                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
            // Sum prices and vihecle 
            foreach (DataGridViewRow row in dataGridViewParking.Rows)
            {
                if (!row.IsNewRow) // Skip the new row if present
                {
                    Object cellValue = row.Cells["Price"].Value;
                    Vehecle += 1;
                    if (row.Cells[11].Value.ToString() == "Parked")
                    {
                        TotalPrice += Convert.ToDecimal(cellValue);
                        Parking += 1;
                    }
                    else
                    {
                        Leaved += 1;
                    }
                }
            }
            labelTotalPrice.Text = TotalPrice.ToString("c");

        }
        public void DeleteToHistory(string porpuse)
        {
            string query3 = "SET identity_insert HistoryParking3 on ;" +
               "insert into HistoryParking3 (ID,Section , Name, Phone, Type, HomeAddress, Price, PlateNo, Date,PicPlateNo,IDSection)" +
               "SELECT ID,Section , Name, Phone, Type, HomeAddress, Price, PlateNo, Date,PicPlateNo,IDSection FROM customer3 where ID = @id ";
            string query = "";
            string query1 = "delete from customer3 where ID = @id";
            string query2 = "update customer3 set Action = @Action where ID = @id"; 
            if(porpuse == "delete")
            {
                query = query1;
            }
            else
            {
                query = query2; 
            }
            try
            {
                DataGridViewRow data = dataGridViewParking.Rows[IndexDatagridView];
                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Close();
                    con.Open();
                    if(porpuse == "delete")
                    {
                        using (SqlCommand cmd = new SqlCommand(query3, con))
                        {
                            cmd.Parameters.AddWithValue("@id", data.Cells[0].Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", data.Cells[0].Value);
                        if(porpuse == "update")
                        {
                            cmd.Parameters.AddWithValue("@Action","Leaved");
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errors Please select Index ! \n{ex.Message}", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            GetData();
        }
       
        private void FormParking_Load(object sender, EventArgs e) // Main Form
        {
            GetData();
            ClassSql admin = new ClassSql();
            admin.GetAllData("Select *from FormAdmin", "FormAdmin");
            // number of admin
            labelUser.Text = admin.numberOfAdmin.ToString(); 
             // number of Parking
             labelVehicle.Text = Parking.ToString();
            // number of Leaved
            labelLeaved.Text = Leaved.ToString();
        }
        // Search Base on ID
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != "")
                {
                    using (SqlConnection con = new SqlConnection(stringConnection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM customer3 WHERE ID = @id", con))
                        {
                            cmd.Parameters.AddWithValue("@id", txtSearch.Text);
                            con.Close();
                            con.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = cmd;
                            DataTable table = new DataTable();
                            table.Clear();
                            adapter.Fill(table);
                            dataGridViewParking.DataSource = table;
    
                        }
                    }
                }
                else
                {
                    GetData();
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCellStyle style1 = new DataGridViewCellStyle();
                style1.ForeColor = Color.White;
                style1.BackColor = Color.RoyalBlue;

                DataGridViewCellStyle style2 = new DataGridViewCellStyle();
                style2.BackColor = Color.White;
                style2.ForeColor = Color.Black;
                if (e.RowIndex > -1)
                {
                    dataGridViewParking.Rows[e.RowIndex].DefaultCellStyle = style1;
                }
                if (e.RowIndex != IndexDatagridView && IndexDatagridView > -1)
                {
                    dataGridViewParking.Rows[IndexDatagridView].DefaultCellStyle = style2;
                }
            IndexDatagridView = e.RowIndex;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dataGridViewParking.Refresh();
                GetData();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteToHistory("delete");
        }

        private void dataGridViewParking_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridViewParking.Rows[e.RowIndex];
            if (row.Cells[11].Value.ToString() == "Parked")
            {
                row.Cells[11].Style.ForeColor = Color.DarkGreen;
            }
            else
            {
                row.Cells[11].Style.ForeColor = Color.DarkRed;
            }
        }

        private void buttonLeave_Click_1(object sender, EventArgs e)
        {
            DeleteToHistory("update");
        }
    }
}
