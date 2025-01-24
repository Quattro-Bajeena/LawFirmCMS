using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Login { get; set; }
        [ValidateNever]
        public byte[] PasswordHash { get; set; }
        [Required]
        public bool Boss { get; set; }
        [Display(Name = "Area of expertise")]
        public string? Expertise { get; set; }
        public byte[]? Picture { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;


        public virtual ICollection<Post> Posts { get; } = new List<Post>();


        public string GetMimeType()
        {
            if (Picture != null && Picture.Length > 0)
            {
                var mimeType = "application/octet-stream";
                if (Picture[0] == 0xFF && Picture[1] == 0xD8)
                    mimeType = "image/jpeg";
                if (Picture[0] == 0x89 && Picture[1] == 0x50)
                    mimeType = "image/png";
                if (Picture[0] == 0x47 && Picture[1] == 0x49)
                    mimeType = "image/gif";
                if (Picture[0] == 0x42 && Picture[1] == 0x4D)
                    mimeType = "image/bmp";
                return mimeType;
            }
            else
                return null;

        }
    }
}
