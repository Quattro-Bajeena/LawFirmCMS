using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
	public class EmployeeSpecialization
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public Employee Employee { get; set; }
		[Required]
		public int EmployeeId { get; set; }
		[Required]
		public int SpecializationId { get; set; }
		public Specialization Specialization { get; set; }
	}
}
