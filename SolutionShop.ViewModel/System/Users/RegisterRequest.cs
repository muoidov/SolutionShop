using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        [DataType(DataType.Password)]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Display(Name = "Xác nhận lại mk")]
        public string ConfirmPassword { get; set; }
    }
}
