using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Beispiel
{
   
    public partial class Form2 : Form
    {
        
        SqlConnection sqlConnection;
        public Form2()
        {
            InitializeComponent();
            String connectionString = ConfigurationManager.ConnectionStrings["Login_Beispiel.Properties.Settings.C__DBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }
        user usr = new user();

        private void button1_Click(object sender, EventArgs e)
        {
            String fullName;
            sqlConnection.Open();
            String query = "select * from loginBeispiel";
            SqlCommand sqlcmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlcmd.ExecuteReader();
            if (reader.Read())
            {
               // fullName = (string)reader["FullName"];
               fullName = reader.GetString(3);
                label1.Text = "Willkommen " + fullName + "!";
            }
            reader.Close();
            sqlConnection.Close();
        }
    }
}
