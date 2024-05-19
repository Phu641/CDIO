using DoAnCDIO2_Genuine_Cosmetic.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Policy;
namespace DoAnCDIO2_Genuine_Cosmetic.ViewModels
{
	public class LoginVM
	{
		[Display(Name = "User name")]
		[Required(ErrorMessage = "User name has not been entered")]
		[MaxLength(20, ErrorMessage = "Maximum 20 characters")]
		public string UserName { get; set; }

		[Display(Name = "Password")]
		[Required(ErrorMessage = "Password has not been entered")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}

