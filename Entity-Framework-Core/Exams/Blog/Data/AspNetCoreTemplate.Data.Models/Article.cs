namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AspNetCoreTemplate.Data.Common.Validation;

    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ArticleValidationConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ArticleValidationConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; } = null!;

        public virtual ApplicationUser Author { get; set; }
    }
}
