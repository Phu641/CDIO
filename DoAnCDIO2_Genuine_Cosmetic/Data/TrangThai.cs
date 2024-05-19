using System;
using System.Collections.Generic;

namespace DoAnCDIO2_Genuine_Cosmetic.Data;

public partial class TrangThai
{
    public int MaTrangThai { get; set; }

    public string? TenTrangThai { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
