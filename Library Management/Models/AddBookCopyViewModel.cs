using System;

namespace Library_Management.Models
{
    public class AddBookCopyViewModel
    {
        public Guid BookId { get; set; } // Links the copy to a book
        public string Condition { get; set; } // New, Good, Fair, Poor, etc.
        public bool IsAvailable { get; set; } = true; // Default availability
        public string? CoverImageUrl { get; set; }
        public string? Source { get; set; }
    }
}
