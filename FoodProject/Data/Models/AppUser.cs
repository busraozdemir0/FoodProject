using Microsoft.AspNetCore.Identity;

namespace FoodProject.Data.Models
{
	public class AppUser:IdentityUser<int>
	{
		public string NameSurname { get; set; }
	}
}
