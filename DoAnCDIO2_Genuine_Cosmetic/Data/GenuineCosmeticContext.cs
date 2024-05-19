using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoAnCDIO2_Genuine_Cosmetic.Data;

public partial class GenuineCosmeticContext : DbContext
{
	public GenuineCosmeticContext()
	{
	}

	public GenuineCosmeticContext(DbContextOptions<GenuineCosmeticContext> options)
		: base(options)
	{
	}

	public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

	public virtual DbSet<HangHoa> HangHoas { get; set; }

	public virtual DbSet<HoaDon> HoaDons { get; set; }

	public virtual DbSet<KhachHang> KhachHangs { get; set; }

	public virtual DbSet<Loai> Loais { get; set; }

	public virtual DbSet<NhanVien> NhanViens { get; set; }

	public virtual DbSet<TrangThai> TrangThais { get; set; }

	//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
	//     => optionsBuilder.UseSqlServer("Data Source=DESKTOP-56MJ47T;Initial Catalog=Genuine_Cosmetic;Persist Security Info=True;User ID=sa;Password=123;Encrypt=True;Trust Server Certificate=True");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ChiTietHoaDon>(entity =>
		{
			entity.HasKey(e => e.MaCt).HasName("PK__ChiTietH__27258E745910D27E");

			entity.ToTable("ChiTietHoaDon");

			entity.Property(e => e.MaCt).HasColumnName("MaCT");
			entity.Property(e => e.DonGia).HasColumnType("double");
			entity.Property(e => e.GiamGia).HasColumnType("decimal(5, 2)");
			entity.Property(e => e.MaHd).HasColumnName("MaHD");
			entity.Property(e => e.MaHh).HasColumnName("MaHH");

			entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHoaDons)
				.HasForeignKey(d => d.MaHd)
				.HasConstraintName("FK__ChiTietHoa__MaHD__45F365D3");

			entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.ChiTietHoaDons)
				.HasForeignKey(d => d.MaHh)
				.HasConstraintName("FK__ChiTietHoa__MaHH__46E78A0C");
		});

		modelBuilder.Entity<HangHoa>(entity =>
		{
			entity.HasKey(e => e.MaHh).HasName("PK__HangHoa__2725A6E4371AC233");

			entity.ToTable("HangHoa");

			entity.Property(e => e.MaHh)
				.ValueGeneratedNever()
				.HasColumnName("MaHH");
			entity.Property(e => e.DonGia).HasColumnType("double");
			entity.Property(e => e.GiamGia).HasColumnType("decimal(5, 2)");
			entity.Property(e => e.HangSx)
				.HasMaxLength(50)
				.HasColumnName("HangSX");
			entity.Property(e => e.Hinh).HasMaxLength(255);
			entity.Property(e => e.MoTaDonVi).HasMaxLength(255);
			entity.Property(e => e.NgaySx).HasColumnName("NgaySX");
			entity.Property(e => e.TenHh)
				.HasMaxLength(100)
				.HasColumnName("TenHH");

			entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.HangHoas)
				.HasForeignKey(d => d.MaLoai)
				.HasConstraintName("FK_HangHoa_Loai");
		});

		modelBuilder.Entity<HoaDon>(entity =>
		{
			entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E0FC188ACE");

			entity.ToTable("HoaDon");

			entity.Property(e => e.MaHd).HasColumnName("MaHD");
			entity.Property(e => e.CachThanhToan).HasMaxLength(50);
			entity.Property(e => e.CachVanChuyen).HasMaxLength(50);
			entity.Property(e => e.DiaChi).HasMaxLength(255);
			entity.Property(e => e.HoTen).HasMaxLength(100);
			entity.Property(e => e.MaKh).HasColumnName("MaKH");
			entity.Property(e => e.MaNv).HasColumnName("MaNV");
			entity.Property(e => e.PhiVanChuyen).HasColumnType("decimal(18, 2)");

			entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
				.HasForeignKey(d => d.MaKh)
				.HasConstraintName("FK__HoaDon__MaKH__412EB0B6");

			entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons)
				.HasForeignKey(d => d.MaNv)
				.HasConstraintName("FK__HoaDon__MaNV__4316F928");

			entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.HoaDons)
				.HasForeignKey(d => d.MaTrangThai)
				.HasConstraintName("FK__HoaDon__MaTrangT__4222D4EF");
		});

		modelBuilder.Entity<KhachHang>(entity =>
		{
			entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1EC150C998");

			entity.ToTable("KhachHang");

			entity.Property(e => e.MaKh)
				.HasMaxLength(10)
				.HasColumnName("MaKH");
			entity.Property(e => e.DiaChi).HasMaxLength(255);
			entity.Property(e => e.DienThoai).HasMaxLength(20);
			entity.Property(e => e.Email).HasMaxLength(100);
			entity.Property(e => e.HoTen).HasMaxLength(100);
			entity.Property(e => e.GioiTinh).HasMaxLength(10);
			entity.Property(e => e.MatKhau).HasMaxLength(50);
			entity.Property(e => e.VaiTro).HasMaxLength(50);
			entity.Property(e => e.NgaySinh)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("date");
			entity.Property(e => e.RandomKey)
				.HasMaxLength(50)
				.IsUnicode(false);
		});

		modelBuilder.Entity<Loai>(entity =>
		{
			entity.HasKey(e => e.MaLoai).HasName("PK__Loai__730A5759D4B8926D");

			entity.ToTable("Loai");

			entity.Property(e => e.MaLoai).ValueGeneratedNever();
			entity.Property(e => e.TenLoai).HasMaxLength(100);
		});

		modelBuilder.Entity<NhanVien>(entity =>
		{
			entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A6184906A");

			entity.ToTable("NhanVien");

			entity.Property(e => e.MaNv)
				.ValueGeneratedNever()
				.HasColumnName("MaNV");
			entity.Property(e => e.Email).HasMaxLength(100);
			entity.Property(e => e.HoTen).HasMaxLength(100);
			entity.Property(e => e.MatKhau).HasMaxLength(50);
		});

		modelBuilder.Entity<TrangThai>(entity =>
		{
			entity.HasKey(e => e.MaTrangThai).HasName("PK__TrangTha__AADE41382DB9087D");

			entity.ToTable("TrangThai");

			entity.Property(e => e.MaTrangThai).ValueGeneratedNever();
			entity.Property(e => e.TenTrangThai).HasMaxLength(50);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}