using LawFirmCMS.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class PageElement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PageElementType Type { get; set; }
        public int Order {  get; set; }
        public string? TextData { get; set; }
        public byte[]? BinaryData { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
        public CustomPage Page { get; set; }
        public int PageId { get; set; }

        
    }
}
