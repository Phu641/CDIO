USE [master]
GO
/****** Object:  Database [Genuine_Cosmetic]    Script Date: 5/1/2024 10:03:01 AM ******/
CREATE DATABASE [Genuine_Cosmetic]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Genuine_Cosmetic', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Genuine_Cosmetic.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Genuine_Cosmetic_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Genuine_Cosmetic_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Genuine_Cosmetic] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Genuine_Cosmetic].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Genuine_Cosmetic] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET ARITHABORT OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Genuine_Cosmetic] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Genuine_Cosmetic] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Genuine_Cosmetic] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Genuine_Cosmetic] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Genuine_Cosmetic] SET  MULTI_USER 
GO
ALTER DATABASE [Genuine_Cosmetic] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Genuine_Cosmetic] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Genuine_Cosmetic] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Genuine_Cosmetic] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Genuine_Cosmetic] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Genuine_Cosmetic] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Genuine_Cosmetic] SET QUERY_STORE = ON
GO
ALTER DATABASE [Genuine_Cosmetic] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Genuine_Cosmetic]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 5/1/2024 10:03:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaCT] [int] NOT NULL,
	[MaHD] [int] NULL,
	[MaHH] [int] NULL,
	[DonGia] [decimal](18, 2) NULL,
	[SoLuong] [int] NULL,
	[GiamGia] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 5/1/2024 10:03:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHH] [int] NOT NULL,
	[TenHH] [nvarchar](100) NULL,
	[HangSX] [nvarchar](50) NULL,
	[MaLoai] [int] NULL,
	[MoTaDonVi] [nvarchar](255) NULL,
	[DonGia] [decimal](18, 2) NULL,
	[Hinh] [nvarchar](255) NULL,
	[NgaySX] [date] NULL,
	[GiamGia] [decimal](5, 2) NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 5/1/2024 10:03:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] NOT NULL,
	[MaKH] [int] NULL,
	[NgayDat] [date] NULL,
	[NgayGiao] [date] NULL,
	[HoTen] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[CachThanhToan] [nvarchar](50) NULL,
	[CachVanChuyen] [nvarchar](50) NULL,
	[PhiVanChuyen] [decimal](18, 2) NULL,
	[MaTrangThai] [int] NULL,
	[MaNV] [int] NULL,
	[GhiChu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/1/2024 10:03:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
	[HoTen] [nvarchar](100) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](255) NULL,
	[DienThoai] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Hinh] [nvarchar](255) NULL,
	[HieuLuc] [bit] NULL,
	[VaiTro] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loai]    Script Date: 5/1/2024 10:03:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[MaLoai] [int] NOT NULL,
	[TenLoai] [nvarchar](100) NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/1/2024 10:03:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[MatKhau] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 5/1/2024 10:03:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[MaTrangThai] [int] NOT NULL,
	[TenTrangThai] [nvarchar](50) NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTrangThai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (1, N'Sữa chống nắng Sunplay Skin Aqua Clear White SPF 50/PA++++ chai 25g
', N'Sunplay', 1001, N'Cái', CAST(100.00 AS Decimal(18, 2)), N'sua-chong-nang-sunplay-skin-aqua-clear-white-25g-060323-015222-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (2, N'Tinh chất chống nắng Sunplay Tone Up Essence Lavender SPF 50+/PA++++ tuýp 50g', N'
Sunplay', 1001, N'Cái', CAST(169.10 AS Decimal(18, 2)), N'tinh-chat-chong-nang-sunplay-tone-up-essence-lavender-spf-50-pa-50g-060323-015325-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (3, N'Sữa chống nắng Sunplay Skin Aqua Tone Up UV SPF50+/PA++++ hiệu chỉnh sắc da chai 50g', N'
Sunplay', 1001, N'Cái', CAST(169.10 AS Decimal(18, 2)), N'sua-chong-nang-sunplay-skin-aqua-spf-50-pa-50g-060323-015422-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (4, N'Sữa chống nắng La Roche-Posay Anthelios UVMune 400 Invisible Fluide chai 50ml', N'
La Roche-Posay', 1001, N'Cái', CAST(459.20 AS Decimal(18, 2)), N'sua-chong-nang-la-roche-posay-anthelios-uvmune-400-fluide-invisible-spf-50-060323-020258-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (5, N'Sữa chống nắng Anessa Skincare Milk SPF 50+/PA++++ dưỡng da, kiềm dầu chai 60ml', N'Anessa', 1001, N'Cái', CAST(715.00 AS Decimal(18, 2)), N'sua-chong-nang-anessa-spf-50-pa-duong-da-thumb-2-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (6, N'Sữa chống nắng Anessa Mild Milk SPF50+/PA++++ dịu nhẹ cho da nhạy cảm chai 60ml
', N'Anessa', 1001, N'Cái', CAST(715.00 AS Decimal(18, 2)), N'sua-chong-nang-anessa-spf50-pa-diu-nhe-cho-da-nhay-cam-chai-60ml-thumb1-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (7, N'Kem chống nắng Vichy Capital Soleil Anti-Dark Spot 3-in-1 (có màu) giảm thâm nám tuýp 50ml', N'Vichy', 1001, N'Cái', CAST(497.20 AS Decimal(18, 2)), N'kem-chong-nang-giam-tham-nam-vichy-ideal-soleil-sp-131023-015300-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (8, N'Kem chống nắng L’Oréal UV Defender Matte & Fresh SPF 50+/PA++++ kiềm dầu, mịn da chai 50ml', N'L''OREAL ', 1001, N'Cái', CAST(379.00 AS Decimal(18, 2)), N'kem-chong-nang-loreal-kiem-dau-thoang-min-da-spf-50-pa-50ml-thumb-1-5-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (9, N'Kem chống nắng Transino UV Protector SPF 50+/PA++++ dưỡng ẩm, trắng da tuýp 30ml', N'Transino', 1001, N'Cái', CAST(620.50 AS Decimal(18, 2)), N'kem-chong-nang-transino-uv-protector-spf-50-pa-duong-am-trang-da-30ml-thumb-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (10, N'Kem chống nắng La Roche-Posay Anthelios UVMune 400 Oil Control SPF 50+ tuýp 50ml', N'La Roche-Posay', 1001, N'Cái', CAST(476.00 AS Decimal(18, 2)), N'kem-chong-nang-la-roche-posay-anthelio-230523-025031-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (11, N'Kem chống nắng bí đao Cocoon SPF50+/ PA++++ cho da nhạy cảm, dầu mụn chai 50ml', N'
Cocoon', 1001, N'Cái', CAST(335.70 AS Decimal(18, 2)), N'kem-chong-nang-bi-dao-cocoon-spf50-pa-cho-da-nhay-cam-dau-mun-chai-50ml-thumb-1-2-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (12, N'Dầu gội chống gàu Selsun sạch gàu, hết ngứa chai 100ml', N'Rohto-Mentholatum', 1003, N'Cái', CAST(84.40 AS Decimal(18, 2)), N'dau-goi-chong-gau-selsun-anti-dandruff-shampoo-100-thumb-1-1-600x600.jpg', CAST(N'2024-01-09' AS Date), CAST(0.00 AS Decimal(5, 2)), NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (13, N'Dầu gội dược liệu Nguyên Xuân phù hợp tóc khô xơ, hư tổn chai 200ml', N'
Hoa Linh', 1003, N'Cái', CAST(60.80 AS Decimal(18, 2)), N'dau-goi-duoc-lieu-nguyen-xuan-xanh-chai-200ml-291223-102427-600x600.jpg', CAST(N'2024-01-09' AS Date), NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (14, N'Dầu gội dược liệu Nguyên Xuân bồng bềnh hương hoa chai 200ml
', N'
Hoa Linh', 1003, N'Cái', CAST(70.80 AS Decimal(18, 2)), N'dau-goi-duoc-lieu-nguyen-xuan-bong-benh-200ml-291223-102337-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (15, N'Dầu gội bưởi Cocoon dưỡng ẩm, giúp giảm rụng tóc chai 310ml
', N'
Cocoon', 1003, N'Cái', CAST(208.20 AS Decimal(18, 2)), N'dau-goi-buoi-cocoon-duong-am-giup-giam-rung-toc-chai-310ml.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (16, N'Dầu gội Romano classic giúp sạch gàu chai 650g
', N'
Romano', 1003, N'Cái', CAST(148.90 AS Decimal(18, 2)), N'dau-goi-romano-classic-sach-gau-duong-da-dau-thumb-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (17, N'Dầu gội OGX Thick Full Biotin Collagen dưỡng tóc bồng bềnh chai 385ml', N'Johnson & Johnson', 1003, N'Cái', CAST(295.00 AS Decimal(18, 2)), N'dau-goi-romano-classic-sach-gau-duong-da-dau-thumb-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (18, N'Dầu Gội Vichy Dercos hỗ trợ trị gàu chai 75ml', N'
Vichy', 1003, N'Cái', CAST(140.80 AS Decimal(18, 2)), N'dau-goi-vichy-dercos-ho-tro-sach-gau-chai-75ml-121023-074835-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (19, N'Dầu xả thảo dược Gừng dừa Cocay Hoala giúp tóc mềm mượt, giảm khô xơ chai 440g', N'Ona Global', 1003, N'Cái', CAST(175.00 AS Decimal(18, 2)), N'dau-xa-thao-duoc-co-cay-hoa-la-gung-dua-440g-thumb-1-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (20, N'Serum Welhair ngăn rụng tóc, kích thích mọc tóc lọ 100ml
', N'Dân Khang', 1003, N'Cái', CAST(185.00 AS Decimal(18, 2)), N'tinh-chat-ngan-rung-toc-welhair-chai-100ml-thumb-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (21, N'Bông tẩy trang Jomi mềm mịn không xơ bông dạng tròn gói 120 miếng
', N'Jomi', 1004, N'Cái', CAST(37.00 AS Decimal(18, 2)), N'bong-tay-trang-jomi-120-mieng-thumb-1-6-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (22, N'Bông tẩy trang Niva mềm mịn dạng tròn gói 100 miếng', N'Niva', 1004, N'Cái', CAST(42.00 AS Decimal(18, 2)), N'bong-tay-trang-niva-tui-tron-100-mieng-thumb-1-4-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (23, N'Nước tẩy trang Senka All Clear Water Fresh giảm mụn, kiểm soát nhờn chai 230ml', N'
Senka', 1004, N'Cái', CAST(113.00 AS Decimal(18, 2)), N'senka-all-clear-water-fresh-thumb-1-5-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (24, N'Nước tẩy trang Senka All Clear Water White sạch bã nhờn, mờ vết sạm chai 230ml', N'
Senka', 1004, N'Cái', CAST(107.10 AS Decimal(18, 2)), N'senka-all-clear-water-white-230ml-070323-020947-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (25, N'Sữa rửa mặt Cetaphil Gentle Skin Cleanser làm sạch dịu nhẹ chai 125ml', N'G Production', 1002, N'Cái', CAST(160000.00 AS Decimal(18, 2)), N'sua-rua-mat-diu-nhe-cetaphil-gentle-skin-cleanser-070323-045841-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (26, N'Kem rửa mặt Hada Labo Advanced Nourish dưỡng ẩm da tuýp 80g', N'Rohto-Mentholatum ', 1002, N'Cái', CAST(175000.00 AS Decimal(18, 2)), N'kem-rua-mat-hada-labo-advanced-nourish-cleanser-070323-050116-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (27, N'Kem rửa mặt Acnes Vitamin sáng da, mờ vết thâm tuýp 100g', N'Acnes', 1002, N'Cái', CAST(155000.00 AS Decimal(18, 2)), N'srm-ances-vitamin-100g-thumb-2-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (28, N'Gel rửa mặt La Roche-Posay Effaclar Purifying Foaming cho da dầu, nhạy cảm tuýp 200ml', N'La Roche-Posay', 1002, N'Cái', CAST(14500.00 AS Decimal(18, 2)), N'laroche-posay-effaclar-purifying-foaming-gel-200ml-070323-050348-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (29, N'Kem rửa mặt Hada Labo Perfect White dưỡng trắng tuýp 80g', N'Hada Labo', 1002, N'Cái', CAST(89000.00 AS Decimal(18, 2)), N'hada-labo-perfect-white-arbutin-cleanser-80g-070323-050423-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (30, N'Gel rửa mặt Decumar Anti-acne Oil Control giảm nhờn cho da mụn tuýp 50g', N'Công ty Cổ phần Dược Mỹ Phẩm CVI ', 1002, N'Cái', CAST(100000.00 AS Decimal(18, 2)), N'gel-rua-mat-decumar-advanced-tuyp-50g-thumb-1-5-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (31, N'Sữa rửa mặt thảo dược Sắc Ngọc Khang giúp da trắng sáng, mờ sạm nám tuýp 100g', N'Hoa Thiên Phú ', 1002, N'Cái', CAST(134000.00 AS Decimal(18, 2)), N'sua-rua-mat-sac-ngoc-khang-100g-201123-032220-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (32, N'Sữa rửa mặt Senka Perfect Whip Acne Care ngừa mụn tuýp 100g', N'Shiseido', 1002, N'Cái', CAST(123000.00 AS Decimal(18, 2)), N'sua-rua-mat-senka-perfect-whip-da-mun-tuyp-100g-070323-050536-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (33, N'Sữa rửa mặt Senka Perfect Whip Collagen In ngừa lão hóa tuýp 120g', N'Shiseido', 1002, N'Cái', CAST(123000.00 AS Decimal(18, 2)), N'sua-rua-mat-senka-collagen-perfect-whip-120g-thumb-1-5-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (34, N'Gel rửa mặt Isis Pharma Teen Derm giảm nhờn, ngừa mụn tuýp 150ml', N'ISIS Pharma ', 1002, N'Cái', CAST(123000.00 AS Decimal(18, 2)), N'gel-rua-mat-giam-nhon-ngua-mun-teenderm-gel-150ml-070323-050903-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (35, N'Kem Oxy 5 hỗ trợ điều trị mụn bọc, mụn trứng cá tuýp 10g', N'M-Technologies', 1006, N'Cái', CAST(50000.00 AS Decimal(18, 2)), N'thuoc-tri-mun-oxy-5-10g-thumb01-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (36, N'Kem Oxy 10 hỗ trợ điều trị mụn bọc, mụn sưng đỏ tuýp 10g', N'M-Technologies', 1006, N'Cái', CAST(49000.00 AS Decimal(18, 2)), N'oxy-10-thumb-1-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (37, N'Tozinax 10mg phòng và điều trị thiếu kẽm (10 vỉ x 10 viên)', N'Rebom Cosmetics Co., Ltd', 1006, N'Cái', CAST(30000.00 AS Decimal(18, 2)), N'tozinax-10mg-thumb-1-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (38, N'Acnacare hỗ trợ giảm mụn, viêm tuyến bã nhờn hộp 30 viên', N'Aveflor', 1006, N'Cái', CAST(119000.00 AS Decimal(18, 2)), N'vien-uong-acnacare-30-vien-thumb-2-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (39, N'Nhau thai cừu Maxi 50000 Placental hỗ trợ chống oxy hóa, giữ ẩm cho da hộp 100 viên', N'Stratpharma', 1006, N'Cái', CAST(559000.00 AS Decimal(18, 2)), N'nhau-thai-cuu-well-being-nutrition-maxi-5000-placental-hop-100-vien-thumb-1-1-600x600.jpg', NULL, NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [HangSX], [MaLoai], [MoTaDonVi], [DonGia], [Hinh], [NgaySX], [GiamGia], [MoTa]) VALUES (40, N'Gel Acnes Sealing Jell hỗ trợ ngừa mụn giảm sẹo thâm tuýp 18g', N'Rohto-Mentholatum ', 1006, N'Cái', CAST(70000.00 AS Decimal(18, 2)), N'gel-ho-tro-ngua-mun-giam-khuan-acnes-sealing-jell-18g-thumb-1-2-600x600.jpg', NULL, NULL, NULL)
GO
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (1001, N'Kem Chống Nắng', NULL)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (1002, N'Sửa Rửa Mặt', NULL)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (1003, N'Dầu gội /Dầu Xả', NULL)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (1004, N'Tẩy Trang Mặt', NULL)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (1005, N'Chăm Sóc Răng Miệng', NULL)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MoTa]) VALUES (1006, N'Hổ Trợ Trị Mụn ', NULL)
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_Loai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_Loai]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaTrangThai])
REFERENCES [dbo].[TrangThai] ([MaTrangThai])
GO
USE [master]
GO
ALTER DATABASE [Genuine_Cosmetic] SET  READ_WRITE 
GO
