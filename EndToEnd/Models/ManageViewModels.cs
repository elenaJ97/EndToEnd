using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EndToEnd.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Новата озинка треба да има најмалку {2} карактери.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова лозинка")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потврдете нова лозинка")]
        [Compare("NewPassword", ErrorMessage = "Внесените лозинки не се исти.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Погрешно внесена тековна лозинка")]
        [DataType(DataType.Password)]
        [Display(Name = "Тековна лозинка")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Новатата лозинка треба да има најмалку {2} карактери.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова лозинка")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потврдете нова лозинка")]
        [Compare("NewPassword", ErrorMessage = "Внесените лозинки не се исти")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Телефонски број")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "код")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Телефонски број")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}