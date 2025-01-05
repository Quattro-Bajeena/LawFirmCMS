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


        public string GetMimeType()
        {
            var mimeType = "application/octet-stream";
            if (BinaryData[0] == 0xFF && BinaryData[1] == 0xD8) mimeType = "image/jpeg";
            if (BinaryData[0] == 0x89 && BinaryData[1] == 0x50) mimeType = "image/png";
            if (BinaryData[0] == 0x47 && BinaryData[1] == 0x49) mimeType = "image/gif";
            if (BinaryData[0] == 0x42 && BinaryData[1] == 0x4D) mimeType = "image/bmp";
            return mimeType;
        }

    }
}
