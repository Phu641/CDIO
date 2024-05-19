using DoAnCDIO2_Genuine_Cosmetic.Data;
using DoAnCDIO2_Genuine_Cosmetic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using X.PagedList;

namespace DoAnCDIO2_Genuine_Cosmetic.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly GenuineCosmeticContext Db;

        public HangHoaController(GenuineCosmeticContext context) {
            Db = context;
        }


        public IActionResult Index(int? loai)
        {
            var  HangHoas  = Db.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
                HangHoas = HangHoas.Where(p => p.MaLoai == loai.Value) ;
            }
            var result = HangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh ?? "",
                Hinh = p.Hinh ?? "",
                DonGia = p.DonGia ?? 0,
                TenLoai = p.MaLoaiNavigation.TenLoai 
            }) ;  
            return View(result);
        }

        public IActionResult Detail(int id)
        {
           var data = Db.HangHoas
                .Include(p => p.MaLoaiNavigation)
                .SingleOrDefault(p=> p.MaHh == id);
            if(data == null)
            {
                TempData["Message"] = "Không tìm thấy sản phẩm "; 
                return Redirect("/404"); 
            }
            var result = new ChiTietHangHoaVM
            {
                MaHh = data.MaHh,
                TenHh = data.TenHh,
                HangSx =data.HangSx, 
                DonGia = data.DonGia ?? 0,
                ChiTiet = data.MoTa ?? string.Empty,
                Hinh = data.Hinh ?? string.Empty,
                TenLoai = data.MaLoaiNavigation.TenLoai,
                DiemDanhGia = 5,
                SoLuongTon = 10 , 

            }; 
            return View(result); 
        }

        public IActionResult Conveyor(int? loai)
        {
            var HangHoas = Db.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
                HangHoas = HangHoas.Where(p => p.MaLoai == loai.Value);
            }
            var result = HangHoas.Select(p => new ConveyorVM
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh ?? "",
                Hinh = p.Hinh ?? "",
                DonGia = p.DonGia ?? 0,
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }
        //public IActionResult phantrang(int? page)
        //{
        //    int pageSize = 8;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    var lstSp = Db.HangHoas.AsNoTracking().OrderBy(x=>x.TenHh);
        //    PagedList<HangHoa> lst = new PagedList<HangHoa>(lstSp,pageNumber,pageSize) ;

        //    return View(lst);
        //}

        //public async Task<IActionResult> Index(int? loai, int? page)
        //{
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);

        //    var hangHoas = Db.HangHoas.AsQueryable();

        //    if (loai.HasValue)
        //    {
        //        hangHoas = hangHoas.Where(p => p.MaLoai == loai.Value);
        //    }

        //    var result = hangHoas.Select(p => new HangHoaVM
        //    {
        //        MaHh = p.MaHh,
        //        TenHh = p.TenHh ?? "",
        //        Hinh = p.Hinh ?? "",
        //        DonGia = p.DonGia ?? 0,
        //        TenLoai = p.MaLoaiNavigation.TenLoai
        //    }).OrderBy(h => h.TenHh);

        //    var pagedResult = await result.ToPagedListAsync(pageNumber, pageSize);
        //    return View(pagedResult);
        //}

    }
}
