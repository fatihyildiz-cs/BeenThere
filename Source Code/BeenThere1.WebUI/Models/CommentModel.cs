using System;
namespace BeenThere1.WebUI.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Author { get; set; }

        public int ExperienceId { get; set; }

        public DateTime DateOfCreation { get; set; }

    }
}
