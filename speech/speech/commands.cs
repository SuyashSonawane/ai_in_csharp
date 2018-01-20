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
using System.Data.SqlClient;

namespace speech
{
    public partial class commands : Form
    {
        public commands()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cont = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\LENOVO\\Desktop\\PRograMerZ\\speech\\speech\\commands.mdf;Integrated Security=True");
                cont.Open();
                SqlCommand com = new SqlCommand("INSERT INTO Jarviscommands(commands, response) VALUES (@commands, @response)",cont);
                com.Parameters.Add("@commands" ,textBox2.Text);
                com.Parameters.Add("@response", textBox1.Text);
                com.ExecuteNonQuery();
                cont.Close();
                MessageBox.Show("Changes have been successfully saved");
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Commands not saved");
            }
        }
    }
}
