namespace CountNextTaskDate.Models
{
	public class NextTaskResponse
	{
		public int id {  get; set; }
		public int count { get; set; }
		public DateTime currentDate { get; set; }
		public DateTime firstOccurrence { get; set; }
		public DateTime lastOccurrence { get; set; }
		public DateTime nextOccurrence { get; set; }
	}
}
