// Models/Post.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
    }
}