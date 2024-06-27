using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProjectSummer2024.Models
{
    /// Represents an article published in a specific category by a user.
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

   
        /// The title of the article.
   
        public string Title { get; set; }

   
        /// The content of the article.
   
        public string Content { get; set; }

   
        /// The date when the article was published.
   
        public DateTime PublishedDate { get; set; }

        // Foreign key for User (Author)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        // Foreign key for Category
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }

    /// Data transfer object (DTO) for Article.
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
