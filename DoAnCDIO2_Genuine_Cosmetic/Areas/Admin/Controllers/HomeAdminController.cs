using DoAnCDIO2_Genuine_Cosmetic.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAnCDIO2_Genuine_Cosmetic.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    [Authorize(Roles = "Admin")]
    public class HomeAdminController : Controller
    {
        GenuineCosmeticContext db = new GenuineCosmeticContext();
        [Route("")]
        [Route("index")]

        public IActionResult Index()
        {
            return View();
        }

        private readonly GenuineCosmeticContext Db;
        public HomeAdminController(GenuineCosmeticContext context)
        {
            Db = context;
        }

       


        [Route("danhmucloaisanpham")]

        public IActionResult DanhMucLoaiSanPham()
        {
            var lstSanPham = Db.Loais.ToList();
            return View(lstSanPham);
        }


        [Route("ThemLoaiSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemLoaiSanPhamMoi()
        {
            return View();
        }



        [Route("ThemLoaiSanPhamMoi")]
        [HttpPost]
        public IActionResult ThemLoaiSanPhamMoi(Loai  loaihangHoa)
        {
            if (ModelState.IsValid)
            {
                Db.Loais.Add(loaihangHoa);
                Db.SaveChanges();
                return RedirectToAction("DanhMucLoaiSanPham");
            }
            return View(loaihangHoa);
        }

       

        [Route("SuaLoaiSanPham/{MaLoai}")]
        [HttpGet]
        public IActionResult SuaLoaiSanPham(int MaLoai)
        {
            var loaisanPham = Db.Loais.Find(MaLoai);

            return View(loaisanPham);
        }


        [Route("SuaLoaiSanPham/{MaLoai}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaLoaiSanPham(Loai loaisanPham)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(loaisanPham).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("DanhMucLoaiSanPham", "HomeAdmin");
            }
            return View(loaisanPham);
        }

        [Route("XoaLoaiSanPham/{MaLoai}")]
        [HttpGet]
        public IActionResult XoaLoaiSanPham(int MaLoai)
        {
            TempData["Message"] = "";
            var hangHoa = Db.HangHoas.Where(x => x.MaLoai == MaLoai).ToList();
            if (hangHoa.Count > 0)
            {
                TempData["Message"] = "Xoá Loại Sản Phẩm Thất Bại ";
                return RedirectToAction("DanhMucLoaiSanPham", "HomeAdmin");
            }
            Db.Remove(Db.Loais.Find(MaLoai));
            Db.SaveChanges();
            TempData["Message"] = "Sản Phẩm Đã Được Xoá ";
            return RedirectToAction("DanhMucLoaiSanPham", "HomeAdmin");
        }

        [Route("danhmucsanpham")]

        public IActionResult DanhMucSanPham()
        {
            var lstSanPham = Db.HangHoas.ToList();
            return View(lstSanPham);
        }

        [Route("ThemSanPhamMoii")]
        [HttpGet]
        public IActionResult ThemSanPhamMoii() {
            ViewBag.MaLoai = new SelectList(Db.Loais.ToList(), "MaLoai", "TenLoai");
            return View(); 
        }


        [Route("ThemSanPhamMoii")]
        [HttpPost]
        public IActionResult ThemSanPhamMoii(HangHoa hangHoa)
        {
            if(ModelState.IsValid)
            {
                Db.HangHoas.Add(hangHoa);
                Db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(hangHoa);
        }

        [Route("SuaSanPham/{MaHh}")]
        [HttpGet]
        public IActionResult SuaSanPham(int MaHh)
        {
            ViewBag.MaLoai = new SelectList(Db.Loais.ToList(), "MaLoai", "TenLoai");
            var sanPham = Db.HangHoas.Find(MaHh);

            return View(sanPham);
        }


        [Route("SuaSanPham/{MaHh}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(hangHoa).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("DanhMucSanPham","HomeAdmin");
            }
            return View(hangHoa);
        }

        [Route("XoaSanPham/{MaHh}")]
        [HttpGet]
        public IActionResult XoaSanPham(int MaHh)
        {
            TempData["Message"] = "";
            var chiTietHoaDon = Db.ChiTietHoaDons.Where(x=> x.MaHh == MaHh).ToList();
            if(chiTietHoaDon.Count > 0)
            {
                TempData["Message"] = "Xoá Sản Phẩm Thất Bại ";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin"); 
            }
            Db.Remove(Db.HangHoas.Find(MaHh));  
            Db.SaveChanges();
            TempData["Message"] = "Sản Phẩm Đã Được Xoá ";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }

        [Route("DanhSachKhachHang")]
        public IActionResult DanhSachKhachHang()
        {
            var lstKhachHang = Db.KhachHangs.ToList();  
            return View(lstKhachHang);
        }


        [Route("QuanLyTaiKhoan/{MaKh}")]
        [HttpGet]
        public IActionResult QuanLyTaiKhoan(string MaKh)
        {
            var khachHang = Db.KhachHangs.Find(MaKh);

            return View(khachHang);
        }


        [Route("QuanLyTaiKhoan/{MaKh}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult QuanLyTaiKhoan(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(khachHang).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("DanhSachKhachHang", "HomeAdmin");
            }
            return View(khachHang);
        }

        [Route("ChiTietDonHang")]
        public IActionResult ChiTietDonHang(int MaHh)
        {
            var lstChiTietHoaDong = Db.ChiTietHoaDons.ToList();
            return View(lstChiTietHoaDong);
        }









        [Route("DanhSachDonHang")]
        public IActionResult DanhSachDonHang()
        {

            var lstDonHang = Db.HoaDons.Include(h => h.MaTrangThaiNavigation).ToList();

            // Tạo danh sách chứa thông tin về MaTrangThai và TenTrangThai
            var trangThaiList = lstDonHang.Select(donHang => new
            {
                MaTrangThai = donHang.MaTrangThaiNavigation?.MaTrangThai,
                TenTrangThai = donHang.MaTrangThaiNavigation?.TenTrangThai
            }).Distinct().ToList();

            // Gán danh sách trạng thái cho ViewBag
            ViewBag.TrangThai = trangThaiList;

            return View(lstDonHang);
        }


    }
}
