using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
	public class Admin
	{
		[Key]
		public int AdminID { get; set; }
		[StringLength(20)]
		public string UserName { get; set; }
		[StringLength(15)]
		public string Password { get; set; }
		[StringLength(10)]
		public string AdminRole { get; set; }
	}
}
