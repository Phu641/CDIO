using DoAnCDIO2_Genuine_Cosmetic.Data;
using DoAnCDIO2_Genuine_Cosmetic.Helpers;
using DoAnCDIO2_Genuine_Cosmetic.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace DoAnCDIO2_Genuine_Cosmetic.ViewComponents
{
    public class Conveyor1ViewComponent : ViewComponent
    {
        private readonly GenuineCosmeticContext db;



        public Conveyor1ViewComponent(GenuineCosmeticContext context) => db = context;



        public IViewComponentResult Invoke()
        {
            var result = db.HangHoas
                            .Where(p => p.MaLoai == 1004)

                            .Select(p => new ConveyorVM1
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
