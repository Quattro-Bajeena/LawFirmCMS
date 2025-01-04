using LawFirmCMS.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawFirmCMS.Data.Models
{
    public class PageElement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PageElementType Type { get; set; }
        public int Order { get; set; }
        [Display(Name = "Text data")]
        public string? TextData { get; set; }
        [Display(Name = "Binary data")]
        public byte[]? BinaryData { get; set; }
        [Required]
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("PageId")]
        public virtual CustomPage? Page { get; set; }

        [Required]
        [Display(Name = "Page")]
        [ReadOnly(true)]
        public int PageId { get; set; }


    }
}
