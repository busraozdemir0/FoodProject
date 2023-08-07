using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        [Required(ErrorMessage = "Lütfen kart üzerindeki adınızı ve soyadınızı giriniz.")]
        public string NameSurname { get; set; }
        [Required(ErrorMessage = "E-Mail alanı boş geçilemez.")]
        public string Email { get; set; }
        [StringLength(11, ErrorMessage = "Telefon numarası 11 karakter olmalıdır.")]
        [Required(ErrorMessage = "Telefon numarası alanı boş bırakılamaz.")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Şehir alanı boş bırakılamaz.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Adres alanı boş bırakılamaz.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Kart numarası boş bırakılamaz.")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Lütfen kart üzerindeki Ay/Yıl bilgisini giriniz.")]
        public string CardMonth_Year { get; set; }
        [Required(ErrorMessage = "Lütfen kartın arkasında yer alan CVC numarasını giriniz.")]
        public string CardCVC { get; set; } 
        public double ShoppingTotal { get; set; }
        public int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int FoodID { get; set; }
        public virtual Food Food { get; set; }
        public List<Shopping> Shoppings { get; set; }

    }
}
