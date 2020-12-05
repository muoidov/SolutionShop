using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.ViewModel.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bat buoc nhap username");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Bat buoc nhap pass").MinimumLength(6).WithMessage("mat khau toi thieu la 6");
            
        }
    }
}
