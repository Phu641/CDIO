using System.ComponentModel.DataAnnotations;

namespace DoAnCDIO2_Genuine_Cosmetic.ViewModels
{
	public class RegisterVM
	{
		[Key]
		[Display(Name = "User name")]
		[Required(ErrorMessage = "Invalid login name")]
		[MaxLength(20, ErrorMessage = "Maximum 20 characters")]
		public string MaKh { get; set; }


		[Display(Name = "Password")]
		[Required(ErrorMessage = "Invalid password")]
		[DataType(DataType.Password)]
		public string MatKhau { get; set; }

		[Display(Name = "Fullname")]
		[Required(ErrorMessage = "Invalid fullname")]
		[MaxLength(50, ErrorMessage = "Maximum 50 characters")]
		public string HoTen { get; set; }

		public bool GioiTinh { get; set; } = true; 
		[Display(Name = "Birthday")]
		[DataType(DataType.Date)]
		public DateTime? NgaySinh { get; set; }

		[Display(Name = "Address")]
		[MaxLength(60, ErrorMessage = "Maximum 60 characters")]
		public string DiaChi { get; set; }

		[Display(Name = "Phone")]
		[MaxLength(24, ErrorMessage = "Maximum 24 characters")]
		[RegularExpression(@"0[9875]\d{8}", ErrorMessage = "Not correct Vietnamese mobile format")]
		public string DienThoai { get; set; }


		[EmailAddress(ErrorMessage = "Incorrect email format")]
		public string Email { get; set; }
	}
}