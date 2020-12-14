using FluentValidation;
using System;

namespace SolutionShop.ViewModel.System.Users
{
    public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Nhap vao di ban").MaximumLength(200).WithMessage("Qua dai");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Nhap vao di ban").MaximumLength(200).WithMessage("Qua dai");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-1009)).WithMessage("Khong the lon hon 1000 nam");
            RuleFor(x => x.Email).NotEmpty().Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Ko dung cu phap");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Ko the de trong sdt");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bat buoc nhap username");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Bat buoc nhap pass").MinimumLength(6).WithMessage("mat khau toi thieu la 6");
            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.PassWord!= request.ConfirmPassword)
                {
                    context.AddFailure("Xac nhan mat khau ko khop");
                }
            });

        }
    }
}
