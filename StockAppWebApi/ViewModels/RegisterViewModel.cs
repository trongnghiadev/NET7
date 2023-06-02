using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.ViewModels
{
    public class RegisterViewModel
    {
        public string? Username { get; set; } = "";

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(255, ErrorMessage = "Email không được vượt quá 255 ký tự")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(200, ErrorMessage = "Mật khẩu không được vượt quá 200 ký tự")]
        public string Password { get; set; } = "";


        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; } = "";

        public string? FullName { get; set; } 
        public DateTime? DateOfBirth { get; set; }

        [StringLength(200, ErrorMessage = "Quốc gia không được vượt quá 200 ký tự")]
        public string? Country { get; set; } 
    }
}
