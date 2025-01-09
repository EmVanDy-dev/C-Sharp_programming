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
    public partial class ParkingForm : Form
    {
        static Form  sForm =  null;
        bool swich = true;
        public ParkingForm()
        {
            InitializeComponent();
        }
        public static void openForm(Form childForm)
        {
            if(sForm != null)
            {
                sForm.Close();
            }
            sForm = childForm;
            childForm.TopLevel = false;
            panelForm.Controls.Add(childForm);
            panelForm.BringToFront();
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }
       public void FormColor(string color)
        {
            btnSection.BackColor = color != "Section" ? Color.FromArgb(120, 111, 112) : Color.FromArgb(146, 137, 138);
            btnAdmin.BackColor = color != "Admin" ? Color.FromArgb(120, 111, 112) : Color.FromArgb(146, 137, 138); 
            btnReport.BackColor = color != "Report" ? Color.FromArgb(120, 111, 112) : Color.FromArgb(146, 137, 138);
            btnParking.BackColor = color != "Parking" ? Color.FromArgb(120, 111, 112) : Color.FromArgb(146, 137, 138);
            btnDashborad.BackColor = color != "Dashborad" ? Color.FromArgb(120, 111, 112) : Color.FromArgb(146, 137, 138);
            btnCustomer.BackColor = color != "Customer" ? Color.FromArgb(120, 111, 112) : Color.FromArgb(146, 137, 138);
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            FormColor("Report");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MainForm.ActiveForm.WindowState = FormWindowState.Normal;
            //MainForm.ActiveForm.TopMost = true;
            this.Close();
        }

        private void btnSection_Click(object sender, EventArgs e)
        {
            openForm(new FormSection());
            FormColor("Section");
        }

        private void ParkingForm_Load(object sender, EventArgs e)
        {
            panel5.Height = 0;
            this.WindowState = FormWindowState.Maximized;
            openForm(new DashboardForm());
        }

        private void btnParking_Click(object sender, EventArgs e)
        {
            //if (swich == true)
            //{
            //    panel5.Height = 80;
            //    swich = false;
            //}
            //else
            //{
            //    panel5.Height = 0;
            //    swich = true;
            //}
            FormColor("Parking");
            openForm(new FormParking());
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            openForm(new FormDashboardAdmin());
            FormColor("Admin");
        }

        private void labelAll_Click(object sender, EventArgs e)
        {
            //openForm(new FormParking());
            //panelLineAll.BackColor = Color.FromArgb(255, 237, 216);
            //panelLineSection.BackColor = Color.FromArgb(146, 137, 138);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //openForm(new FormParking());
            //panelLineAll.BackColor = Color.FromArgb(255, 237, 216);
            //panelLineSection.BackColor = Color.FromArgb(146, 137, 138);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FormColor("Dashborad");
            openForm(new DashboardForm());

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FormColor("Customer");
            openForm(new FormHistory());
        }



        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //panelLineSection.BackColor = Color.FromArgb(255, 237, 216);
            //panelLineAll.BackColor = Color.FromArgb(146, 137, 138);
        }

        private void labelSection_Click(object sender, EventArgs e)
        {
            //panelLineSection.BackColor = Color.FromArgb(255, 237, 216);
            //panelLineAll.BackColor = Color.FromArgb(146, 137, 138);
        }
    }
}
