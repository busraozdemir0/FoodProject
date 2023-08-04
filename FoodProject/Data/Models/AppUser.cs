using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodProject.Data.Models
{
	public class AppUser:IdentityUser<int>
	{
		public string NameSurname { get; set; }
        [NotMapped]
        public List<Shopping> Shoppings { get; set; }
        public Payment Payment { get; set; }
    }
}
