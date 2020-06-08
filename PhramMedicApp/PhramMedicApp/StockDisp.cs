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
    public partial class StockDisp : Form
    {
        public string status { get; set; }
        SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder()
        {
            DataSource = "medic-server.database.windows.net",
            UserID = "medic_admin",
            Password = "sXbPj8pMzy",
            InitialCatalog = "MedicAppDB"
        };

        public StockDisp(string status)
        {
            this.status = status;
            InitializeComponent(status);
        }

        private void StockDisp_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connStr.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from t_stock", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        stockList.DataSource = dataTable;
                        reader.Close();
                    }
                }

                using(SqlCommand command1 = new SqlCommand("select * from t_medicine",connection))
                {
                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        while (reader.Read())
                        {
                            medCB.Items.Add(reader["name"].ToString());
                        }
                        reader.Close();
                    }
                }
            }
        }

        private void dispMed_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from t_stock where name = '" + medCB.SelectedItem.ToString() + "'", connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            stockList.DataSource = dt;
                        }
                    }
                }
            }
            catch(System.NullReferenceException ex) 
            {
                MessageBox.Show("İlaç Seçmediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buyMed_Click(object sender, EventArgs e)
        {

        }

        private void sellMed_Click(object sender, EventArgs e)
        {
            
        }

        private void StockDisp_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
