using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace SqlLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection command = new MySqlConnection("Server=localhost\\MSSQLSERVER01;Database=master;Trusted_Connection=True;");
            command.Open();
        }
    }
}
