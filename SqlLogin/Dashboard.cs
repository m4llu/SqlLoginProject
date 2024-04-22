using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Drawing.Text;
using RequirementManagementSystem;
using Microsoft.Data.SqlClient;

namespace SqlLogin
{
    public partial class Dashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner  
            int nTopRect,      // y-coordinate of upper-left corner  
            int nRightRect,    // x-coordinate of lower-right corner  
            int nBottomRect,   // y-coordinate of lower-right corner  
            int nWidthEllipse, // width of ellipse  
            int nHeightEllipse // height of ellipse  
        );

        private void AddExampleRequirements()
        {
            // Create some example requirements
            Requirement requirement1 = new Requirement("Requirement 1", 80, 50, "High", "John Doe", "v1.0", "Feature", 1);
            Requirement requirement2 = new Requirement("Requirement 2", 60, 30, "Medium", "Jane Smith", "v2.0", "Bug", 2);
            Requirement requirement3 = new Requirement("Requirement 3", 90, 70, "High", "Alice Johnson", "v1.1", "Enhancement", 3);

            // Add requirements to the flow layout panel
            flowLayoutPanel2.Controls.Add(requirement1);
            flowLayoutPanel2.Controls.Add(requirement2);
            flowLayoutPanel2.Controls.Add(requirement3);
        }

        public Dashboard()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
            flowLayoutPanel1.VerticalScroll.Visible = true;
            AddExampleRequirements();
        }







        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1299, 700);
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentsFolder, projectName + ".kiverio");

            filePathTextBox.Text = filePath;
        }

        Color lockedColor;

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        public class Task
        {
            public int TaskWidth { get; set; }
            public int TaskHeight { get; set; }
            public string TaskTitle { get; set; }
            public string Color { get; set; }
            public DateTime TaskDate { get; set; }
        }
        private void UpdateTaskPreview(bool addToFlowLayoutPanel)
        {
            string width = taskSizeInput.Text;
            string height = taskHeightInput.Text;

            int panelWidth, panelHeight;
            if (!int.TryParse(width, out panelWidth) || !int.TryParse(height, out panelHeight))
            {
                // Handle invalid input
                MessageBox.Show("Please enter valid width and height values.");
                return;
            }

            Panel previewPanel = new Panel();
            previewPanel.Size = new Size(panelWidth, panelHeight);
            taskPreview.Size = new Size(panelWidth, panelHeight);
            previewPanel.BackColor = Color.Black;

            Button button = new Button();
            button.Text = "Click Me";
            button.Location = new Point(10, previewPanel.Height - button.Height - 10); // Align button to bottom-left corner

            Label titleLabel = new Label();
            titleLabel.ForeColor = Color.White;
            titleLabel.Text = taskTitleBox.Text;
            titleLabel.Font = new Font(titleLabel.Font, FontStyle.Bold); // Set the font to bold
            titleLabel.AutoSize = false; // Set to false to manually adjust label size
            titleLabel.Size = new Size(panelWidth - 20, 30); // Adjust the height and width as needed
            titleLabel.Location = new Point(10, 10);

            Label contentLabel = new Label();
            contentLabel.ForeColor = Color.White;
            contentLabel.Text = taskContentBox.Text;
            contentLabel.AutoSize = false; // Set to false to manually adjust label size
            contentLabel.Size = new Size(panelWidth - 20, panelHeight - titleLabel.Bottom - 50); // Adjust the height and width as needed
            contentLabel.Location = new Point(10, titleLabel.Bottom + 5);

            previewPanel.Controls.Add(titleLabel);
            previewPanel.Controls.Add(contentLabel);
            previewPanel.Controls.Add(button);
            previewPanel.BackColor = lockedColor;
            previewPanel.Width += 15;

            // Clear previous controls from the panel
            taskPreview.Controls.Clear();

            // Add the updated panel to taskPreview
            taskPreview.Controls.Add(previewPanel);

            if (addToFlowLayoutPanel)
            {
                   int taskHeight = Convert.ToInt32(height);
                int taskWidth = Convert.ToInt32(width);
                string taskTitle = taskTitleBox.Text;
                string color = lockedColor.ToString();
                DateTime taskDate = dateTimePicker1.Value;

                // SQL query to insert task details into the database
                string query = "INSERT INTO tasks (task_height, task_width, task_title, color, task_date) " +
                               "VALUES (@TaskHeight, @TaskWidth, @TaskTitle, @Color, @TaskDate)";

                // Database connection string
                string connectionString = "Server=localhost;Database=db1;Trusted_Connection=True;TrustServerCertificate=True;";

                // Establish database connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create SQL command
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SQL command
                        cmd.Parameters.AddWithValue("@TaskHeight", taskHeight);
                        cmd.Parameters.AddWithValue("@TaskWidth", taskWidth);
                        cmd.Parameters.AddWithValue("@TaskTitle", taskTitle);
                        cmd.Parameters.AddWithValue("@Color", color);
                        cmd.Parameters.AddWithValue("@TaskDate", taskDate);

                        // Open database connection
                        connection.Open();

                        // Execute SQL command
                        int result = cmd.ExecuteNonQuery();

                        // Check if the task was successfully saved
                        if (result > 0)
                        {
                            MessageBox.Show("Task saved successfully");
                        }
                        else
                        {
                            MessageBox.Show("Failed to save task");
                        }
                    }
                }
                // Fetch tasks from the database
                List<Task> tasks = GetTasksFromDatabase();

                // Clear existing controls from flowLayoutPanel1
                flowLayoutPanel1.Controls.Clear();
                // Get task details from UI
             
                // Create and add panels for each task
                foreach (Task task in tasks)
                {
                    Panel panel = CreateTaskPanel(task);
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
        }

        private List<Task> GetTasksFromDatabase()
        {
            List<Task> tasks = new List<Task>();

            // SQL query to select tasks from the database
            string query = "SELECT * FROM tasks";

            // Database connection string
            string connectionString = "Server=localhost;Database=db1;Trusted_Connection=True;TrustServerCertificate=True;";

            // Establish database connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create SQL command
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Open database connection
                    connection.Open();

                    // Execute SQL command and read tasks from the database
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Task task = new Task
                            {
                                TaskHeight = Convert.ToInt32(reader["task_height"]),
                                TaskWidth = Convert.ToInt32(reader["task_width"]),
                                TaskTitle = reader["task_title"].ToString(),
                                Color = reader["color"].ToString(),
                                TaskDate = Convert.ToDateTime(reader["task_date"])
                            };

                            tasks.Add(task);
                        }
                    }
                }
            }

            return tasks;
        }

        private Panel CreateTaskPanel(Task task)
        {
            Panel panel = new Panel();
            panel.Size = new Size(task.TaskWidth, task.TaskHeight);
            panel.BackColor = Color.FromName(task.Color);

            Label titleLabel = new Label();
            titleLabel.ForeColor = Color.White;
            titleLabel.Text = task.TaskTitle;
            titleLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);
            titleLabel.AutoSize = false;
            titleLabel.Size = new Size(panel.Width - 20, 30);
            titleLabel.Location = new Point(10, 10);

            // Add other controls like content label, button, etc. as needed

            panel.Controls.Add(titleLabel);
            // Add other controls to the panel

            return panel;
        }


        private void button7_Click(object sender, EventArgs e)
        {
            // Update the task preview and add it to flowLayoutPanel1
            UpdateTaskPreview(true);

        }

        private void taskContentBox_TextChanged(object sender, EventArgs e)
        {
            // Update the task preview when content input changes
            UpdateTaskPreview(false);
        }


        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap pixelData = (Bitmap)pictureBox1.Image;
            Color clr = pixelData.GetPixel(e.X, e.Y);
            colorPreview.BackColor = clr;
            button7.BackColor = lockedColor;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lockedColor = colorPreview.BackColor;
            UpdateTaskPreview(false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private Point mouseOffset;
        private bool isMouseDown = false;
        private bool isPanelMinimized = true;
        private int originalPanelHeight;
        private bool isLocked = true;
        private string selectedView = "panelRequirements";




        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && !isLocked)
            {
                // Calculate the new location of the panel
                Point newLocation = this.PointToClient(MousePosition);
                newLocation.Offset(-mouseOffset.X, -mouseOffset.Y);

                // Set the new location of the panel
                panel3.Location = newLocation;
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture
                isMouseDown = false;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Capture the mouse and calculate the offset
                mouseOffset = new Point(e.X, e.Y);
                isMouseDown = true;
            }
        }

        private void taskTitleBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTaskPreview(false);
        }

        private void taskSizeInput_TextChanged(object sender, EventArgs e)
        {
            UpdateTaskPreview(false);
        }

        private void taskHeightInput_TextChanged(object sender, EventArgs e)
        {
            UpdateTaskPreview(false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isPanelMinimized)
            {
                // Restore panel to its original size
                panel3.Height = originalPanelHeight;
                isPanelMinimized = false;
                panel3.AutoSize = true; // Set AutoSize to true when panel is maximized
                isLocked = false;
                button8.Text = "🢁";
            }
            else
            {
                isPanelMinimized = true;
                panel3.AutoSize = false; // Set AutoSize to false when panel is minimized
                panel3.Height = 32;
                isLocked = true;
                panel3.Location = new Point(6, 97);
                button8.Text = "🢃";
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ShowSelectedPanel(string selectedView)
        {
            // Create a list of panel names that should be affected
            List<string> panelNames = new List<string> { "panelUsers", "panelRequirements", "panelInfo", "panelFile" };

            // Iterate through all controls in the form
            foreach (Control control in this.Controls)
            {
                // Check if the control is a Panel and its name is in the list
                if (control is Panel && panelNames.Contains(control.Name))
                {
                    // Cast the control to a Panel
                    Panel panel = (Panel)control;

                    // Check if the panel's name matches the selectedView
                    if (panel.Name == selectedView)
                    {
                        // Show the selected panel
                        panel.Visible = true;
                        panel.Location = new Point(206, 47);
                        panel.Size = new Size(1098, 657);
                    }
                    else
                    {
                        // Hide the unselected panels
                        panel.Visible = false;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedView = "panelInfo";
            ShowSelectedPanel(selectedView);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedView = "panelRequirements";
            ShowSelectedPanel(selectedView);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedView = "panelUsers";
            ShowSelectedPanel(selectedView);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedView = "panelFile";
            ShowSelectedPanel(selectedView);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private bool mouseDown;
        private Point lastLocation;

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }



        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private string projectName = "Project1";
        private string projectVersion = "0.0.1";
        private string projectDesc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        private void refreshProjectInfo()
        {
            projectName = projectNameBox.Text;
            projectVersion = projectVersionBox.Text;
            projectDesc = projectDescBox.Text;

            projectNameLabel.Text = projectNameBox.Text;
            projectVersionLabel.Text = projectVersionBox.Text;
            projectDescLabel.Text = projectDescBox.Text;
        }

        private void projectNameBox_TextChanged(object sender, EventArgs e)
        {
            refreshProjectInfo();
        }

        private void projectVersionBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            refreshProjectInfo();
        }

        private void projectDescBox_TextChanged(object sender, EventArgs e)
        {
            refreshProjectInfo();
        }

        public class ProjectInfo
        {
            public string ProjectName { get; set; }
            public string ProjectVersion { get; set; }
            public string ProjectDesc { get; set; }
        }

        private void SaveProjectInfo(string projectName)
        {
            ProjectInfo projectInfo = new ProjectInfo
            {
                ProjectName = this.projectName,
                ProjectVersion = this.projectVersion,
                ProjectDesc = this.projectDesc
            };

            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentsFolder, projectName + ".kiverio");

            filePathTextBox.Text = filePath;

            try
            {
                string json = JsonSerializer.Serialize(projectInfo);
                File.WriteAllText(filePath, json);
                MessageBox.Show("Project info saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving project info: " + ex.Message);
            }
        }

        private ProjectInfo LoadProjectInfo(string projectName)
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentsFolder, projectName);
            filePathTextBox.Text = filePath;
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<ProjectInfo>(json);
                }
                else
                {
                    MessageBox.Show("Project info file not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading project info: " + ex.Message);
                return null;
            }
        }

        // Example usage:
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Assuming filePathTextBox contains the file path entered by the user
            string filePath = filePathTextBox.Text;
            SaveProjectInfo(projectName);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Assuming filePathTextBox contains the file path entered by the user
            string filePath = filePathTextBox.Text;
            ProjectInfo loadedProjectInfo = LoadProjectInfo(filePath);
            if (loadedProjectInfo != null)
            {
                projectName = loadedProjectInfo.ProjectName;
                projectVersion = loadedProjectInfo.ProjectVersion;
                projectDesc = loadedProjectInfo.ProjectDesc;

                // Update UI with loaded project info
                projectNameBox.Text = projectName;
                projectVersionBox.Text = projectVersion;
                projectDescBox.Text = projectDesc;
                projectNameLabel.Text = projectNameBox.Text;
                projectVersionLabel.Text = projectVersionBox.Text;
                projectDescLabel.Text = projectDescBox.Text;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


