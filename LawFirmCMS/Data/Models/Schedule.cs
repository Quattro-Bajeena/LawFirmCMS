using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
	public class Schedule
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Weekday { get; set; }
		[Required]
		public int StartTime { get; set; }
		[Required]
		public int EndTime { get; set; }
		[Required]
		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }
	}
}
