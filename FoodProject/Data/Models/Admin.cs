using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
	public class Admin
	{
		[Key]
		public int AdminID { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		[StringLength(20)]
		public string UserName { get; set; }
		public string EMail { get; set; }

		[StringLength(15)]
		public string Password { get; set; }
		
	}
}
