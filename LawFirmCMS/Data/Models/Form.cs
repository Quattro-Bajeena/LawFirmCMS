using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
	public class Form
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Content { get; set; }
		[Required]
		public bool IsHandled { get; set; } = false;
		
	}
}
