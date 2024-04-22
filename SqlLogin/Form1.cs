using Microsoft.Data.SqlClient;
using System.Data;
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

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = registerUsernameBox.Text.Trim();
            string password = registerPasswordBox.Text.Trim();
            string email = emailBox.Text.Trim();

            string querycheck = "SELECT COUNT(1) FROM users WHERE username=@Username";

            // initialize database connection
            string connectionStringcheck = "Server=localhost;Database=db1;Trusted_Connection=True;TrustServerCertificate=True;";
            using (SqlConnection connectioncheck = new SqlConnection(connectionStringcheck))
            {
                using (SqlCommand cmdcheck = new SqlCommand(querycheck, connectioncheck))
                {
                    cmdcheck.Parameters.AddWithValue("@Username", username);
                    cmdcheck.Parameters.AddWithValue("@Password", password);

                    connectioncheck.Open();

                    int count = Convert.ToInt32(cmdcheck.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Username already in use.");
                    }
                    else
                    {
                        string query = "INSERT INTO users (username, password, email) VALUES (@Username, @Password, @Email)";

                        string connectionString = "Server=localhost;Database=db1;Trusted_Connection=True;TrustServerCertificate=True;";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.Parameters.AddWithValue("@password", password);
                                cmd.Parameters.AddWithValue("@email", email);

                                connection.Open();

                                int result = cmd.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    MessageBox.Show("Success");
                                }
                                else
                                {
                                    MessageBox.Show("Failure");
                                }
                            }

                        }
                    }
                }
            }
        }



        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = loginUsernameBox.Text.Trim();
            string password = loginPasswordBox.Text.Trim();

            string query = "SELECT COUNT(1) FROM users WHERE username=@Username AND password=@Password";

            // initialize database connection
            string connectionString = "Server=localhost;Database=db1;Trusted_Connection=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Successful login");
                    }
                    else
                    {
                        MessageBox.Show("Login failure");
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Size = new Size(718, 372);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            createButton.Font = new Font(createButton.Font, FontStyle.Underline);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            createButton.Font = new Font(createButton.Font, FontStyle.Regular);
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Size = new Size(303, 372);
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.IndianRed;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard f2 = new Dashboard(); //this is the change, code for redirect  
            f2.ShowDialog();
        }
    }
}
