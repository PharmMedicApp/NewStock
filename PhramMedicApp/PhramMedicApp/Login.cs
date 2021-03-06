﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PhramMedicApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "medic-server.database.windows.net"; 
                builder.UserID = "medic_admin";
                builder.Password = "sXbPj8pMzy";
                builder.InitialCatalog = "MedicAppDB";

                using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string query = "select * from t_user";

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (tb_username.Text == reader["username"].ToString() && tb_password.Text == reader["password"].ToString())
                                {
                                    StringBuilder msg = new StringBuilder();
                                    msg.Append("Hoşgeldiniz: ");
                                    msg.Append(tb_username.Text);
                                    msg.Append("\nStatü: ");
                                    msg.Append(reader["status"]);
                                    MessageBox.Show(msg.ToString(), "Bilgi", MessageBoxButtons.OK);
                                    switch (reader["status"])
                                    {
                                        case "ECZ":
                                            this.Hide();
                                            MedicineDisplayECZ ecz = new MedicineDisplayECZ();
                                            ecz.status = reader["status"].ToString();
                                            ecz.Show();
                                            break;
                                        case "KLF":
                                            this.Hide();
                                            MedicineDisplayECZ eck = new MedicineDisplayECZ();
                                            eck.status = reader["status"].ToString();
                                            eck.Show();
                                            break;
                                        case "STK":
                                            this.Hide();
                                            StockDisp stock = new StockDisp(reader["status"].ToString());
                                            stock.Show();
                                            break; 
                                    }
                                }
                                else if(tb_username.Text != reader["username"].ToString() && tb_password.Text == reader["password"].ToString())
                                {
                                    MessageBox.Show("Kullanıcı adı yanlış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    break;
                                }
                                else if(tb_username.Text == reader["username"].ToString() && tb_password.Text != reader["password"].ToString())
                                {
                                    MessageBox.Show("Şifre yanlış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            MedicineDisplay mdc = new MedicineDisplay();
            mdc.Show();
        }
    }
}
