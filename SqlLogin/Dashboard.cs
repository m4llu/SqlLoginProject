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
            panel5.BringToFront();
            flowLayoutPanel1.VerticalScroll.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            string x = taskSizeInput.Text;
            string y = taskHeightInput.Text;
            Panel panel = new Panel();
            panel.Size = new Size(Convert.ToInt32(x), Convert.ToInt32(y));
            panel.BackColor = Color.White;
            panel.Margin = new Padding(25, 25, 25, 25);

            Button button = new Button();
            button.Text = "Click Me";
            button.Location = new Point(10, 10);

            panel.Controls.Add(button);
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
    }
}
