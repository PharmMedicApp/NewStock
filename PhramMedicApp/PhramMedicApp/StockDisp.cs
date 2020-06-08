using Microsoft.Win32;
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

        private void qrDisp_Click(object sender, EventArgs e)
        {
            Camera camx = new Camera();
            camx.ShowDialog();
           
            while (camx.a)
            {
                using(SqlConnection connection =new SqlConnection(connStr.ConnectionString))
                {
                    connection.Open();
                    
                    using (SqlCommand cmdx = new SqlCommand("select * from t_stock where barcode = '" + camx.barcode + "'", connection))
                    {
                        
                        
                        using (SqlDataReader redr = cmdx.ExecuteReader())
                        {
                            DataTable dtx = new DataTable();
                            dtx.Load(redr);
                            this.stockList.DataSource = dtx;

                        }
                        connection.Close();
                        camx.a = false;
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
                            this.stockList.DataSource = dt;
                        }
                    }
                    connection.Close();
                }
            }
            catch(System.NullReferenceException ex) 
            {
                MessageBox.Show("İlaç Seçmediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buyMed_Click(object sender, EventArgs e)
        {
            string k = this.medCB.SelectedItem.ToString();
            int val = Convert.ToInt32(this.numericUpDown1.Value);
            
            int variabl =0;
            var updateQuery = String.Format("update t_stock set stock = stock + {0} where name = {1}", val, k);
            var displayupdatedStock = String.Format("select * from t_stock where name = {0}", medCB.SelectedItem.ToString());

            using(SqlConnection connection = new SqlConnection(connStr.ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmx = new SqlCommand("select stock from t_stock where name = '" + medCB.SelectedItem.ToString() + "'", connection))
                {
                    using (SqlDataReader rcx = cmx.ExecuteReader())
                    {
                        while (rcx.Read())
                        {
                            variabl = Convert.ToInt32(rcx.GetValue(0));
                            variabl += val;
                        }
                }
                    

                    using (SqlCommand command = connection.CreateCommand())
                {
                        command.Parameters.AddWithValue("@stock", val);
                        using (SqlCommand cmd = new SqlCommand("select * from t_stock where name = '" + medCB.SelectedItem.ToString() + "'", connection))
                            
                        {
                            
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                DataTable dt = new DataTable();
                                dt.Load(reader);
                                this.stockList.DataSource = dt;
                                
                            }
                        }
                        connection.Close();



                    }

                }
            }
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
