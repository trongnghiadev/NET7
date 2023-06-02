using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }


        [Column("username")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(100, ErrorMessage = "Tên đăng nhập không được vượt quá 100 ký tự")]
        public string Username { get; set; } = "";

        [Column("hashed_password")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(200, ErrorMessage = "Mật khẩu không được vượt quá 200 ký tự")]
        public string HashedPassword { get; set; } = "";

        [Column("email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(255, ErrorMessage = "Email không được vượt quá 255 ký tự")]
        public string Email { get; set; } = "";

        [Column("phone")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự")]
        public string Phone { get; set; } = "";

        [Column("full_name")]
        [StringLength(255, ErrorMessage = "Họ và tên không được vượt quá 255 ký tự")]
        public string FullName { get; set; } = "";

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("country")]
        [StringLength(200, ErrorMessage = "Quốc gia không được vượt quá 200 ký tự")]
        public string Country { get; set; } = "";
    }
}
