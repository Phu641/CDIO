using DoAnCDIO2_Genuine_Cosmetic.Data;
using DoAnCDIO2_Genuine_Cosmetic.Helpers;
using DoAnCDIO2_Genuine_Cosmetic.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace DoAnCDIO2_Genuine_Cosmetic.ViewComponents
{
    public class ConveyorViewComponent : ViewComponent
    {
        private readonly GenuineCosmeticContext db;



        public ConveyorViewComponent(GenuineCosmeticContext context) => db = context;



        public IViewComponentResult Invoke()
        {
            var result = db.HangHoas
                            .Where(p => p.MaLoai == 1001)

                            .Select(p => new ConveyorVM
                            {
                                MaHh = p.MaHh,
                                TenHh = p.TenHh ?? "",
                                Hinh = p.Hinh ?? "",
                                DonGia = p.DonGia ?? 0,
                                TenLoai = p.MaLoaiNavigation.TenLoai
                            });

            return View(result);
        }


    }
}
