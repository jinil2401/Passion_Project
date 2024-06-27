using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace PassionProjectSummer2024.Models
{
    /// Represents a comment made on an article.
    public class Comment
    {
   
        /// The unique identifier for the comment.
   
        public int CommentId { get; set; }

   
        /// The content of the comment.
   
        [Required]
        public string Content { get; set; }

   
        /// The user ID of the commenter.
   
        [Required]
        public string UserId { get; set; }

   
        /// The ID of the article that the comment belongs to.
   
        [Required]
        public int ArticleId { get; set; }

   
        /// The date and time when the comment was posted.
   
        public DateTime CreatedAt { get; set; }

   
        /// Navigation property to the associated article.
   
        public virtual Article Article { get; set; }
    }
}
