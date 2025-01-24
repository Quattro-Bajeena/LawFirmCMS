using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class Configuration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Key { get; set; }
        [Required]
        public required string Value { get; set; }

        public static string POST_VISIBLE = "post_visible";
        public static string FOOTER = "footer";
    }
}
