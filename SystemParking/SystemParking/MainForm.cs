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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = HELLO-WORLD\MSSQLSERVER02;Initial Catalog = SystemParking;Integrated Security = true");
        public void Login()
        {
            try
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM FormAdmin where userName = @username and email = @email and password = @password", con))
                {
                    cmd1.Parameters.AddWithValue("@username", textUserName.Text);
                    cmd1.Parameters.AddWithValue("@email", texEmail.Text);
                    cmd1.Parameters.AddWithValue("@password", textPassword.Text);
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader.GetString(2);
                            string email = reader.GetString(7);
                            string password = reader.GetString(8);
                            if (username.ToLower() == textUserName.Text.ToLower())
                            {
                                if (email == texEmail.Text)
                                {
                                    if (password == textPassword.Text)
                                    {
                                        DialogResult result = MessageBox.Show("Complete successfully!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                                        if (result == DialogResult.OK)
                                        {
                                            ParkingForm s = new ParkingForm();
                                            s.Show();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Complete is wrong!");
                        }
                    }
                }

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
            
           
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Focus(); 
            this.ActiveControl = null;
            this.Size = new System.Drawing.Size(450, 700);
        }

 

        private void texEmail_Enter(object sender, EventArgs e)
        {
            if(texEmail.Text == "Email Address or Phone number")
            {
                texEmail.Text = "";
                texEmail.ForeColor = Color.Black;
            }
        }

        private void texEmail_Leave(object sender, EventArgs e)
        {
            if(texEmail.Text == "")
            {
                texEmail.Text = "Email Address or Phone number";
                texEmail.ForeColor = Color.DarkGray;
            }
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if(textPassword.Text == "Password")
            {
                textPassword.Text = "";
                textPassword.ForeColor = Color.Black;
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if(textPassword.Text == "")
            {
                textPassword.Text = "Password";
                textPassword.ForeColor = Color.DarkGray;
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            FormCustomer FC = new FormCustomer();
            FC.Show();
        }

        private void textUserName_Enter(object sender, EventArgs e)
        {
            if(textUserName.Text== "UserName")
            {
                textUserName.Text = "";
                textUserName.ForeColor = Color.Black;
            }
        }

        private void textUserName_Leave(object sender, EventArgs e)
        {
            if(textUserName.Text == "")
            {
                textUserName.Text = "UserName";
                textUserName.ForeColor = Color.DarkGray;
            }
        }
    }
}
