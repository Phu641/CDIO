using DoAnCDIO2_Genuine_Cosmetic.Data;
using Microsoft.AspNetCore.Mvc;
using DoAnCDIO2_Genuine_Cosmetic.Helpers;
using DoAnCDIO2_Genuine_Cosmetic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using DoAnCDIO2_Genuine_Cosmetic.Services;
namespace DoAnCDIO2_Genuine_Cosmetic.Controllers
{
	public class CartController : Controller
	{
		private readonly GenuineCosmeticContext db;
		private readonly IVnPayService _vnPayservice;

		public CartController(GenuineCosmeticContext context, IVnPayService vnPayService)
		{
			db = context;
			_vnPayservice = vnPayService;
		}

		public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();


		public IActionResult Index()
		{
			return View(Cart);
		}

		public IActionResult AddToCart(int id, int quantity = 1)
		{
			var gioHang = Cart;
			var item = gioHang.SingleOrDefault(p => p.MaHh == id);

			if (item == null)
			{
				var hangHoa = db.HangHoas.SingleOrDefault(p => p.MaHh == id);
				if (hangHoa == null)
				{
					TempData["Message"] = $"Không tìm thấy hàng hoá ";
					return Redirect("/404");
				}
				item = new CartItem
				{
					MaHh = hangHoa.MaHh,
					TenHh = hangHoa.TenHh,
					DonGia = hangHoa.DonGia ?? 0,
					Hinh = hangHoa.Hinh ?? string.Empty,
					soluong = quantity
				};
				gioHang.Add(item);

			}
			else
			{
				item.soluong += quantity;
			}
			HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
			return RedirectToAction("Index");

		}
		public IActionResult RemoveCart(int id)
		{
			var gioHang = Cart;
			var item = gioHang.SingleOrDefault(p => p.MaHh == id);

			if (item != null)
			{
				gioHang.Remove(item);
				HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
			}
			return RedirectToAction("Index");

		}
		[Authorize]
		[HttpGet]
		public IActionResult Checkout()
		{

			if (Cart.Count == 0)
			{

				return Redirect("/");
			}

			return View(Cart);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Checkout(CheckoutVM model, string payment = "COD")
		{
			if (ModelState.IsValid)
			{
				if (payment == "Thanh toán VNPay")
				{
					var vnPayModel = new VnPaymentRequestModel
					{
						Amount =Cart.Sum(p => p.ThanhTien),
						CreatedDate = DateTime.Now,
						Description= $"{model.HoTen} {model.DienThoai}",
						FullName = model.HoTen,
						OrderId = new Random().Next(1000,100000)
					};
					return Redirect(_vnPayservice.CreatePaymentUrl(HttpContext, vnPayModel)); 
				}

				var customerId = HttpContext.User.Claims.SingleOrDefault(p => p.Type == MySetting.CLAIM_CUSTOMERID).Value;
				var khachHang = new KhachHang();
				if (model.GiongKhachHang)
				{
					khachHang = db.KhachHangs.SingleOrDefault(kh => kh.MaKh == customerId);
				}

				var hoadon = new HoaDon
				{
					MaKh = customerId,
					HoTen = model.HoTen ?? khachHang.HoTen,
					DiaChi = model.DiaChi ?? khachHang.DiaChi,
					DienThoai = model.DienThoai ?? khachHang.DienThoai,
					NgayDat = DateTime.Now,
					CachThanhToan = "COD",
					CachVanChuyen = "ShipCod",
					MaTrangThai = 0,
					GhiChu = model.GhiChu
				};

				db.Database.BeginTransaction();
				try
				{
					db.Database.CommitTransaction();
					db.Add(hoadon);
					db.SaveChanges();

					var cthds = new List<ChiTietHoaDon>();
					foreach (var item in Cart)
					{
						cthds.Add(new ChiTietHoaDon
						{
							MaHd = hoadon.MaHd,
							MaHh = item.MaHh,
							DonGia = item.DonGia,
							SoLuong = item.soluong,
							GiamGia = 0
						});
					}
					db.AddRange(cthds);
					db.SaveChanges();

					HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());

					return View("Success");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error occurred: " + ex.Message);

					db.Database.RollbackTransaction();
				}
			}

			return View(Cart);
		}

		[Authorize]
		public IActionResult PaymentSuccess()
		{
			return View("Success");
		}


		[Authorize]
		public IActionResult PaymentFail()
		{
			return View();	
		}


		[Authorize]
		public IActionResult PaymentCallBack(CheckoutVM model)
		{
			var respone = _vnPayservice.PaymentExecute(Request.Query);
			if (respone == null || respone.VnPayResponseCode != "00")
			{
				TempData["Message"] = "Lỗi Thanh Toán VNPAY ";
				return RedirectToAction("PaymentFail");
			}

			// Lấy mã khách hàng từ thông tin người dùng đăng nhập (nếu có)
			var customerId = HttpContext.User.Claims.SingleOrDefault(p => p.Type == MySetting.CLAIM_CUSTOMERID)?.Value;

			// Tạo một đối tượng KhachHang để lấy thông tin khách hàng (nếu cần)
			var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKh == customerId);

			// Tạo đối tượng Hóa đơn từ thông tin CheckoutVM và response từ VNPay
			var hoadon = new HoaDon
			{
				MaKh = customerId,
				HoTen = model.HoTen ?? khachHang?.HoTen,
				DiaChi = model.DiaChi ?? khachHang?.DiaChi,
				DienThoai = model.DienThoai ?? khachHang?.DienThoai,
				NgayDat = DateTime.Now,
				CachThanhToan = "Thanh toán VNPay",
				CachVanChuyen = "ShipCod",
				MaTrangThai = 0,
				GhiChu = model.GhiChu
			};

			// Lưu hóa đơn vào cơ sở dữ liệu
			db.Add(hoadon);
			db.SaveChanges();

			// Lưu các chi tiết hóa đơn từ giỏ hàng vào cơ sở dữ liệu
			var cthds = new List<ChiTietHoaDon>();
			foreach (var item in Cart)
			{
				cthds.Add(new ChiTietHoaDon
				{
					MaHd = hoadon.MaHd,
					MaHh = item.MaHh,
					DonGia = item.DonGia,
					SoLuong = item.soluong,
					GiamGia = 0
				});
			}
			db.AddRange(cthds);
			db.SaveChanges();

			// Xóa giỏ hàng trong Session sau khi đặt hàng thành công
			HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());

			TempData["Message"] = "Thanh Toán VNPAY Thành Công";
			return RedirectToAction("PaymentSuccess");
		}
	}
}