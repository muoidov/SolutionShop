using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SolutionShop.ViewModel.System.Users
{
    public class UserVm
    {
        public Guid Id { get; set; }
        [Display(Name="Tên")]
        public string FirstName { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Display(Name = "Sđt")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tên đn")]
        public string UserName { get; set; }
        [Display(Name = "Mail")]
        public string Email { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime Dob { get; set; }
    }
}
