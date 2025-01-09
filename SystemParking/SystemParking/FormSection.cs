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
    public partial class FormSection : Form
    {
        //private const string stringconnection = @"Data Source=HI\MSSQLSERVER02;Initial Catalog=SystemParking;Integrated Security=True";
        //public string name { get; set; }
        public DataGridView data;
        int numNo = 1;
        int IndexEdit;
        public string[] arr = new string[600];
        bool Edit = false;


        SqlConnection con = new SqlConnection(@"Data source =HELLO-WORLD\MSSQLSERVER02 ;Initial Catalog =SystemParking ;Integrated security = True");
        public FormSection()
        {
            InitializeComponent();
        }
        public void InsertValue(string name)
        {
            try
            {
                con.Open();
                string Items;
                string addItems = "INSERT INTO [section3] (name,capacity,cost,description) VALUES (@name,@capacity,@cost,@description)";
                string edit = "Update  section3 set name = @name , capacity = @capacity ,cost = @cost,description = @description  where id = @id ";
                string getItems = "SELECT *FROM section3";
                string delateItems = "DELETE FROM section3 WHERE id = @id";
                if (name.ToLower() == "add")
                {
                    btnDalate.ForeColor = Color.Black;
                    btnEdite.ForeColor = Color.Black;
                    btnAdd.ForeColor = Color.Firebrick;

                    Items = addItems;
                    using (SqlCommand cmd = new SqlCommand(Items, con))
                    {
                        cmd.Parameters.AddWithValue("@name", texName.Text);
                        cmd.Parameters.AddWithValue("@capacity", texCapacity.Text);
                        cmd.Parameters.AddWithValue("@cost", textCost.Text);
                        cmd.Parameters.AddWithValue("@description", textDecription.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (name.ToLower() == "get")
                {
                    dataGrid.Rows.Clear();
                    //dataGrid.Refresh();
                    Items = getItems;
                    using (SqlCommand cmd = new SqlCommand(Items, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string Sname = reader.GetString(1);
                                int capacity = reader.GetInt32(2);
                                var cost = reader.GetValue(3);
                                string description = reader.GetString(4);
                                dataGrid.Rows.Add(id.ToString("D4"), Sname, capacity.ToString(), cost.ToString(), description);
                                numNo++;
                            }
                        }
                    }
                }
                else if (name.ToLower() == "delate")
                {
                    btnDalate.ForeColor = Color.Firebrick;
                    btnEdite.ForeColor = Color.Black;
                    btnAdd.ForeColor = Color.Black;

                    Items = delateItems;
                    using (SqlCommand cmd = new SqlCommand(Items, con))
                    {
                        //int countIndex = dataGrid.Rows.Count;
                        //if (IndexEdit<countIndex && IndexEdit>=0)
                        //{
                        //    DataGridViewRow data = dataGrid.Rows[IndexEdit];
                        //    string[] cost = data.Cells[3].Value.ToString().Split();
                        //    string cost2 = cost[0].Substring(1);

                        //    cmd.Parameters.AddWithValue("@name", data.Cells[1].Value);
                        //    cmd.Parameters.AddWithValue("@capacity", data.Cells[2].Value);
                        //    cmd.Parameters.AddWithValue("@cost", cost2);
                        //    cmd.Parameters.AddWithValue("@description", data.Cells[4].Value);
                        //    cmd.ExecuteNonQuery();

                        //    dataGrid.Rows.RemoveAt(IndexEdit);

                        //        for (int i = IndexEdit; i < countIndex - 1; i++)
                        //        {
                        //            DataGridViewRow newdata = dataGrid.Rows[IndexEdit];
                        //            newdata.Cells[0].Value = (i + 1).ToString();
                        //            numNo = i + 2;
                        //            IndexEdit++;
                        //        }
                        DataGridViewRow data = dataGrid.Rows[IndexEdit];
                        cmd.Parameters.AddWithValue("@id", data.Cells[0].Value);
                        cmd.ExecuteNonQuery();
                        if (numNo == 0)
                        {
                            Edit = false;
                        }

                    }

                }
                else if (name.ToLower() == "edit")
                {
                    Items = edit;
                    DataGridViewRow data = dataGrid.Rows[IndexEdit];
                    using (SqlCommand cmd = new SqlCommand(Items, con))
                    {
                        cmd.Parameters.AddWithValue("@name", texName.Text);
                        cmd.Parameters.AddWithValue("@capacity", int.Parse(texCapacity.Text));
                        cmd.Parameters.AddWithValue("@cost", float.Parse(textCost.Text));
                        cmd.Parameters.AddWithValue("@description", textDecription.Text);
                        cmd.Parameters.AddWithValue("@id", data.Cells[0].Value);
                        cmd.ExecuteNonQuery();
                    }
                    string newItem = "update customer3 set Section = @section , Price = @price where IDSection = @idSection";
                    using (SqlCommand cmd = new SqlCommand(newItem, con))
                    {
                        cmd.Parameters.AddWithValue("@section", texName.Text);
                        cmd.Parameters.AddWithValue("@price", float.Parse(textCost.Text));
                        cmd.Parameters.AddWithValue("@idSection", data.Cells[0].Value);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
            con.Close();
        }
        private void FormSection_Load(object sender, EventArgs e)
        {
            dataGrid.Font = new System.Drawing.Font("Segoe Print", 10, FontStyle.Bold);
            InsertValue("get");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {           
            //dataGrid.Rows.Add(numNo.ToString(), texName.Text, texCapacity.Text, textCost.Text, textDecription.Text);
            //dataGrid.Rows.Add(numNo.ToString(), texName.Text, texCapacity.Text, textCost.Text, textDecription.Text);
            numNo=1;
            Edit = true;
            dataGrid.Rows.Clear();
            InsertValue("add");
            InsertValue("get");
        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            
            btnDalate.ForeColor = Color.Black;
            btnEdite.ForeColor = Color.Firebrick;
            btnAdd.ForeColor = Color.Black;
            InsertValue("edit");
            InsertValue("get");
        }

        private void btnDalate_Click(object sender, EventArgs e)
        {
            InsertValue("delate");
            InsertValue("get");
        }
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IndexEdit = e.RowIndex;
        }
    }
}
 