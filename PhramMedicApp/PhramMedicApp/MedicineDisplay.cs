using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            conn.DataSource="medic-server.database.windows.net";
            conn.UserID="medic_admin";
            conn.Password="sXbPj8pMzy";
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
                }

            }
   
        }

    }
}
