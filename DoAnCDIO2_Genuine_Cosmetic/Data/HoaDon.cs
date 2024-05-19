using System;
using System.Collections.Generic;

namespace DoAnCDIO2_Genuine_Cosmetic.Data;

public partial class HoaDon
{
    public int MaHd { get; set; }

    public string? MaKh { get; set; } = null! ; 

    public DateTime? NgayDat { get; set; }

    public DateTime? NgayGiao { get; set; }

    public string? HoTen { get; set; }

    public string? DiaChi { get; set; } = null!;

    public string? DienThoai { get; set; }

	public string? CachThanhToan { get; set; } = null!;

    public string? CachVanChuyen { get; set; } = null!;

    public decimal? PhiVanChuyen { get; set; }

    public int? MaTrangThai { get; set; }

    public int? MaNv { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang? MaKhNavigation { get; set; } = null; 

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual TrangThai? MaTrangThaiNavigation { get; set; } = null!;
}
