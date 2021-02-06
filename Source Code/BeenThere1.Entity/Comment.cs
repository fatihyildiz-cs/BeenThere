using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeenThere1.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Author { get; set; }

        public string AuthorProfilePic { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateOfUpdate { get; set; } = DateTime.Now;

        public int ExperienceId { get; set; }

    }
}
