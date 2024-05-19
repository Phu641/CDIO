using System;
using System.Collections.Generic;

namespace DoAnCDIO2_Genuine_Cosmetic.Data;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string? HoTen { get; set; }

    public string? Email { get; set; }

    public string? MatKhau { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
