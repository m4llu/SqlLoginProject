using System;

namespace SqlLogin
{
    // Rename this class to avoid naming conflicts
    public class TaskItem
    {
        public int TaskId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
}
