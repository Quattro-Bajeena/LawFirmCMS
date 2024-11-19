using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
	public class JobOffer
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Position { get; set; }
		[Required]
		public int Salary { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public string Requirements { get; set; }
	}
}
