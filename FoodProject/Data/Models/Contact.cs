using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
	public class Contact
	{
		[Key]
		public int ContactID { get; set; }
		public string ContactName { get; set; }
		public string ContactSurname { get; set; }
		public string ContactEmail { get; set; }
		public string ContactSubject { get; set; }
		public string ContactMessage { get; set; }
	}
}
