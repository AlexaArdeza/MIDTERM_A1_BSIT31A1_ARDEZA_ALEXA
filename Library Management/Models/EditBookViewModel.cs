using System.ComponentModel.DataAnnotations;

namespace Library_Management.Models
{
    public class EditBookViewModel
    {
        [Required(ErrorMessage = "Book ID is required.")]
        public Guid BookId { get; set; }
        public Guid? BookCopyId { get; set; }

        [Required(ErrorMessage = "Book title is required.")]
        [Display(Name = "Book Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [Display(Name = "Genre")]
        public string Genre { get; set; } = string.Empty;

        [Display(Name = "Published Date")]
        public DateTime? PublishedDate { get; set; }

        [Display(Name = "Book Author")]
        public Guid Id { get; set; }
        public string? Author { get; set; }             // Author name
        public Guid? AuthorId { get; set; }             // Author reference


        [Display(Name = "Author Profile Image URL")]
        public string? AuthorProfileImageUrl { get; set; }

        [Display(Name = "Cover Image URL")]
        public string? CoverImageUrl { get; set; }
    }
}
