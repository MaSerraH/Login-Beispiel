using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Login_Beispiel
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
            String connectionString = ConfigurationManager.ConnectionStrings["Login_Beispiel.Properties.Settings.C__DBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }

        private void bt2_Click(object sender, EventArgs e)
        {

            DialogResult Exit;
            try
            {
                Exit = MessageBox.Show("möchten Sie wirklich schließen?", "Login Beispiel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Exit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Beispiel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            } 
        }

        public user usr = null;
        private void bt1_Click(object sender, EventArgs e)
        { 
            user usr = new user();

            String email = this.tb1.Text;
            String password = this.tb2.Text;

            if (email.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("email und Passwort bitte eingeben!", "die Felde: email und Passwort sind leer!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                sqlConnection.Open();
                String query = "select * from loginBeispiel where Email = @email and Password = @password";
                 SqlCommand sqlcmd = new SqlCommand(query, sqlConnection);
                sqlcmd.Parameters.AddWithValue("@email", email);
                sqlcmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = sqlcmd.ExecuteReader();  
                if (reader.Read())
                {

                    usr.Equals(reader[1].ToString());
                    usr.Equals(reader[2].ToString());
                    usr.Fullname = reader.GetString(3);

                    MessageBox.Show("Login erfolgt! " + usr.Fullname, "erfolgreiche eingeloggt!", MessageBoxButtons.OK);
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("der User mit der email-adresse " + email + ", existiert nicht!", "Login fehlgeschlagen!", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message, "Login Beispiel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            finally
            {
                if (usr != null)
                {
                    Form2 form2 = new Form2(usr);
                    form2.ShowDialog();
                }

                sqlConnection.Close();
            }
        }
    }
}
