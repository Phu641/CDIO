using DoAnCDIO2_Genuine_Cosmetic.Helpers;
using DoAnCDIO2_Genuine_Cosmetic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCDIO2_Genuine_Cosmetic.ViewComponents
{
    public class CartViewComponent : ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
            return View("CartPanel",new CartModel { 
                Quantity = cart.Sum(p => p.soluong),
                Total = cart.Sum( p => p.ThanhTien) 
                
                });

        }
    }
}
