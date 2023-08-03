using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data
{
    public class UserSignUpViewModel
	{
        public string RoleID { get; set; } = "Uye".ToLower(); // default değer atadık
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen ad soyad giriniz")]
        public string NameSurname { get; set; }

		[Display(Name = "Şifre")]
		[Required(ErrorMessage = "Lütfen şifre giriniz")]
		public string Password { get; set; }

		[Display(Name = "Şifre Tekrar")]
		[Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Mail Adresi")]
		[Required(ErrorMessage = "Lütfen mail giriniz")]
		public string Mail { get; set; }

		[Display(Name = "Kullanıcı Adı")]
		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
		public string UserName { get; set; }
		


    }
}
