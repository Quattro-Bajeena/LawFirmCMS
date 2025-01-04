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
        [RegularExpression(@"^[^\s]*$", ErrorMessage = "Path can't have spaces")]
        public string Path { get; set; }

        [Required]
        [Display(Name = "Page group")]
        public bool IsGroup { get; set; } = false;

        [Required]
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;
        public virtual CustomPage? Parent { get; set; }
        [Display(Name = "Parent page")]
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
