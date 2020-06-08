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
using System.Net;

namespace PhramMedicApp
{
    public partial class MedicineDisplayECZ : Form
    {
        public string status { get; set; }
        SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder()
        {
            DataSource = "medic-server.database.windows.net",
            UserID = "medic_admin",
            Password = "sXbPj8pMzy",
            InitialCatalog = "MedicAppDB"
        };

        public MedicineDisplayECZ()
        {
            InitializeComponent();
        }

        private void MedicineDisplayECZ_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connStr.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from t_medicine", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        medicineList.DataSource = dataTable;
                        reader.Close();
                    }
                }


                using (SqlCommand command1 = new SqlCommand("select name from t_medicine", connection))
                {
                    using (SqlDataReader reader1 = command1.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            medicineCB.Items.Add(reader1["name"]);
                        }
                        reader1.Close();
                    }
                }
                connection.Close();
            }
        }

        private void dispMed_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr.ConnectionString))
                {
                    medicineList.DataSource = null;
                    prosRTB.Clear();
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from t_medicine where name='" + medicineCB.SelectedItem.ToString() + "'", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            medicineList.DataSource = dt;
                        }
                    }

                    using (SqlCommand command1 = new SqlCommand("select prospectus from t_prospectus where name = '" + medicineCB.SelectedItem.ToString() + "'", connection))
                    {
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                prosRTB.Text = reader1["prospectus"].ToString();
                            }
                        }
                    }

                    using (SqlCommand command2 = new SqlCommand("select * from t_medicine_pic where name = '" + medicineCB.SelectedItem.ToString() + "'", connection))
                    {
                        string url = "https://";
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                url += reader2["picture_path"].ToString();
                            }
                        }

                        var request = WebRequest.Create(url);
                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream())
                        {
                            medPic.Image = Bitmap.FromStream(stream);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir ilaç seçmediniz!\n" + ex.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MedicineDisplayECZ_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dispStock_Click(object sender, EventArgs e)
        {
            StockDisp stockDisp = new StockDisp(this.status);
            stockDisp.Show();
        }

        private void dispQR_Click(object sender, EventArgs e)
        {
            Camera camx = new Camera();
            camx.ShowDialog();
            while (camx.a)
            {
                
                SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
                conn.DataSource = "medic-server.database.windows.net";
                conn.UserID = "medic_admin";
                conn.Password = "sXbPj8pMzy";
                conn.InitialCatalog = "MedicAppDB";

                this.prosRTB.Clear();
                using (SqlConnection conx = new SqlConnection(conn.ConnectionString))
                {
                    using (SqlCommand cmd3 = new SqlCommand("select * from t_medicine where barcode = '" + camx.barcode + "'"))
                    {
                        cmd3.Connection = conx;
                        conx.Open();
                        using (SqlDataReader rde = cmd3.ExecuteReader())
                        {

                            DataTable dt = new DataTable();
                            dt.Load(rde);
                            this.medicineList.DataSource = dt;
                        }
                        conx.Close();
                    }
                    using (SqlCommand cmd4 = new SqlCommand("select prospectus from t_prospectus where barcode = '" + camx.barcode + "'"))
                    {
                        cmd4.Connection = conx;
                        conx.Open();
                        using (SqlDataReader rdx = cmd4.ExecuteReader())
                        {
                            while (rdx.Read())
                            {
                                this.prosRTB.Text = rdx.GetValue(0).ToString();
                            }
                        }
                        conx.Close();
                    }
                    using (SqlCommand cmd5 = new SqlCommand("select picture_path from t_medicine_pic where barcode = '" + camx.barcode + "'"))
                    {
                        cmd5.Connection = conx;
                        conx.Open();
                        using (SqlDataReader rdr1 = cmd5.ExecuteReader())
                        {
                            while (rdr1.Read())
                            {
                                WebRequest request = WebRequest.Create("https://" + rdr1.GetValue(0).ToString());

                                using (var response = request.GetResponse())
                                {
                                    using (var str = response.GetResponseStream())
                                    {
                                        this.medPic.Image = Bitmap.FromStream(str);
                                        camx.a = false;
                                    }
                                }
                            }
                        }
                        conx.Close();
                        
                    }
                }
            }
        }
    }
}