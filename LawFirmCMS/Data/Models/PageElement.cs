using LawFirmCMS.Data.Enums;
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
        public string? TextData { get; set; }
        public byte[]? BinaryData { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
		[ForeignKey("PageId")]
		public virtual CustomPage? Page { get; set; }

		[Required]
		public int PageId { get; set; }


	}
}
