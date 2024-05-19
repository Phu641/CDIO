using System;
using System.Collections.Generic;

namespace DoAnCDIO2_Genuine_Cosmetic.Data;

public partial class ChiTietHoaDon
{
    public int MaCt { get; set; }

    public int MaHd { get; set; }

    public int MaHh { get; set; }

    public double? DonGia { get; set; }

    public int SoLuong { get; set; }

    public decimal? GiamGia { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual HangHoa MaHhNavigation { get; set; } = null!;
}
