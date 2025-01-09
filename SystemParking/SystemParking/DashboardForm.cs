using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SystemParking
{
    public partial class DashboardForm : Form
    {

        decimal[] TotalSection = new decimal[5];
        LinkedList<int> countSection = new LinkedList<int>();

        int[] sumMonth = new int[12];
        LinkedList<string> section = new LinkedList<string>();
        LinkedList<string> section2 = new LinkedList<string>();
        LinkedList<int> count1 = new LinkedList<int>();

        LinkedList<string> current = new LinkedList<string>();
        LinkedList<string> year = new LinkedList<string>();
        LinkedList<int> count2 = new LinkedList<int>();
        public DashboardForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = HELLO-WORLD\MSSQLSERVER02 ;Initial Catalog = SystemParking ;Integrated Security = true;");
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            //try
            //{
                con.Close();
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select *from FormAdmin", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Total User
                            TotalSection[3] += 1;
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("select *from section3 ", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            section.AddLast(reader.GetString(1));
                            countSection.AddLast(reader.GetInt32(2));
                            TotalSection[0] += 1;
                        }
                    }
                }


                using (SqlCommand cmd = new SqlCommand("select *from customer3 ", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //desclare
                            DateTime date = reader.GetDateTime(8);
                            int ss3 = date.Month;
                            string yy = date.Year.ToString();

                            // Total Price
                            TotalSection[4] += reader.GetDecimal(6);
                            // Total Parking
                            string Action = reader.GetString(11);
                            if (Action == "Parked")
                            {
                                TotalSection[2] += 1;
                            }

                            // chart Yearly
                            year.AddLast(yy);
                            // chart Monthly
                            string section3 = reader.GetString(1);
                            for (int i = 0; i < 12; i++)
                            {
                                if (ss3 == i + 1)
                                {
                                    sumMonth[i] += 1;
                                }
                            }
                            section2.AddLast(section3);
                        }
                        chart1.Series["Monthly"].Points.AddXY("Janjuary", sumMonth[0]);
                        chart1.Series["Monthly"].Points.AddXY("February", sumMonth[1]);
                        chart1.Series["Monthly"].Points.AddXY("March", sumMonth[2]);
                        chart1.Series["Monthly"].Points.AddXY("April", sumMonth[3]);
                        chart1.Series["Monthly"].Points.AddXY("May", sumMonth[4]);
                        chart1.Series["Monthly"].Points.AddXY("June", sumMonth[5]);
                        chart1.Series["Monthly"].Points.AddXY("July", sumMonth[6]);
                        chart1.Series["Monthly"].Points.AddXY("August", sumMonth[7]);
                        chart1.Series["Monthly"].Points.AddXY("September", sumMonth[8]);
                        chart1.Series["Monthly"].Points.AddXY("October", sumMonth[9]);
                        chart1.Series["Monthly"].Points.AddXY("November", sumMonth[10]);
                        chart1.Series["Monthly"].Points.AddXY("December", sumMonth[11]);
                        // chart Section

                        foreach (var i in section)
                        {
                            count1.AddLast(section2.Count(n => n == i));
                        }
                        var combined = count1.Zip(section, (countValue, sectionValue) => new { Count = countValue, Section = sectionValue });
                        TotalSection[1] = TotalSection[0];
                        foreach (var i in combined)
                        {
                            chart2.Series["Section"].Points.AddXY(i.Section, i.Count);
                            foreach (var j in countSection)
                            {
                                if (i.Count == j)
                                {
                                    TotalSection[1] = TotalSection[1] - 1;
                                }
                            }
                        }


                        // chart yearly
                        foreach (var i in year)
                        {
                            if (!current.Contains(i))
                            {
                                current.AddLast(i);
                            }
                        }
                        foreach (var i in current)
                        {
                            count2.AddLast(year.Count(n => n == i));
                        }
                        var combined2 = count2.Zip(current, (countvalue, yearvalue) => new { countValue1 = countvalue, yearValue1 = yearvalue });
                        foreach (var i in combined2)
                        {

                            chart3.Series["Yearly"].Points.AddXY(i.yearValue1, i.countValue1);
                        }


                    }

                    labelPrice.Text = TotalSection[4].ToString("C2");
                    labelParking.Text = TotalSection[2].ToString();
                    labelUser.Text = TotalSection[3].ToString();
                    labelSlot.Text = (TotalSection[0] - TotalSection[1]).ToString() + "/" + TotalSection[0].ToString();

                }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show($"Error : {ex.Message}");
            //}
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ParkingForm.openForm(new FormSection());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ParkingForm.openForm(new FormSection());
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ParkingForm.openForm(new FormParking());
        }

        private void pictureBoxParking_Click(object sender, EventArgs e)
        {
            ParkingForm.openForm(new FormParking());
        }

        private void labelSystemUser_Click(object sender, EventArgs e)
        {
            ParkingForm.openForm(new FormDashboardAdmin());
        }

        private void pictureBoxUser_Click(object sender, EventArgs e)
        {
            ParkingForm.openForm(new FormDashboardAdmin());
        }

        private void labelTotalPrice_Click(object sender, EventArgs e)
        {
            ParkingForm.openForm(new FormSection());
        }

        private void pictureBoxPrice_Click(object sender, EventArgs e)
        {
            ParkingForm.openForm(new FormSection());
        }
    }
}
