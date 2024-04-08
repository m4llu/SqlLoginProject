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
            panel.BackColor = Color.Black;

            Button button = new Button();
            button.Text = "Click Me";
            button.Location = new Point(10, panel.Height - button.Height - 10); // Align button to bottom-left corner

            Label titleLabel = new Label();
            titleLabel.ForeColor = Color.White;
            titleLabel.Text = taskTitleBox.Text;
            titleLabel.AutoSize = true; // Set to true to automatically adjust label size based on content
            titleLabel.Location = new Point(10, 10);

            Label contentLabel = new Label();
            contentLabel.ForeColor = Color.White;
            contentLabel.Text = taskContentBox.Text;
            contentLabel.AutoSize = true; // Set to true to automatically adjust label size based on content
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

        private void taskSizeInput_TextChanged(object sender, EventArgs e)
        {
            // Update the task preview when width input changes
            UpdateTaskPreview(false);
        }

        private void taskHeightInput_TextChanged(object sender, EventArgs e)
        {
            // Update the task preview when height input changes
            UpdateTaskPreview(false);
        }

        private void taskTitleBox_TextChanged(object sender, EventArgs e)
        {
            // Update the task preview when title input changes
            UpdateTaskPreview(false);
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
            UpdateTaskPreview(false);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lockedColor = colorPreview.BackColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private Point mouseOffset;
        private bool isMouseDown = false;
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
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
    }
}

