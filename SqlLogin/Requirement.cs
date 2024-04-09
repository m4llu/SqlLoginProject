using System;
using System.Windows.Forms;

namespace RequirementManagementSystem
{
    public class Requirement : FlowLayoutPanel
    {
        // Properties
        public string Title { get; set; }
        public int CoveragePercentage { get; set; }
        public int ProgressPercentage { get; set; }
        public string Importance { get; set; }
        public string Author { get; set; }
        public string Release { get; set; }
        public string Type { get; set; }
        public int ID { get; set; }

        // Constructor
        public Requirement(string title, int coveragePercentage, int progressPercentage, string importance, string author, string release, string type, int id)
        {
            Title = title;
            CoveragePercentage = coveragePercentage;
            ProgressPercentage = progressPercentage;
            Importance = importance;
            Author = author;
            Release = release;
            Type = type;
            ID = id;

            InitializeUI();
        }

        // Method to initialize the UI of the requirement panel
        private void InitializeUI()
        {
            this.FlowDirection = FlowDirection.LeftToRight;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(10);
            this.Size = new Size(770, 70);
            this.BackColor = Color.Black; // Set background color to black to contrast the white text

            // Common font settings for all labels except title
            Font defaultFont = new Font("Tw Cen MT", 8.25F, FontStyle.Regular);

            // Title label with specific bold styling
            Label titleLabel = new Label();
            titleLabel.Text = "Title: " + Title;
            titleLabel.Font = new Font("Tw Cen MT", 8.25F, FontStyle.Bold); // Tw Cen MT, bold
            titleLabel.ForeColor = Color.White; // Set text color to white
            titleLabel.AutoSize = true;
            this.Controls.Add(titleLabel);

            // Set properties for other controls similarly, using defaultFont and white ForeColor
            // Coverage percentage progress bar
            ProgressBar coverageProgressBar = new ProgressBar();
            coverageProgressBar.Minimum = 0;
            coverageProgressBar.Maximum = 100;
            coverageProgressBar.Value = CoveragePercentage;
            coverageProgressBar.Width = 200;
            this.Controls.Add(coverageProgressBar);

            // Progress percentage progress bar
            ProgressBar progressProgressBar = new ProgressBar();
            progressProgressBar.Minimum = 0;
            progressProgressBar.Maximum = 100;
            progressProgressBar.Value = ProgressPercentage;
            progressProgressBar.Width = 200;
            this.Controls.Add(progressProgressBar);

            // Example for setting other labels
            Label importanceLabel = new Label();
            importanceLabel.Text = "Importance: " + Importance;
            importanceLabel.AutoSize = true;
            importanceLabel.Font = defaultFont; // Use the common font
            importanceLabel.ForeColor = Color.White; // Set text color to white
            this.Controls.Add(importanceLabel);

            // Repeat for authorLabel, releaseLabel, typeLabel, idLabel
            // Remember to set Font and ForeColor for each label

            // Author label
            Label authorLabel = new Label();
            authorLabel.Text = "Author: " + Author;
            authorLabel.AutoSize = true;
            authorLabel.Font = defaultFont;
            authorLabel.ForeColor = Color.White;
            this.Controls.Add(authorLabel);

            // The rest of the labels would follow a similar pattern
        }
    }
}