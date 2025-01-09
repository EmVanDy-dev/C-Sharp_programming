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

namespace SystemParking
{
    public partial class FormCustomer : Form
    {
        public string section { get; set; }
        public string[] price { get; set; }
        int TotalCapacity = 0;
        int countRow = 0;
        string name;
        string name2;
        int ID;

        public SqlConnection con = new SqlConnection(@"Data source=HELLO-WORLD\MSSQLSERVER02;Initial Catalog=SystemParking;Integrated security=True");
        public FormCustomer()
        {
            InitializeComponent();
        }
        private byte[] GetPhoto() // function for format photo to binary
        {
            MemoryStream str = new MemoryStream();
            pictureBoxPlatNo.Image.Save(str, pictureBoxPlatNo.Image.RawFormat);
            return str.GetBuffer(); // ToArray();
        }
        public void GetValue(string sectionName)
        {
            //try
            //{
                con.Open();
                string GetSection = "SELECT *FROM section3";
                string AddCostomer = "set identity_insert customer3 off ;" +
                    "INSERT INTO [customer3]  (Section,Name,Phone,Type,HomeAddress,Price,Date,PlateNo,PicPlateNo,IDSection,Action) " +
                    "VALUES (@section,@driver,@phone,@type,@homeAddress,@price,@date,@plateNo,@PicPlateNo,@IDSection,'Parked')";
                string SelectCustomer = "Select *from customer3";
                string GetData = "";
                if (sectionName == "get" || sectionName == "choose")
                {
                    GetData = GetSection;
                }
                else if (sectionName == "AddCostomer")
                {
                    GetData = AddCostomer;
                }
                else if (sectionName == "selectCustomer")
                {
                    GetData = SelectCustomer;
                }



                using (SqlCommand cmd = new SqlCommand(GetData, con))
                {
                    if (sectionName == "get" || sectionName == "choose")
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (sectionName == "get")
                            {
                                while (reader.Read())
                                {
                                    ID = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    ComboSection.Items.Add(name);
                                }
                            }
                            else if (sectionName == "choose")
                            {
                                while (reader.Read())
                                {
                                    var price = reader.GetValue(3);
                                    name = reader.GetString(1);
                                    
                                    if (ComboSection.Text == name)
                                    {
                                        textAmount.Text = price.ToString();
                                        textAmount.ForeColor = Color.Black;
                                        TotalCapacity = reader.GetInt32(2);
                                    }
                                }
                            }

                        }
                    }
                    // Add items into customer
                    else if (sectionName == "AddCostomer")
                    {

                        //string an = textAmount.Text.Split()[0].Substring(1);
                        if ( countRow <= TotalCapacity)
                        {
                            cmd.Parameters.AddWithValue("@section", ComboSection.Text);
                            cmd.Parameters.AddWithValue("@driver", textDriver.Text);
                            cmd.Parameters.AddWithValue("@phone", textPhone.Text);
                            cmd.Parameters.AddWithValue("@type", textPype.Text);
                            cmd.Parameters.AddWithValue("@homeAddress", textAddress.Text);
                            cmd.Parameters.AddWithValue("@price", textAmount.Text);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").ToString());
                            cmd.Parameters.AddWithValue("@plateNo", textPlateNo.Text);
                            cmd.Parameters.AddWithValue("@PicPlateNo",GetPhoto());
                            cmd.Parameters.AddWithValue("@IDSection", ID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"Successfully!");
                        }
                        else
                        {
                            MessageBox.Show($"Section is Full! {countRow}");
                        }
                    }
                    // count how many item in section
                    else if (sectionName == "selectCustomer")
                    {
                        countRow = 0;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string ss = reader.GetString(1);
                                if (ComboSection.Text == ss)
                                {
                                    countRow += 1;
                                    name2 = ss;
                                }
                            }
                        }
                    }
                }
                con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textPlateNo.Text == "")
            {
                textPlateNo.Text = "Plate No";
                textPlateNo.ForeColor = Color.DarkGray;
            }
        }

        private void textPlateNo_Enter(object sender, EventArgs e)
        {
            if (textPlateNo.Text == "Plate No")
            {
                textPlateNo.Text = "";
                textPlateNo.ForeColor = Color.Black;
            }
        }

        private void textPype_Enter(object sender, EventArgs e)
        {
            if (textPype.Text == "Type")
            {
                textPype.Text = "";
                textPype.ForeColor = Color.Black;
            }
        }

        private void textPype_Leave(object sender, EventArgs e)
        {
            if (textPype.Text == "")
            {
                textPype.Text = "Type";
                textPype.ForeColor = Color.DarkGray;
            }
        }
        private void textDriver_Enter(object sender, EventArgs e)
        {
            if (textDriver.Text == "Driver")
            {
                textDriver.Text = "";
                textDriver.ForeColor = Color.Black;
            }
        }

        private void textDriver_Leave(object sender, EventArgs e)
        {
            if (textDriver.Text == "")
            {
                textDriver.Text = "Driver";
                textDriver.ForeColor = Color.DarkGray;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (ComboSection.Text == "Section")
            {
                ComboSection.Text = "";
                ComboSection.ForeColor = Color.Black;
            }
        }

        private void textSection_Leave(object sender, EventArgs e)
        {
            if (ComboSection.Text == "")
            {
                ComboSection.Text = "Section";
                ComboSection.ForeColor = Color.DarkGray;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textPhone.Text == "Phone")
            {
                textPhone.Text = "";
                textPhone.ForeColor = Color.Black;
            }
        }

        private void textPhone_Leave(object sender, EventArgs e)
        {
            if (textPhone.Text == "")
            {
                textPhone.Text = "Phone";
                textPhone.ForeColor = Color.DarkGray;
            }
        }


        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textAmount.Text == "Price")
            {
                textAmount.Text = "";
                textAmount.ForeColor = Color.Black;
            }
        }

        private void textAmount_Leave(object sender, EventArgs e)
        {
            if (textAmount.Text == "")
            {
                textAmount.Text = "Price";
                textAmount.ForeColor = Color.DarkGray;
            }
        }
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss");
            labelDate.Text = DateTime.Now.ToLongDateString();
            this.Size = new System.Drawing.Size(600, 800);
            timer1.Start();
            GetValue("get");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss");  //or use :  DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (textAddress.Text == "Home Adress")
            {
                textAddress.Text = "";
                textAddress.ForeColor = Color.Black;
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (textAddress.Text == "")
            {
                textAddress.Text = "Home Adress";
                textAddress.ForeColor = Color.DarkGray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //INPUT
            GetValue("AddCostomer");
            GetValue("selectCustomer");

        }

        private void ComboSection_Click(object sender, EventArgs e)
        {
            GetValue("choose");
            GetValue("selectCustomer");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboSection_MouseClick(object sender, MouseEventArgs e)
        {
            GetValue("choose");
            GetValue("selectCustomer");
        }

        private void pictureBoxPlatNo_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Open File!";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.CheckFileExists)
                {
                    pictureBoxPlatNo.Image = Bitmap.FromFile(dialog.FileName);
                    pictureBoxPlatNo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
