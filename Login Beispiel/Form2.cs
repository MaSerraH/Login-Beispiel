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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Login_Beispiel
{
   
    public partial class Form2 : Form
    {
        
        SqlConnection sqlConnection;
        public Form2(user user)
        {
            InitializeComponent();
            String connectionString = ConfigurationManager.ConnectionStrings["Login_Beispiel.Properties.Settings.C__DBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            String fullName;
            sqlConnection.Open();


            String query = "select * from loginBeispiel";
            SqlCommand sqlcmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlcmd.ExecuteReader();
            if (reader.Read())
            {
                user usr = new user();
                usr.Fullname = reader[3].ToString();

                label1.Text = "Willkommen " + usr.Fullname +  "!";
            }
            reader.Close();
            sqlConnection.Close();
        }
    }
}
