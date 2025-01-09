using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace SystemParking
{
    public partial class FormAdmin : Form
    {
        bool eye1 = true, eye2 = true;
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textUerName.Text == "UserName")
            {
                textUerName.Text = "";
                textUerName.ForeColor = Color.FromArgb(116, 114, 100);
            }
        }

        private void textUerName_Leave(object sender, EventArgs e)
        {
            if (textUerName.Text == "")
            {
                textUerName.Text = "UserName";
                textUerName.ForeColor = Color.DarkGray;
            }
        }
        private void textPhone_Enter(object sender, EventArgs e)
        {
            if (textPhone.Text == "Phone Number")
            {
                textPhone.Text = "";
                textPhone.ForeColor = Color.FromArgb(116, 114, 100);
            }
        }

        private void textPhone_Leave(object sender, EventArgs e)
        {
            if (textPhone.Text == "")
            {
                textPhone.Text = "Phone Number";
                textPhone.ForeColor = Color.DarkGray;
            }
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (textPassword.Text == "Password")
            {
                textPassword.Text = "";
                textPassword.ForeColor = Color.FromArgb(116, 114, 100);
            }
            if (textPassword.Text != "Password" && eye1 == true)
            {
                textPassword.PasswordChar = '*';
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (textPassword.Text == "")
            {
                textPassword.Text = "Password";
                textPassword.ForeColor = Color.DarkGray;
            }
            if (textPassword.Text == "Password" )
            {
                textPassword.PasswordChar = '\0';
            }
        }

        private void textEmail_Enter(object sender, EventArgs e)
        {
            if (textEmail.Text == "Email")
            {
                textEmail.Text = "";
                textEmail.ForeColor = Color.FromArgb(116, 114, 100);
            }
        }

        private void textEmail_Leave(object sender, EventArgs e)
        {
            if (textEmail.Text == "")
            {
                textEmail.Text = "Email";
                textEmail.ForeColor = Color.DarkGray;
            }
        }

        private void textComfirm_Enter(object sender, EventArgs e)
        {
            if (textComfirm.Text == "Comfirm Password")
            {
                textComfirm.Text = "";
                textComfirm.ForeColor = Color.FromArgb(116, 114, 100);
            }
            if(textComfirm.Text!= "Comfirm Password" && eye2 != false)
            {
                textComfirm.PasswordChar = '*';
            }
        }

        private void textComfirm_Leave(object sender, EventArgs e)
        {
            if (textComfirm.Text == "")
            {
                textComfirm.Text = "Comfirm Password";
                textComfirm.ForeColor = Color.DarkGray;
            }
            if (textComfirm.Text == "Comfirm Password")
            {
                textComfirm.PasswordChar = '\0';
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textAddress.Text == "")
            {
                textAddress.Text = "Current Address";
                textAddress.ForeColor = Color.DarkGray;
            }
        }

        private void textAddress_Enter(object sender, EventArgs e)
        {
            if(textAddress.Text == "Current Address")
            {
                textAddress.Text = "";
                textAddress.ForeColor = Color.FromArgb(116, 114, 100);
            }
        }
        private byte[] GetPhoto()
        {
            MemoryStream str = new MemoryStream();
            pictureBox1.Image.Save(str, pictureBox1.Image.RawFormat);
            return str.GetBuffer(); // or ToArray()
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string stringConnection = @"Data Source = HELLO-WORLD\MSSQLSERVER02 ;Initial Catalog =SystemParking;Integrated Security =true ";
                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Open();
                    string query = "Insert into [FormAdmin] (picture,userName,gender,phoneNumber,dateOfBirth,currentAddress,email,password,description)" +
                    " values(@picture,@userName,@gender,@phoneNumber,@dateOfBirth,@currentAddress,@email,@password,@description)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if(textPassword.Text == textComfirm.Text)
                        {
                            cmd.Parameters.AddWithValue("@userName", textUerName.Text);
                            cmd.Parameters.AddWithValue("@gender", textGender.Text);
                            cmd.Parameters.AddWithValue("@phoneNumber", int.Parse(textPhone.Text));
                            cmd.Parameters.AddWithValue("@dateOfBirth", textDate.Value);
                            cmd.Parameters.AddWithValue("@currentAddress", textAddress.Text);
                            cmd.Parameters.AddWithValue("@email", textEmail.Text);
                            cmd.Parameters.AddWithValue("@password", textPassword.Text);
                            cmd.Parameters.AddWithValue("@description", textDescription.Text);
                            cmd.Parameters.AddWithValue("@picture", GetPhoto());
                            cmd.ExecuteNonQuery();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please courrect the password !");
                        }
                    }
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Please select Image.";
            openFileDialog1.Filter = "All Files |*.*";
            //openFileDialog1.Filter = "All Files |*.*";

            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(eye2 == true)
            {
                pictureBox2.Image = new Bitmap(Properties.Resources.eye_15px);
                eye2 = false;
                textComfirm.PasswordChar = '\0';
            }
            else 
            {
                pictureBox2.Image = new Bitmap(Properties.Resources.hide_15px);
                eye2 = true;
                if (textComfirm.Text != "Comfirm Password")
                {
                    textComfirm.PasswordChar = '*';
                }
            }
        }

        private void textDescription_Enter(object sender, EventArgs e)
        {
            if(textDescription.Text == "Description")
            {
                textDescription.Text = "";
                textDescription.ForeColor = Color.FromArgb(116, 114, 100);
            }
        }

        private void textDescription_Leave(object sender, EventArgs e)
        {
            if(textDescription.Text == "")
            {
                textDescription.Text = "Description";
                textDescription.ForeColor = Color.DarkGray;
            }
        }

        private void textGender_Enter(object sender, EventArgs e)
        {
            if(textGender.Text == "Gender")
            {
                textGender.Text = "";
                textGender.ForeColor = Color.FromArgb(116, 114, 100);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(eye1 == true)
            {
                pictureBox3.Image = new Bitmap(Properties.Resources.eye_15px);
                eye1 = false;
                textPassword.PasswordChar = '\0';
            }
            else
            {
                pictureBox3.Image = new Bitmap(Properties.Resources.hide_15px);
                eye1 = true;
                if(textPassword.Text != "Password")
                {
                    textPassword.PasswordChar = '*';
                }
            }
            pictureBox3.Anchor = AnchorStyles.Left;
        }
    }
}
