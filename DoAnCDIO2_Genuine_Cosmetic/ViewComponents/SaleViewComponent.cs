using DoAnCDIO2_Genuine_Cosmetic.Data;
using DoAnCDIO2_Genuine_Cosmetic.Helpers;
using DoAnCDIO2_Genuine_Cosmetic.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace DoAnCDIO2_Genuine_Cosmetic.ViewComponents
{
    public class SaleViewComponent : ViewComponent
    {
        private readonly GenuineCosmeticContext db;
        public SaleViewComponent(GenuineCosmeticContext context) => db = context;
        public IViewComponentResult Invoke()
        {
            var result = db.HangHoas
                            .Where(p => p.GiamGia > 0)

                            .Select(p => new SaleVM
                            {
                                MaHh = p.MaHh,
                                TenHh = p.TenHh ?? "",
                                Hinh = p.Hinh ?? "",
                                GiamGia = p.GiamGia ?? 0,
                                TenLoai = p.MaLoaiNavigation.TenLoai
                            });

            return View(result);
        }


    }
}
