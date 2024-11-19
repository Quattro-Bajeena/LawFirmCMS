using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
	public class Specialization
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int Cost { get; set; }

		public ICollection<EmployeeSpecialization> EmployeeSpecializations { get; } = new List<EmployeeSpecialization>();

	}
}
