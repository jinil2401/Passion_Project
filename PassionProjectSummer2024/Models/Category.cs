using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PassionProjectSummer2024.Models
{
    /// Represents a category for organizing articles
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

   
        /// The name of the category.
  
        public string Name { get; set; }

   
        /// A brief description of the category.
  
        public string Description { get; set; }

        // Navigation property
        public virtual ICollection<Article> Articles { get; set; }

    }

    /// Data transfer object (DTO) for Category
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
