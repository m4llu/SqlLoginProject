using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace SqlLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(303, 372);
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection command = new MySqlConnection("Server=localhost\\MSSQLSERVER01;Database=master;Trusted_Connection=True;");
            command.Open();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Size = new Size(718, 372);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Size = new Size(303, 372);
        }
    }
}
