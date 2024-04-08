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

        public Dashboard()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
            flowLayoutPanel1.VerticalScroll.Visible = true;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1299, 700);
        }

        Color lockedColor;

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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

            Panel panel = new Panel();
            panel.Size = new Size(panelWidth, panelHeight);
            taskPreview.Size = new Size(panelWidth, panelHeight);
            panel.BackColor = Color.Black;

            Button button = new Button();
            button.Text = "Click Me";
            button.Location = new Point(10, panel.Height - button.Height - 10); // Align button to bottom-left corner

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

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(contentLabel);
            panel.Controls.Add(button);
            panel.BackColor = lockedColor;
            panel.Width += 15;

            // Clear previous controls from the panel
            taskPreview.Controls.Clear();

            // Add the updated panel to taskPreview
            taskPreview.Controls.Add(panel);

            if (addToFlowLayoutPanel)
            {
                // Add the updated panel to flowLayoutPanel1
                flowLayoutPanel1.Controls.Add(panel);
            }
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
            List<string> panelNames = new List<string> { "panelUsers", "panelRequirements", "panelInfo" };

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
    }
}


