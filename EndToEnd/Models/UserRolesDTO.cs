using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class ExpandedUserDTO
    {
        [Key]
        [Display(Name = "Корисничко име")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Wrong email format.")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Лозинка")]
        public string Password { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public int AccessFailedCount { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Изберете улога!")]
        [Display(Name = "Улога")]
        public IEnumerable<UserRolesDTO> Roles { get; set; }

    }
    public class UserRolesDTO
    {
        [Key]
        [Display(Name = "Улога")]
        [Required(ErrorMessage = "Изберете улога!")]
        public string RoleName { get; set; }
    }
  
    public class UserRoleDTO
    {
        [Key]
        [Display(Name = "Корисничко име")]
        public string UserName { get; set; }
        [Display(Name = "Улога")]
        [Required(ErrorMessage = "Изберете улога!")]
        public string RoleName { get; set; }
    }
    public class RoleDTO
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Улога")]
        [Required(ErrorMessage = "Изберете улога!")]
        public string RoleName { get; set; }
    }
    public class UserAndRolesDTO
    {
        [Key]
        [Display(Name = "Корисничко име")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Изберете улога!")]
        public List<UserRoleDTO> colUserRoleDTO { get; set; }
    }
}