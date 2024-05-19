using DoAnCDIO2_Genuine_Cosmetic.Data;
using DoAnCDIO2_Genuine_Cosmetic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCDIO2_Genuine_Cosmetic.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly GenuineCosmeticContext db;

        public MenuLoaiViewComponent(GenuineCosmeticContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai  =     lo.MaLoai,
                TenLoai =     lo.TenLoai,
                SoLuong =     lo.HangHoas.Count
            }); 
            return View(data);
        }
    }
}
