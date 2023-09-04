using System.ComponentModel.DataAnnotations;

namespace CountNextTaskDate.Models.DTOs
{
	public class NextTaskRequest
	{
		[Required]
		public DateOnly startDate { get; set; }
		[Required]
		public int interval { get; set; }
		[Required]
		public string day { get; set; } = string.Empty;
	}
}
