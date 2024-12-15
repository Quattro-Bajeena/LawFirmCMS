using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class CustomPage : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^[^\s]*$")]
        public string Path { get; set; }

        [Required]
        public bool IsGroup { get; set; } = false;

        [Required]
        public bool IsDeleted { get; set; } = false;
        public CustomPage? Parent { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<PageElement> Elements { get; } = new List<PageElement>();
        public virtual ICollection<CustomPage> Children { get; set; } = new List<CustomPage>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsGroup && ParentId != null)
            {
                yield return new ValidationResult($"Page can't be a group of pages and have a parent at the same time");
            }
        }
    }
}
