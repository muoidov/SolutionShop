using System;
using System.ComponentModel.DataAnnotations;

namespace SolutionShop.ViewModel.System.Users
{
    public class RegisterRequest
    {
        [Display(Name="Tên")]
        public string FirstName { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [Display(Name = "Mail")]
        public string Email { get; set; }
        [Display(Name = "SĐT")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Display(Name = "Xác nhận lại mk")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
