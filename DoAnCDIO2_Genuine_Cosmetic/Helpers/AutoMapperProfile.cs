using AutoMapper;
using DoAnCDIO2_Genuine_Cosmetic.Data;
using DoAnCDIO2_Genuine_Cosmetic.ViewModels;

namespace DoAnCDIO2_Genuine_Cosmetic.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<RegisterVM, KhachHang>();
        }
    }
}
