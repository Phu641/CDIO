using System;
using System.Collections.Generic;

namespace DoAnCDIO2_Genuine_Cosmetic.Data;

public partial class HangHoa
{
    public int MaHh { get; set; }

    public string? TenHh { get; set; }

    public string? HangSx { get; set; }

    public int? MaLoai { get; set; }

    public string? MoTaDonVi { get; set; }

    public double? DonGia { get; set; }

    public string? Hinh { get; set; }

    public DateOnly? NgaySx { get; set; }

    public float? GiamGia { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual Loai? MaLoaiNavigation { get; set; }
}
