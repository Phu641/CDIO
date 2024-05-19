using DoAnCDIO2_Genuine_Cosmetic.ViewModels;

namespace DoAnCDIO2_Genuine_Cosmetic.Services
{
	public interface IVnPayService
	{
		string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model);
		VnPaymentResponseModel PaymentExecute(IQueryCollection collections);
	}
}
