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

        public Form2(user usr)
        {
            InitializeComponent();

            label1.Text = "Willkommen " + usr.Fullname + "!";
           
        }
    }
}
