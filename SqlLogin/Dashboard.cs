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

        private void button7_Click(object sender, EventArgs e)
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
            panel.Margin = new Padding(25, 25, 25, 25);

            Button button = new Button();
            button.Text = "Click Me";
            button.Location = new Point(10, panel.Height - button.Height - 10); // Align button to bottom-left corner

            Label titleLabel = new Label();
            titleLabel.ForeColor = Color.White; // Changed text color to black for better visibility
            titleLabel.Text = taskTitleBox.Text;
            titleLabel.AutoSize = true; // Automatically adjust label size based on content
            titleLabel.Location = new Point(10, 10); // Align label to top-left corner

            Label contentLabel = new Label();
            contentLabel.ForeColor = Color.White; // Changed text color to black for better visibility
            contentLabel.Text = taskContentBox.Text;
            contentLabel.AutoSize = true; // Automatically adjust label size based on content
            contentLabel.Location = new Point(10, titleLabel.Bottom + 5); // Align label below title label

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(contentLabel);
            panel.Controls.Add(button);
            panel.BackColor = lockedColor;
            flowLayoutPanel1.Controls.Add(panel);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void taskSizeInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void taskHeightInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void taskContentBox_TextChanged(object sender, EventArgs e)
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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
