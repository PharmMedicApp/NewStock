using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace PhramMedicApp
{
    public partial class MedicineDisplay : Form
    {

        public MedicineDisplay()
        {
            InitializeComponent();
        }
        private void MedicineDisplay_Load(object sender, EventArgs e)
        {
            MessageBox.Show("İlaç görüntülemeye hoşgeldiniz.");
            Initialize();
        }
        private void Initialize()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            conn.DataSource = "medic-server.database.windows.net";
            conn.UserID = "medic_admin";
            conn.Password = "sXbPj8pMzy";
            conn.InitialCatalog = "MedicAppDB";

            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from t_medicine", con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;

                    }
                    con.Close();

                }
                using (SqlCommand cmd2 = new SqlCommand("Select name from t_medicine", con))
                {
                    con.Open();
                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            comboBox1.Items.Add(reader2.GetValue(0));
                        }
                    }
                    con.Close();
                }

            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Fill_the_tables();
        }



        private void Fill_the_tables()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            conn.DataSource = "medic-server.database.windows.net";
            conn.UserID = "medic_admin";
            conn.Password = "sXbPj8pMzy";
            conn.InitialCatalog = "MedicAppDB";

            this.richTextBox1.Clear();
            using (SqlConnection conx = new SqlConnection(conn.ConnectionString))
            {
                using (SqlCommand cmd3 = new SqlCommand("select * from t_medicine where name = @1"))
                {
                    cmd3.Connection = conx;
                    cmd3.Parameters.AddWithValue("@1", this.comboBox1.SelectedItem);
                    conx.Open();
                    using (SqlDataReader rde = cmd3.ExecuteReader())
                    {

                        DataTable dt = new DataTable();
                        dt.Load(rde);
                        this.dataGridView1.DataSource = dt;
                    }
                    conx.Close();
                }
                using (SqlCommand cmd4 = new SqlCommand("select prospectus from t_prospectus where name = '" + this.comboBox1.SelectedItem + "'"))
                {
                    cmd4.Connection = conx;
                    conx.Open();
                    using (SqlDataReader rdx = cmd4.ExecuteReader())
                    {
                        while (rdx.Read())
                        {
                            this.richTextBox1.Text = rdx.GetValue(0).ToString();
                        }
                    }
                    conx.Close();
                }
                using (SqlCommand cmd5 = new SqlCommand("select picture_path from t_medicine_pic where name = '" + this.comboBox1.SelectedItem + "'"))
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
                                    this.pictureBox1.Image = Bitmap.FromStream(str);
                                }
                            }
                        }
                    }
                    conx.Close();
                }
            }
        }

        private void QrButton_Click(object sender, EventArgs e)
        {
            Camera cam = new Camera();
            cam.ShowDialog();
            while (cam.a)
            {
               
                SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
                conn.DataSource = "medic-server.database.windows.net";
                conn.UserID = "medic_admin";
                conn.Password = "sXbPj8pMzy";
                conn.InitialCatalog = "MedicAppDB";

                this.richTextBox1.Clear();
                using (SqlConnection conx = new SqlConnection(conn.ConnectionString))
                {
                    using (SqlCommand cmd3 = new SqlCommand("select * from t_medicine where barcode = '" + cam.barcode + "'"))
                    {
                        cmd3.Connection = conx;
                        conx.Open();
                        using (SqlDataReader rde = cmd3.ExecuteReader())
                        {

                            DataTable dt = new DataTable();
                            dt.Load(rde);
                            this.dataGridView1.DataSource = dt;
                        }
                        conx.Close();
                    }
                    using (SqlCommand cmd4 = new SqlCommand("select prospectus from t_prospectus where barcode = '" + cam.barcode + "'"))
                    {
                        cmd4.Connection = conx;
                        conx.Open();
                        using (SqlDataReader rdx = cmd4.ExecuteReader())
                        {
                            while (rdx.Read())
                            {
                                this.richTextBox1.Text = rdx.GetValue(0).ToString();
                            }
                        }
                        conx.Close();
                    }
                    using (SqlCommand cmd5 = new SqlCommand("select picture_path from t_medicine_pic where barcode = '" +cam.barcode + "'"))
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
                                        this.pictureBox1.Image = Bitmap.FromStream(str);
                                    }
                                }
                            }
                        }
                        conx.Close();
                    }
                }
                cam.a = false;
            }
        }
    }
}
    

