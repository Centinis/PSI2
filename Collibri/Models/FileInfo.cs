namespace Collibri.Models
{
	public class FileInfo
	{
		public Guid Id { get; set; }
		
		public Guid PostId { get; set; }

		public string Path { get; set; } = "";
		
		public string Name { get; set; } = "";

		public string ContentType { get; set; } = "";

		public long Lenght { get; set; }

		public FileInfo()
		{ 
		
		}
	}
}