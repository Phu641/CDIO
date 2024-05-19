using AutoMapper;
using DoAnCDIO2_Genuine_Cosmetic.Data;
using DoAnCDIO2_Genuine_Cosmetic.Helpers;
using DoAnCDIO2_Genuine_Cosmetic.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoAnCDIO2_Genuine_Cosmetic.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly GenuineCosmeticContext db;
        private readonly IMapper _mapper;

        public KhachHangController(GenuineCosmeticContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        #region Register
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var khachHang = _mapper.Map<KhachHang>(model);
                    khachHang.RandomKey = MyUtil.GenerateRamdomKey();
                    khachHang.MatKhau = model.MatKhau.ToMd5Hash(khachHang.RandomKey);
                    khachHang.HieuLuc = true; // Sẽ xử lý khi dùng Mail để active
                    khachHang.VaiTro = 0;

                    db.Add(khachHang);
                    db.SaveChanges();
                    return RedirectToAction("Index", "HangHoa");
                }
                catch (Exception ex)
                {
                    var mess = $"{ex.Message} shh";
                }
            }
            return View();
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult DangNhap(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl ?? "/";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl ?? "/";
            if (ModelState.IsValid)
            {
                var khachHang = db.KhachHangs.SingleOrDefault(kh => kh.MaKh == model.UserName);
                if (khachHang == null)
                {
                    ModelState.AddModelError("loi", "Không có khách hàng này");
                }
                else
                {
                    if (!khachHang.HieuLuc)
                    {
                        ModelState.AddModelError("loi", "Tài khoản đã bị khóa. Vui lòng liên hệ Admin.");
                    }
                    else
                    {
                        if (khachHang.MatKhau != model.Password.ToMd5Hash(khachHang.RandomKey))
                        {
                            ModelState.AddModelError("loi", "Sai thông tin đăng nhập");
                        }
                        else
                        {
                            var claims = new List<Claim> {
                                new Claim(ClaimTypes.Email, khachHang.Email),
                                new Claim(ClaimTypes.Name, khachHang.HoTen),
                                new Claim(MySetting.CLAIM_CUSTOMERID, khachHang.MaKh),
                                // Thêm claim vai trò
                                new Claim(ClaimTypes.Role, khachHang.VaiTro == 0 ? "Customer" : "Admin")
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                            await HttpContext.SignInAsync(claimsPrincipal);

                            // Điều hướng dựa trên vai trò
                            if (khachHang.VaiTro == 0)
                            {
                                TempData["Username"] = khachHang.MaKh;
                                return RedirectToAction("Profile");
                            }
                            else if (khachHang.VaiTro == 1)
                            {
                                TempData["Adminname"] = khachHang.MaKh;
                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                                {
                                    return Redirect(ViewBag.ReturnUrl);
                                }
                                else
                                {
                                    return Redirect("/");
                                }
                            }
                        }
                    }
                }
            }
            return View();
        }
        #endregion

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
