using System;
using System.Collections.Generic;

namespace DoAnCDIO2_Genuine_Cosmetic.Data;

public partial class Loai
{
    public int MaLoai { get; set; }

    public string? TenLoai { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
}
